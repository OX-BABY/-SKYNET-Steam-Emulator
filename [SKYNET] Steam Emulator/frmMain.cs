﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using SKYNET.Client;
using SKYNET.Common;
using SKYNET.GUI;
using SKYNET.GUI.Controls;
using SKYNET.Helper;
using SKYNET.Managers;
using SKYNET.Properties;
using SKYNET.Types;

namespace SKYNET
{
    public partial class frmMain : frmBase
    {
        public static frmMain frm;
        public static Types.Settings settings;
        public Process InjectedProcess;
        public SteamClient SteamClient;

        private List<RunningGame> RunningGames;
        private GameBox SelectedBox;
        private GameBox MenuBox;
        private Dictionary<uint, List<string>> GameMessages;
        private int ProcessId;
        

        public frmMain()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            SetMouseMove(PN_Top);
            frm = this;

            Log.OnMessage += Log_OnMessage;

            settings = Types.Settings.Load();
            LB_NickName.Text = settings.PersonaName;
            LB_Menu_NickName.Text = settings.PersonaName.ToUpper();
            LB_SteamID.Text = settings.AccountID.ToString();

            GameMessages = new Dictionary<uint, List<string>>();
            RunningGames = new List<RunningGame>();
                 
            modCommon.EnsureDirectoryExists(Path.Combine(modCommon.GetPath(), "Data"));
            modCommon.EnsureDirectoryExists(Path.Combine(modCommon.GetPath(), "Data", "www"));
            modCommon.EnsureDirectoryExists(Path.Combine(modCommon.GetPath(), "Data", "Storage"));
            modCommon.EnsureDirectoryExists(Path.Combine(modCommon.GetPath(), "Data", "Images"));
            modCommon.EnsureDirectoryExists(Path.Combine(modCommon.GetPath(), "Data", "Images", "AppCache"));
            modCommon.EnsureDirectoryExists(Path.Combine(modCommon.GetPath(), "Data", "Images", "AvatarCache"));
            modCommon.EnsureDirectoryExists(Path.Combine(modCommon.GetPath(), "Data", "Images", "Avatars"));
            modCommon.EnsureDirectoryExists(Path.Combine(modCommon.GetPath(), "Data", "cefsharp", "locales"));


            try
            {
                string AvatarPath = Path.Combine(modCommon.GetPath(), "Data", "Images", "AvatarCache", "Avatar.jpg");
                if (File.Exists(AvatarPath))
                {
                    var AvatarImage = ImageHelper.FromFile(AvatarPath);
                    PB_Avatar.Image = AvatarImage;
                    SteamClient.Avatar = (Bitmap)AvatarImage;
                }
            }
            catch (Exception)
            {
            }

            GameManager.OnGameAdded += GameManager_OnGameAdded;
            GameManager.OnGameUpdated += GameManager_OnGameUpdated;
            GameManager.OnGameRemoved += GameManager_OnGameRemoved;
            GameManager.Initialize();

            shadowBox1.BackColor = Color.FromArgb(100, 0, 0, 0);

            SteamClient = new SteamClient(settings);
            SteamClient.Initialize();

            UserManager.OnUserAdded += UserManager_OnUserAdded;
            UserManager.OnUserUpdated += UserManager_OnUserUpdated;
            UserManager.OnUserRemoved += UserManager_OnUserRemoved;
            UserManager.OnAvatarReceived = UserManager_OnAvatarReceived;

            new frmBrowser().ShowDialog();
        }

        #region GameManager Events

        private void GameManager_OnGameAdded(object sender, Game e)
        {
            AddBoxGame(e);
        }

        private void GameManager_OnGameUpdated(object sender, Game e)
        {
            foreach (var control in PN_GameContainer.Controls)
            {
                if (control is GameBox && ((GameBox)control).Handle.ToInt32() == MenuBox.Handle.ToInt32())
                {
                    ((GameBox)control).SetGame(e);
                    return;
                }
            }
        }

        private void GameManager_OnGameRemoved(object sender, Game e)
        {

        }

        #endregion

        #region UserManager Events

        private void UserManager_OnUserAdded(object sender, SteamPlayer user)
        {
            var control = new SKYNET_UserControl();
            control.SteamPlayer = user;
            control.Dock = DockStyle.Top;

            modCommon.InvokeAction(PN_UserContainer, delegate
            {
                PN_UserContainer.Controls.Add(control);
            });
        }

        private void UserManager_OnUserUpdated(object sender, SteamPlayer user)
        {

        }

        private void UserManager_OnUserRemoved(object sender, SteamPlayer user)
        {

        }

        private void UserManager_OnAvatarReceived(object sender, UserManager.AvatarReceivedEventArgs e)
        {
            for (int i = 0; i < PN_UserContainer.Controls.Count; i++)
            {
                var control = PN_UserContainer.Controls[i];
                if (control is SKYNET_UserControl)
                {
                    var User = (SKYNET_UserControl)control;
                    if (User.SteamPlayer.AccountID == e.AccountID)
                    {
                        User.PB_Avatar.Image = e.Avatar;
                    }
                }
            }
        }

        #endregion

        private void Log_OnMessage(object sender, LogEventArgs Event)
        {
            Write(Event.Sender, Event.Message);
        }

        private void GameBox_Clicked(object sender, MouseEventArgs e )
        {
            GameBox b = (GameBox)sender;
            if (e.Button == MouseButtons.Left)
            {
                SelectBox(b);
            }
            if (e.Button == MouseButtons.Right)
            {
                MenuBox = b;
                CM_MenuGame.Show(b, new Point(e.Location.X, e.Location.Y));
            }
        }

        private void GameBox_DoubleClicked(object sender, GameBox e)
        {
            SelectBox(e);
            OpenGame(e);
        }

        private void SelectBox(GameBox e)
        {
            SelectedBox = e;

            if (RunningGames.Find(x => x.Game == e.GetGame()) != null)
            {
                BT_GameAction.Text = "CLOSE";
                BT_GameAction.BackColor = Color.Red;
            }
            else
            {
                BT_GameAction.Text = "PLAY";
                BT_GameAction.BackColor = Color.FromArgb(46, 186, 65);
            }

            PB_Logo.Image = e.Image;
            LB_GameTittle.Text = e.GameName;

            string imagePath = Path.Combine(modCommon.GetPath(), "Data", "Images", "AppCache", e.AppId + "_library_hero.jpg");
            if (File.Exists(imagePath))
            {
                PB_Banner.Image = Image.FromFile(imagePath);
            }
            else
            {
                PB_Banner.Image = Resources.Header_1;
            }

            foreach (var control in PN_GameContainer.Controls)
            {
                if (control is GameBox)
                {
                    ((GameBox)control).Selected = false;
                }
            }

            e.Selected = true;
            BT_GameAction.Visible = true;

        }

        private void AddBoxGame(Game game)
        {
            var module = new GameBox();
            module.SetGame(game);
            module.Dock = DockStyle.Top;
            module.BoxClicked += GameBox_Clicked;
            module.BoxDoubleClicked += GameBox_DoubleClicked;
            module.BackColor = Color.FromArgb(23, 33, 43);
            module.Color = Color.FromArgb(23, 33, 43);
            module.Color_MouseHover = Color.FromArgb(33, 43, 53);
            
            PN_GameContainer.Controls.Add(module);
        }


        private void OpenGame(GameBox e)
        {
            Game game = e.GetGame();

            if (game.LaunchWithoutEmu)
            {
                Process.Start(game.ExecutablePath, game.Parameters);
                return;
            }

            Write("SteamClient", "Opening " + game.Name);

            string x86Dll = Path.Combine(modCommon.GetPath(), "x86", "steam_api.dll");
            string x64Dll = Path.Combine(modCommon.GetPath(), "x64", "steam_api64.dll");

            var pInfo = new ProcessStartInfo();
            pInfo.FileName = game.ExecutablePath;
            pInfo.Arguments = game.Parameters;
            pInfo.CreateNoWindow = true;
            pInfo.RedirectStandardOutput = true;
            pInfo.UseShellExecute = false;
            InjectedProcess = Process.Start(pInfo);

            var content = "";
            if (modCommon.Is64Bit)
            {
                content = $"rundll32 \"x64/steam_api64.dll\",Initialize {InjectedProcess.ProcessName}.exe";
            }
            else
                content = $"rundll32 \"x86/steam_api.dll\",Initialize {InjectedProcess.ProcessName}.exe";

            string injPath = Path.Combine(modCommon.GetPath(), "Inject.cmd");
            File.WriteAllText(injPath, content);
            Process.Start(injPath);

            //InjectedProcess = DllInjector.Inject(game.ExecutablePath, game.Parameters, x64Dll, x86Dll);

            RunningGames.Add(new RunningGame() { Game = e.GetGame(), Process = InjectedProcess });
            BT_GameAction.Text = "CLOSE";
            BT_GameAction.BackColor = Color.Red;
            WaitForExit();
        }

        internal static void AvatarUpdated(Bitmap Avatar)
        {
            SteamClient.Avatar = Avatar;
            frm.PB_Avatar.Image = Avatar;
            IPCManager.SendAvatarUpdated(SteamClient.AccountID, Avatar);

            try
            {
                string AvatarPath = Path.Combine(modCommon.GetPath(), "Data", "Images", "AvatarCache", "Avatar.jpg");
                modCommon.EnsureDirectoryExists(AvatarPath, true);
                ImageHelper.ToFile(AvatarPath, Avatar);
            }
            catch 
            {
                modCommon.Show("Error saving avatar image");
            }
        }

        internal static void PersonaNameUpdated(string PersonaName)
        {
            SteamClient.PersonaName = PersonaName;
            frm.LB_NickName.Text = PersonaName;
            frm.LB_Menu_NickName.Text = PersonaName.ToUpper();
            IPCManager.SendUserDataUpdated(SteamClient.AccountID, PersonaName);
            settings.PersonaName = PersonaName;
            settings.Save();
        }

        private void WaitForExit()
        {
            Task.Run(() =>
            {
                int closeId = 0;
                string processName = "";
                while (ProcessId != closeId)
                {
                    try
                    {
                        Process processById = Process.GetProcessById(ProcessId);
                        processName = processById.ProcessName;
                        closeId = ProcessId;
                        processById.WaitForExit();
                    }
                    catch (Exception)
                    {
                    }
                }
                Write("SteamClient", $"The injected process {processName} are closed");

                foreach (var game in RunningGames)
                {
                    if (GameMessages.ContainsKey(game.Game.AppID) && game.Game.LogToFile)
                    {
                        string logPath = Path.Combine(modCommon.GetPath(), "Data", "Storage", game.Game.AppID.ToString(), "GameMessages.log");
                        File.WriteAllLines(logPath, GameMessages[game.Game.AppID]);
                    }
                }

                BT_GameAction.Text = "PLAY";
                BT_GameAction.BackColor = Color.FromArgb(46, 186, 65);
            });
        }

        private void Write(string sender, object msg)
        {
            WebLogger1.WriteLine(new ConsoleMessage(0, sender, msg));
        }

        private void Close_Clicked(object sender, EventArgs e)
        {
            string path = Path.Combine(modCommon.GetPath(), "Data", "Games.bin");
            modCommon.EnsureDirectoryExists(path);

            settings.Save();

            List<Game> Games = new List<Game>();
            foreach (var control in PN_GameContainer.Controls)
            {
                if (control is GameBox)
                {
                    Games.Add(((GameBox)control).GetGame());
                }
            }

            string json = new JavaScriptSerializer().Serialize(Games);
            File.WriteAllText(path, json);

            Process.GetCurrentProcess().Kill();
        }

        private void Minimize_Clicked(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            int attrValue = 2;
            DwmApi.DwmSetWindowAttribute(base.Handle, 2, ref attrValue, 16);
            DwmApi.MARGINS mARGINS = default(DwmApi.MARGINS);
            mARGINS.cyBottomHeight = 1;
            mARGINS.cxLeftWidth = 0;
            mARGINS.cxRightWidth = 0;
            mARGINS.cyTopHeight = 0;
            DwmApi.MARGINS marInset = mARGINS;
            DwmApi.DwmExtendFrameIntoClientArea(base.Handle, ref marInset);
        }


        private void TB_Search_KeyUp(object sender, KeyEventArgs e)
        {
            FindGame(TB_Search.Text);
        }

        private void FindGame(string word = "")
        {
            foreach (var control in PN_GameContainer.Controls)
            {
                if (control is GameBox)
                {
                    GameBox Game = (GameBox)control;

                    if (string.IsNullOrEmpty(word))
                    {
                        Game.Visible = true;
                    }
                    else
                    {
                        if (Game.Name.ToLower().Contains(word.ToLower()))
                        {
                            Game.Visible = true;
                        }
                        else
                        {
                            Game.Visible = false;
                        }
                    }
                }
            }
        }

        private void Add_MouseMove(object sender, MouseEventArgs e)
        {
            LB_Add.ForeColor = Color.White;
            PB_Add.Image = Resources.add_Selected;
        }

        private void Add_MouseLeave(object sender, EventArgs e)
        {
            LB_Add.ForeColor = Color.FromArgb(200, 200, 200);
            PB_Add.Image = Resources.add;
        }

        private void GameAction_Click(object sender, EventArgs e)
        {
            if (BT_GameAction.Text == "PLAY")
            {
                OpenGame(SelectedBox);
            }
            else
            {
                var Game = RunningGames.Find(x => x.Game == SelectedBox.GetGame());
                if (Game != null)
                {
                    try
                    {
                        Game.Process.Kill();

                        foreach (var game in RunningGames)
                        {
                            if (GameMessages.ContainsKey(game.Game.AppID) && game.Game.LogToFile)
                            {
                                string logPath = Path.Combine(modCommon.GetPath(), "Data", "Storage", game.Game.AppID.ToString(), "GameMessages.log");
                                File.WriteAllLines(logPath, GameMessages[game.Game.AppID]);
                            }
                        }

                        RunningGames.Remove(Game);
                    }
                    catch { }
                }
            }
        }

        private void AddGame_Clicked(object sender, MouseEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog()
            {
                 Filter = "exe file | *.exe",
                 Multiselect = false
            };
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                new frmGameManager(fileDialog.FileName).ShowDialog();
            }
        }

        #region Menu items events
        private void ToTopMenuItem_Click(object sender, EventArgs e)
        {
            MenuBox.SendToBack();
        }

        private void OpenMenuItem_Click(object sender, EventArgs e)
        {
            OpenGame(MenuBox);
        }

        private void OpenWithoutEmuMenuItem_Click(object sender, EventArgs e)
        {
            var game = MenuBox.GetGame();
            Process.Start(game.ExecutablePath, game.Parameters);
            return;
        }

        private void OpenFileLocationMenuItem_Click(object sender, EventArgs e)
        {
            modCommon.OpenFolderAndSelectFile(MenuBox.GetGame().ExecutablePath);
        }

        private void ConfigureMenuItem_Click(object sender, EventArgs e)
        {
            new frmGameManager(MenuBox).ShowDialog();
        }

        private void RemoveMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = modCommon.Show("You are sure you want to remove this game?", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.OK)
            {
                for (int i = 0; i < PN_GameContainer.Controls.Count; i++)
                {
                    object control = PN_GameContainer.Controls[i];
                    if (control is GameBox && ((GameBox)control).Handle == MenuBox.Handle)
                    {
                        Game game = ((GameBox)control).GetGame();
                        GameManager.Remove(game.AppID);
                        PN_GameContainer.Controls.RemoveAt(i);
                    }
                }
            }
        }

        private void ToButtomMenuItem_Click(object sender, EventArgs e)
        {
            MenuBox.BringToFront();
        }

        private void GameCacheMenuItem_Click(object sender, EventArgs e)
        {
            if (MenuBox.AppId == 0)
            {
                modCommon.Show("Please configure a valid AppId for this game.");
                return;
            }
            new frmGameDownload(MenuBox).ShowDialog();
        }

        #endregion

        private void PN_GameContainer_DragDrop(object sender, DragEventArgs e)
        {
            string path = ((string[])e.Data.GetData(DataFormats.FileDrop, false))[0];
            new frmGameManager(path).ShowDialog();
        }

        private void PN_GameContainer_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void BT_Profile_Click(object sender, EventArgs e)
        {
            new frmUpdateProfile().ShowDialog();
        }
    }
}
