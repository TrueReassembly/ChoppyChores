using System;
using ChoppyChores.models;
using System.Windows.Forms;

namespace ChoppyChores.forms.loginpage
{
    public partial class FirstAccountPage : Form
    {
        public FirstAccountPage()
        {
            InitializeComponent();
        }

        // Create a parent account
        private void btn_CreateAccount_Click(object sender, EventArgs e)
        {
            var username = txt_Username.Text;
            var password = txt_Password.Text;
            new Parent(username, password).Save();
            MessageBox.Show("Parent account created! Please open the application again and log in with the details!");
            Close();
        }
    }
}
