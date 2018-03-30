using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hypertag.Advising
{
    public partial class Form1 : Form
    {
        Common.frmUI UI = new Common.frmUI();
        Common.frmDB db = new Common.frmDB();
        Common.frmProfile profile = new Common.frmProfile();

        Presentation.frmStudent student = new Presentation.frmStudent();

        public Form1()
        {
            
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Login();   

            Hypertag.Advising.ACL.Login = new DAL.Login() {  LoginId = 1, Contact = "", Email = "admin@system.com", Password = "", Name = "Mr System Admin", Type = "A"};


        }

        private void Login()
        {
            Hypertag.Advising.ACL.Login = null;
            mnuMain.Enabled = false;
            mnuUserList.Visible = false;
            mnuAdmin.Visible = false;
            btnLogInOut.Text = "Login";
            Hypertag.Advising.Common.frmLogin lgn = new Hypertag.Advising.Common.frmLogin();
            lgn.ShowDialog();

            Hypertag.Advising.DAL.MyBase ct = new Hypertag.Advising.DAL.City();



            

            if (Hypertag.Advising.ACL.Login != null)
            {
                mnuMain.Enabled = true;
                if (Hypertag.Advising.ACL.Login.Type == "A")
                {
                    mnuUserList.Visible = !false;
                    mnuAdmin.Visible = !false;
                }
                btnLogInOut.Text = "Logout";
            }
        }

        private void btnLogInOut_Click(object sender, EventArgs e)
        {
            //Login();
        }

        private void uISettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UI.IsDisposed)
                UI = new Common.frmUI();
            UI.MdiParent = this;
            UI.Show();
            UI.BringToFront();
        }

        private void dBSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (db.IsDisposed)
                db = new Common.frmDB();
            db.MdiParent = this;
            db.Show();
            db.BringToFront();
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmTest().ShowDialog();
        }

        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Help.frmManual().Show();
        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (profile.IsDisposed)
                profile = new Common.frmProfile();
            profile.MdiParent = this;
            profile.Show();
            profile.BringToFront();
        }
        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (student.IsDisposed)
                student = new Presentation.frmStudent();
            student.MdiParent = this;
            student.Show();
            student.BringToFront();
        }
    }
}