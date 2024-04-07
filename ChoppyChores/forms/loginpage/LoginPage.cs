using System;
using System.IO;
using System.Windows.Forms;
using ChoppyChores.data;
using ChoppyChores.forms.child;
using ChoppyChores.forms.parent;
using ChoppyChores.forms.parent.chores;
using ChoppyChores.models;
using ChoppyChores.utils;

namespace ChoppyChores
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();

            FormClosed += new FormClosedEventHandler(LoginPage_FormClosed);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string parsedword = GeneralUtils.ComputeHash(txtPassword.Text);

            foreach (var child in DataFileHandler.Instance.GetAllChildren())
            {
                if (child.GetUsername() == txtUsername.Text && child.GetPassword() == parsedword)
                {
                    // new ChildDashboard(child).Show();
                    // this.Hide();
                    MessageBox.Show("Login Successful for " + child.GetUsername(), "a", MessageBoxButtons.OK);
                    DataFileHandler.Instance.SetLoggedInChild(child);
                    Hide();
                    var childDashboard = new ChildDashboard();
                    childDashboard.ShowDialog();
                    return;
                }
            }

            foreach (var parent in DataFileHandler.Instance.GetParents())
            {
                if (parent.GetUsername() == txtUsername.Text && parent.GetPassword() == parsedword)
                {
                    MessageBox.Show("Login Successful for " + parent.GetUsername(), ".", MessageBoxButtons.OK);
                    Hide();
                    new ParentDashboard().ShowDialog();
                    return;
                }
            }
        }

        void LoginPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
