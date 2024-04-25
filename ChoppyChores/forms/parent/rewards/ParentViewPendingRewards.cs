using ChoppyChores.forms.parent.accounts;
using ChoppyChores.forms.parent.chores;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ChoppyChores.data;
using ChoppyChores.models;

namespace ChoppyChores.forms.parent.rewards
{
    public partial class ParentViewPendingRewards : Form
    {
        private int pointer;
        private List<PendingReward> _rewards;
        
        // Constructor for the ParentViewPendingRewards form
        public ParentViewPendingRewards()
        {
            InitializeComponent();

            pointer = 0;
            LoadEverything();
        }

        // Load the pending reward information
        public void LoadEverything()
        {
            _rewards = DataFileHandler.Instance.GetAllPendingRewards();
            if (_rewards.Count == 0)
            {
                lbl_RewardName.Text = "No Pending Rewards";
                lbl_For.Text = "";
                buttonNextPage.Enabled = false;
                buttonPrevPage.Enabled = false;
                MessageBox.Show("No Pending Rewards");
                return;
            }
            lbl_RewardName.Text = _rewards[pointer].GetName();
            lbl_For.Text = DataFileHandler.Instance.GetChildById(_rewards[pointer].GetAssignedTo()).GetUsername();
        }

        // Go to the Parent dashboard
        private void buttonHome_Click(object sender, EventArgs e)
        {
            Hide();
            new ParentDashboard().ShowDialog();
        }

        // Go to the Parent chores page
        private void buttonChores_Click(object sender, EventArgs e)
        {
            Hide();
            new ParentViewChoresPage().ShowDialog();
        }

        // Go to the Parent accounts page
        private void buttonAccounts_Click(object sender, EventArgs e)
        {
            Hide();
            new ParentViewAccountPage().ShowDialog();
        }

        // Go to the Parent rewards page
        private void buttonRewards_Click(object sender, EventArgs e)
        {
            Hide();
            new ParentViewRewards().ShowDialog();
        }

        // Go to the next page of pending rewards
        private void buttonNextPage_Click(object sender, EventArgs e)
        {
            if (pointer < _rewards.Count - 1)
            {
                pointer++;
                LoadEverything();
            } else
            {
                pointer = 0;
                LoadEverything();
            }
        }

        // Go to the previous page of pending rewards
        private void buttonPrevPage_Click(object sender, EventArgs e)
        {
            if (pointer > 0)
            {
                pointer--;
                LoadEverything();
            } else
            {
                pointer = _rewards.Count - 1;
                LoadEverything();
            }
        }

        // Accept the reward
        private void buttonAcceptReward_Click(object sender, EventArgs e)
        {
            var reward = _rewards[pointer];
            reward.Delete();
            MessageBox.Show("Reward accepted");
        }

        // Refund the reward
        private void buttonRefundReward_Click(object sender, EventArgs e)
        {
            var reward = _rewards[pointer];
            var child = DataFileHandler.Instance.GetChildById(reward.GetAssignedTo());
            var points = child.GetPoints();
            child.SetPoints(points + reward.GetCost());
            child.Save();
            reward.Delete();
            MessageBox.Show("Reward refunded");
        }
    }
}
