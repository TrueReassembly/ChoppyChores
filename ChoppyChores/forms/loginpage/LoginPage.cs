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

            FormClosed += new FormClosedEventHandler(LoginPage_FormClosed); // Event handler for when the form is closed
        }

        // Button click event for the login button
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string parsedword = GeneralUtils.ComputeHash(txtPassword.Text); // Hash the password entered by the user

            foreach (var child in DataFileHandler.Instance.GetAllChildren())
            {
                if (child.GetUsername() == txtUsername.Text && child.GetPassword() == parsedword) // If the username and password match the child's details, set the logged in child and open the ChildDashboard form
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

            // Run the same check for the parents
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

            MessageBox.Show("Incorrect username or password");
        }

        // When the form is closed, close the application
        void LoginPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
