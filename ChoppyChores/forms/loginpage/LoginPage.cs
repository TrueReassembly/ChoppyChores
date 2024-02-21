using System;
using System.IO;
using System.Windows.Forms;
using ChoppyChores.data;
using ChoppyChores.models;
using ChoppyChores.utils;

namespace ChoppyChores
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
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
                    return;
                }
            }
        }
    }
}
