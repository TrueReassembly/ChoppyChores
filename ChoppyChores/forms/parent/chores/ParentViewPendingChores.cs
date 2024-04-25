using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ChoppyChores.data;
using ChoppyChores.models;

namespace ChoppyChores.forms.parent.chores
{
    public partial class ParentViewPendingChores : Form
    {
        private int pointer;
        private List<Chore> pendingChores;
        public ParentViewPendingChores()
        {
            InitializeComponent();

            FormClosed += new FormClosedEventHandler(ParentViewPendingChores_FormClosed);
            pointer = 0;
            LoadEverything();
        }

        // Go to the Parent dashboard
        private void buttonHome_Click(object sender, EventArgs e)
        {
            Hide();
            new ParentDashboard().ShowDialog();
        }

        // Go to the Parent accounts page
        private void buttonAccounts_Click(object sender, EventArgs e)
        {
            Hide();
            new accounts.ParentViewAccountPage().ShowDialog();
        }

        // Go to the Parent rewards page
        private void buttonRewards_Click(object sender, EventArgs e)
        {
            Hide();
            new rewards.ParentViewRewards().ShowDialog();
        }

        // Go to the Parent chores page
        private void buttonChores_Click(object sender, EventArgs e)
        {
            Hide();
            new ParentViewChoresPage().ShowDialog();
        }
        
        // Close the application
        private void ParentViewPendingChores_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        
        // Load the pending chores information
        private void LoadEverything()
        {
            pendingChores = DataFileHandler.Instance.GetPendingChores();
            if (pendingChores.Count == 0)
            {
                lbl_ChoreName.Text = "";
                lbl_AssignedTo.Text = "";
                lbl_Worth.Text = "";
                MessageBox.Show("There are no pending chores");
                return;
            }

            Chore chore = pendingChores[pointer];
            lbl_ChoreName.Text = chore.GetName();
            lbl_AssignedTo.Text = DataFileHandler.Instance.GetChildById(chore.GetClaimedBy()).GetUsername();
            lbl_Worth.Text = chore.GetReward().ToString();
        }

        // Go to the previous page
        private void buttonPrevPage_Click(object sender, EventArgs e)
        {
            if (pointer > 0) pointer--;
            else pointer = pendingChores.Count - 1;
            
            LoadEverything();
        }

        // Go to the next page
        private void buttonNextPage_Click(object sender, EventArgs e)
        {
            if (pointer < pendingChores.Count - 1) pointer++;
            else pointer = 0;
            
            LoadEverything();
        }

        // Accept the chore
        private void buttonAcceptChore_Click(object sender, EventArgs e)
        {
            if (pendingChores.Count == 0)
            {
                MessageBox.Show("There are no pending chores to accept");
                return;
            }
            var chore = pendingChores[pointer];
            var child = DataFileHandler.Instance.GetChildById(chore.GetClaimedBy());
            var points = child.GetPoints();
            child.SetPoints(points + chore.GetReward());
            child.Save();
            chore.Delete();
            pointer = 0;
            MessageBox.Show("Chore accepted, points awarded to child");
            LoadEverything();
        }

        // Reject the chore
        private void buttonRejectChore_Click(object sender, EventArgs e)
        {
            if (pendingChores.Count == 0)
            {
                MessageBox.Show("There are no pending chores to reject");
                return;
            }
            var chore = pendingChores[pointer];
            chore.SetStatus(ChoreState.Claimed);
            chore.Save();
            pointer = 0;
            LoadEverything();
        }
    }
}
