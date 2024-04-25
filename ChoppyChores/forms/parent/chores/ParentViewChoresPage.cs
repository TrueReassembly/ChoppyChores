using System;
using ChoppyChores.models;
using ChoppyChores.data;
using System.Windows.Forms;
using System.Collections.Generic;
using ChoppyChores.forms.parent.accounts;
using ChoppyChores.forms.parent.rewards;

namespace ChoppyChores.forms.parent.chores
{
    public partial class ParentViewChoresPage : Form
    {

        List<Chore> chores = new List<Chore>();
        List<Child> children = new List<Child>();
        int pointer;

        public ParentViewChoresPage()
        {
            pointer = 0;
            
            
            InitializeComponent();

            FormClosed += new FormClosedEventHandler(ParentViewChoresPage_FormClosed);
        }

        // Load the chore information
        public void LoadEverything()
        {
            children.Clear();
            children = DataFileHandler.Instance.GetChildrenSortedByName();
            chores = DataFileHandler.Instance.GetAllChores();
            // If there are no chores, display a message to the user and clear the text boxes
            if (chores.Count == 0)
            {
                txtChoreName.Text = "";
                numAge.Text = "";
                numPoints.Text = "";
                lblPage.Text = "0/0";
                MessageBox.Show("Please enter parameters into the empty option boxes then click 'New Chore' to create a new chore");
                comboAssignedTo.Items.Clear();
                comboAssignedTo.Items.Add("Unassigned");
                foreach (var theChild in children)
                {
                    comboAssignedTo.Items.Add(theChild.GetUsername());
                }
                return;
            }

            Chore chore = chores[pointer];
            txtChoreName.Text = chore.GetName();
            
            numAge.Text = chore.GetMinAge().ToString();
            numPoints.Text = chore.GetReward().ToString();
            lblPage.Text = (pointer + 1) + " / " + chores.Count;
            comboAssignedTo.Items.Clear();
            comboAssignedTo.Items.Add("Unassigned");
            // Add the children to the combo box options
            foreach (var theChild in children)
            {
                comboAssignedTo.Items.Add(theChild.GetUsername());
            }
            var child = DataFileHandler.Instance.GetChildFromName(chore.GetClaimedBy().ToString());
           
            // If the chore is unassigned, set the combo box to unassigned, otherwise set it to the child's name
            if (child != null)
            {
                comboAssignedTo.SelectedIndex = children.IndexOf(child);
            }
            else
                comboAssignedTo.SelectedIndex = -1;
        }

        private void ParentViewChoresPage_Load(object sender, EventArgs e)
        {
            LoadEverything();
        }

        // Save the chore information
        private void buttonSaveChore_Click(object sender, EventArgs e)
        {
            // If there are no chores, display a message to the user
            if (chores.Count == 0)
            {
                MessageBox.Show("Please use the 'New Chore' button to create the new chore");
                return;
            }

            // Validation for the chore name, minimum age, and reward
            if (txtChoreName.Text == "")
            {
                MessageBox.Show("Please enter a chore name");
                return;
            }
            if (numAge.Text == "")
            {
                MessageBox.Show("Please enter a minimum age");
                return;
            }
            if (numPoints.Text == "")
            {
                MessageBox.Show("Please enter a reward");
                return;
            }
            
            // Overwrite the chore information
            Chore chore = chores[pointer];
            chore.SetName(txtChoreName.Text);
            chore.SetReward(int.Parse(numPoints.Text));
            chore.SetMinAge(int.Parse(numAge.Text));
            // If the combo box is unassigned, set the chore to unassigned, otherwise set it to the child's ID
            if (comboAssignedTo.SelectedIndex == 0 || comboAssignedTo.SelectedIndex == -1)
            {
                chore.SetClaimedBy("0");
            }
            else
            {
                chore.SetClaimedBy(children[comboAssignedTo.SelectedIndex - 1].GetId());
            }
            // Save the chore information
            chore.Save();
            MessageBox.Show("Chore Information Saved!");
        }

        // Go to the next page of chores
        private void buttonNextPage_Click(object sender, EventArgs e)
        {
            if (pointer == chores.Count - 1)
            {
                pointer = 0;
            }
            else pointer++;

            LoadEverything();
        }

        // Go to the previous page of chores
        private void buttonPrevPage_Click(object sender, EventArgs e)
        {
            if (pointer == 0)
            {
                pointer = chores.Count - 1;
            }
            else pointer--;

            LoadEverything();
        }

        private void buttonNewChore_Click(object sender, EventArgs e)
        {
            // Validation for the chore name, minimum age, and reward
            if (txtChoreName.Text == "")
            {
                MessageBox.Show("Please enter a chore name");
                return;
            }
            if (numAge.Text == "")
            {
                MessageBox.Show("Please enter a minimum age");
                return;
            }
            if (numPoints.Text == "")
            {
                MessageBox.Show("Please enter a reward");
                return;
            }
            // If the combo box is unassigned, set the childID to an empty string, otherwise set it to the child's ID
            String childID;
            Console.WriteLine(comboAssignedTo.SelectedIndex);
            if (comboAssignedTo.SelectedIndex == 0 || comboAssignedTo.SelectedIndex == -1)
            {
                childID = "";
                new Chore(DataFileHandler.Instance.FindNewId(StorageFiles.Chores), txtChoreName.Text, int.Parse(numPoints.Text), true, int.Parse(numAge.Text), childID, ChoreState.Unclaimed).Save();
                LoadEverything();
            }
            else
            {
                Console.WriteLine("Size of children: " + children.Count);
                Console.WriteLine("Index: " + comboAssignedTo.SelectedIndex);
                childID = children[comboAssignedTo.SelectedIndex - 1].GetId();
                new Chore(DataFileHandler.Instance.FindNewId(StorageFiles.Chores), txtChoreName.Text, int.Parse(numPoints.Text), false, int.Parse(numAge.Text), childID, ChoreState.Claimed).Save();
                LoadEverything();
            }
        }
        
        // Close the form
        void ParentViewChoresPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        private void buttonHome_Click(object sender, EventArgs e)
        {
            Hide();
            new ParentDashboard().ShowDialog();
        }

        private void buttonAccounts_Click(object sender, EventArgs e)
        {
            Hide();
            new ParentViewAccountPage().ShowDialog();
        }

        private void buttonRewards_Click(object sender, EventArgs e)
        {
            Hide();
            new ParentViewRewards().ShowDialog();
        }

        private void buttonDeleteChore_Click(object sender, EventArgs e)
        {
            if (chores.Count == 0)
            {
                MessageBox.Show("No chores to delete");
                return;
            }
            var chore = chores[pointer];
            chore.Delete();
            LoadEverything();
        }

        private void buttonPendingChores_Click(object sender, EventArgs e)
        {
            Hide();
            new ParentViewPendingChores().ShowDialog();
        }
    }
}
