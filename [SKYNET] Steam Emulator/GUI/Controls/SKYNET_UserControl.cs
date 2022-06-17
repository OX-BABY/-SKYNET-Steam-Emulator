﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SKYNET.Types;

namespace SKYNET.GUI.Controls
{
    public partial class SKYNET_UserControl : UserControl
    {
        private SteamPlayer steamPlayer;

        [Category("SKYNET")]
        public SteamPlayer SteamPlayer
        {
            get { return steamPlayer;  }
            set
            {
                steamPlayer = value;
                LB_PersonaName.Text = steamPlayer.PersonaName;
                LB_IPAddress.Text = steamPlayer.IPAddress;
            }
        }

        public SKYNET_UserControl()
        {
            InitializeComponent();
        }

        private void SKYNET_UserControl_MouseMove(object sender, MouseEventArgs e)
        {
            BackColor = Color.FromArgb(43, 53, 63);
        }

        private void SKYNET_UserControl_MouseLeave(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(33, 43, 53);
        }
    }
}