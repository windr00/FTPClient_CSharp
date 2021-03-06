﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FTPClient.Forms;

namespace FTPClient
{
    public partial class frmMain : Form
    {
        private string host;
        private int port;
        private string user;
        private string pass;
        private CMDAgent agent;


        private delegate void CMDDone(Statics.CMD_TYPE type, bool state, string result);

        private CMDDone onDone;

        public frmMain(string host, int port, string user, string pass)
        {
            this.host = host;
            this.port = port;
            this.user = user;
            this.pass = pass;
            InitializeComponent();
            this.Text = user + "@" + host + ":" + port;
            this.onDone = OnCMDDone;
        }

        private void OnCMDDone(Statics.CMD_TYPE type, bool state, object result)
        {
            
                Type t = this.GetType();
                var method = "On" + type.ToString() + "Done";
               
                MethodInfo info = t.GetMethod(method, BindingFlags.NonPublic | BindingFlags.Instance, null, new []{typeof(object)}, null);
                if (state)
                {
                    info.Invoke(this, new object[] {result});
                }
                else
                {
                    OnError(type, result as string);
                }
        }

        public void OnfrmLoginClose(string user, string pass)
        {
            this.user = user;
            this.pass = pass;
            this.Enabled = true;
            frmMain_Load(null, null);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (!(user != string.Empty && pass != string.Empty))
            {
                frmLogin login = new frmLogin(user, pass, OnfrmLoginClose);
                this.Enabled = false;
                login.Show();
            }
            else
            {
                agent = new CMDAgent();
                agent.Command(Statics.CMD_TYPE.LOGIN, OnCMDDone, host, port.ToString(), user, pass);
            }
        }


    }
}
