using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ChoppyChores.data;
using ChoppyChores.forms.parent.chores;
using ChoppyChores.models;

namespace ChoppyChores.forms.child.rewards
{
    public partial class ChildViewRewards : Form
    {
        
        List<Reward> _rewards;
        int pointer;
        
        // Constructor for the ChildViewRewards form
        public ChildViewRewards()
        {
            InitializeComponent();
            FormClosed += new FormClosedEventHandler(ChildViewRewards_FormClosed);
            pointer = 0;
            LoadEverything();
        }

        // Load all the information about the reward, using the reward list and the pointer which represents the index of the reward
        public void LoadEverything()
        {
            _rewards = DataFileHandler.Instance.GetAllRewards();
            if (_rewards.Count == 0)
            {
                lblRewardName.Text = "No rewards available";
                lblCost.Text = "No rewards available";
                btnClaim.Enabled = false;
                btnPrevPageChildChore.Enabled = false;
                btnNextPageChildChore.Enabled = false;
                MessageBox.Show("No rewards available, please check back later");
                return;
            }
            var reward = _rewards[pointer];
            lblRewardName.Text = reward.GetName();
            lblCost.Text = "Costs: " + reward.GetCost() + " points";
            lblRewardPage.Text = (pointer + 1) + "/" + _rewards.Count;
        }

        // Claim the reward, if the child has enough points, the reward will be claimed
        private void btnClaim_Click(object sender, EventArgs e)
        {
            var childPoints = DataFileHandler.Instance.GetLoggedInChild().GetPoints();
            var reward = _rewards[pointer];
            
            if (childPoints < reward.GetCost())
            {
                MessageBox.Show("You do not have enough points to claim this reward");
                return;
            }
            
            DataFileHandler.Instance.GetLoggedInChild().SetPoints(childPoints - reward.GetCost()); // Deduct the points from the child
            new PendingReward(reward.GetName(), reward.GetCost(), DataFileHandler.Instance.GetLoggedInChild().GetId()).Save();
            MessageBox.Show("Reward claimed, please talk to your parent to redeem it");
        }
        
        // Go to the previous reward

        private void btnPrevPageChildChore_Click(object sender, EventArgs e)
        {
            if (pointer == 0)
            {
                pointer = _rewards.Count - 1;
            }
            else pointer--;
            
            LoadEverything();
        }

        // Go to the next reward
        private void btnNextPageChildChore_Click(object sender, EventArgs e)
        {
            if (pointer == _rewards.Count - 1)
            {
                pointer = 0;
            }
            else pointer++;
            
            LoadEverything();
        }

        // Go back to the child dashboard
        private void btnHome_Click(object sender, EventArgs e)
        {
            Hide();
            new ChildDashboard().ShowDialog();
        }

        // Go to the chores page
        private void btnChores_Click(object sender, EventArgs e)
        {
            Hide();
            new ChildViewChoresPage().ShowDialog();
        }
        
        // Close the application when the form is closed
        private void ChildViewRewards_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
