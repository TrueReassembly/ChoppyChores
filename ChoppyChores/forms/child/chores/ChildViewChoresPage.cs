using System;
using ChoppyChores.models;
using ChoppyChores.data;
using System.Windows.Forms;
using System.Collections.Generic;
using ChoppyChores.forms.child;
using ChoppyChores.forms.child.rewards;

namespace ChoppyChores.forms.parent.chores
{
    public partial class ChildViewChoresPage : Form
    {
        
        // List of chores and the pointer to the current chore, global scope so that it can be accessed by all methods
        List<Chore> chores;
        int pointer;

        public ChildViewChoresPage()
        {
            pointer = 0;
           
            
            InitializeComponent();
            chores = DataFileHandler.Instance.GetAllChores();
            Console.WriteLine(chores.Count);
            LoadEverything();
        }

        /**
         * Load all the information about the chore, using the chore list and the pointer which represents the index of the chore
         */
        public void LoadEverything()
        {
            if (chores.Count == 0)
            {
                lblChoreName.Text = "Unavailable";
                lblWorth.Text = "Unavailable";
                lblClaimedBy.Text = "Unavailable";
                lblStatus.Text = "Unavailable";
                lblAge.Text = "Unavailable";
                MessageBox.Show("There are no chores. Come back later!");
                //TODO: Switch back to the old one
                return;
            }

            Chore chore = chores[pointer];
            lblChoreName.Text = chore.GetName();
            lblWorth.Text = "Worth " + chore.GetReward() + " Points";
            lblAge.Text = "For children aged at least " + chore.GetMinAge() + " years old";
            lblChildChorePage.Text = (pointer + 1) + " / " + chores.Count;

            //Disable both of the buttons by default, and enable them based on the status of the chore below
            btnClaim.Enabled = false;
            btnSubmit.Enabled = false;

            // If the chore is claimed by someone else, show the name of the person who claimed it
            if (chore.GetClaimedBy() != DataFileHandler.Instance.GetLoggedInChild().GetId() && chore.GetStatus() == ChoreState.Claimed)
            {
                lblClaimedBy.Text = "Claimed by: " + DataFileHandler.Instance.GetChildById(chore.GetClaimedBy()).GetUsername().ToString();
            }
            // If the chore is claimed by the logged in child, show that it is claimed by the child and enable the submit button for them to submit their chore for review
            else if (chore.GetClaimedBy() == DataFileHandler.Instance.GetLoggedInChild().GetId())
            {
                lblClaimedBy.Text = "Claimed by: You";
                btnSubmit.Enabled = true;
            } 
            // Otherwise, show that it is unclaimed and enable the claim button
            else
            {
                lblClaimedBy.Text = "Claimed by: Noone";
                btnClaim.Enabled = true;
            }

            // Set the status of the chore
            switch (chore.GetStatus())
            {
                case ChoreState.Unclaimed:
                    lblStatus.Text = "Status: Unclaimed";
                    break;
                case ChoreState.Claimed:
                    lblStatus.Text = "Status: Claimed";
                    break;
                case ChoreState.Pending:
                    lblStatus.Text = "Status: Pending Review";
                    btnSubmit.Enabled = false;
                    break;
            }
        }

        // When the page loads, load all the information
        private void ChildViewChoresPage_Load(object sender, EventArgs e)
        {
            LoadEverything();
        }

        // When the next page button is clicked, increment the pointer and load the information of the next chore
        private void btnNextPageChildChore_Click_1(object sender, EventArgs e)
        {
            if (pointer == chores.Count - 1)
            {
                pointer = 0;
            }
            else pointer++;

            LoadEverything();
            
        }

        // When the previous page button is clicked, decrement the pointer and load the information of the previous chore
        private void btnPrevPageChildChore_Click_1(object sender, EventArgs e)
        {
            if (pointer == 0)
            {
                pointer = chores.Count - 1;
            }
            else pointer--;

            LoadEverything();
        }

        // When the claim button is clicked, give the chore to the logged in child and set the status to claimed and reload the information
        private void btnClaim_Click(object sender, EventArgs e)
        {
            var chore = chores[pointer];
            chore.SetClaimedBy(DataFileHandler.Instance.GetLoggedInChild().GetId());
            chore.SetStatus(ChoreState.Claimed);
            chore.Save();
            MessageBox.Show("Chore claimed!");
            LoadEverything();
        }

        // When the submit button is clicked, set the status of the chore to pending review and reload the information
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var chore = chores[pointer];
            chore.SetStatus(ChoreState.Pending);
            chore.Save();
            MessageBox.Show("Chore submitted for review!");
            LoadEverything();
        }

        // When the home button is clicked, go back to the child dashboard
        private void btnHome_Click(object sender, EventArgs e)
        {
            Hide();
            new ChildDashboard().ShowDialog();
        }

        // When the rewards button is clicked, go to the rewards page
        private void btnRewards_Click(object sender, EventArgs e)
        {
            Hide();
            new ChildViewRewards().ShowDialog();
        }
    }
}
