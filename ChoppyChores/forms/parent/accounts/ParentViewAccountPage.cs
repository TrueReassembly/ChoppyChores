using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ChoppyChores.data;
using ChoppyChores.models;
using ChoppyChores.utils;

namespace ChoppyChores.forms.parent.accounts
{
    public partial class ParentViewAccountPage : Form
    {
        
        private List<Child> _children;
        private int pointer = 0;
        public ParentViewAccountPage()
        {
            InitializeComponent();
            
            FormClosed += new FormClosedEventHandler(ParentViewAccountPage_FormClosed);
            _children = DataFileHandler.Instance.GetAllChildren();
            LoadEverything();
        }

        private void LoadEverything()
        {
            if (_children.Count == 0)
            {
                return;
            }
            var child = _children[pointer];
            txt_Username.Text = child.GetUsername();
            txt_Password.Text = "";
            num_Age.Value = child.GetAge();
            num_Points.Value = child.GetPoints();
        }
        
        private void buttonHome_Click(object sender, EventArgs e)
        {
            Hide();
            new ParentDashboard().ShowDialog();
        }
        
        private void buttonChores_Click(object sender, EventArgs e)
        {
            Hide();
            new chores.ParentViewChoresPage().ShowDialog();
        }

        private void buttonAccounts_Click(object sender, EventArgs e)
        {
            return;
        }

        private void buttonRewards_Click(object sender, EventArgs e)
        {
            Hide();
            new rewards.ParentViewRewards().ShowDialog();
        }
        
        void ParentViewAccountPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void buttonNewChild_Click(object sender, EventArgs e)
        {
            var age = (int) Math.Floor(num_Age.Value);
            var points = (int) Math.Floor(num_Points.Value);
            if (txt_Password.Text == "")
            {
                MessageBox.Show("Please enter a password for the child account.");
                return;
            }
            if (txt_Username.Text == "")
            {
                MessageBox.Show("Please enter a username for the child account.");
                return;
            }
            var child = new Child(txt_Username.Text, txt_Password.Text, age, points);
            child.Save();
            MessageBox.Show("Child account created!");
            _children = DataFileHandler.Instance.GetAllChildren();
            pointer = _children.Count - 1;
            LoadEverything();
        }

        private void buttonSaveChild_Click(object sender, EventArgs e)
        {
            
            if (_children.Count == 0)
            {
                MessageBox.Show("Please use the 'New Child' button to create a new child account first.");
            }
            var child = _children[pointer];
            child.SetUsername(txt_Username.Text);
            child.SetAge((int) Math.Floor(num_Age.Value));
            child.SetPoints((int) Math.Floor(num_Points.Value));
            
            if (txt_Password.Text != "")
            {
                child.ResetPassword(txt_Password.Text);
            }
            child.Save();
            MessageBox.Show("Child account updated!");
        }

        private void buttonPrevPage_Click(object sender, EventArgs e)
        {
            if (pointer == 0)
            {
                pointer = _children.Count - 1;
            } else
            {
                pointer--;
            }

            LoadEverything();
            
            
        }

        private void buttonNextPage_Click(object sender, EventArgs e)
        {
            if (pointer == _children.Count - 1)
            {
                pointer = 0;
            } else
            {
                pointer++;
            }

            LoadEverything();
        }
    }
}
