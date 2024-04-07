using ChoppyChores.forms.parent.accounts;
using ChoppyChores.forms.parent.chores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChoppyChores.data;
using ChoppyChores.models;

namespace ChoppyChores.forms.parent.rewards
{
    public partial class ParentViewPendingRewards : Form
    {
        private int pointer;
        private List<PendingReward> _rewards;
        
        public ParentViewPendingRewards()
        {
            InitializeComponent();

            pointer = 0;
            LoadEverything();
        }

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
            lbl_For.Text = _rewards[pointer].GetAssignedTo();
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            Hide();
            new ParentDashboard().ShowDialog();
        }

        private void buttonChores_Click(object sender, EventArgs e)
        {
            Hide();
            new ParentViewChoresPage().ShowDialog();
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

        private void buttonAcceptReward_Click(object sender, EventArgs e)
        {
            var reward = _rewards[pointer];
            reward.Delete();
            MessageBox.Show("Reward accepted");
        }

        private void buttonRefundReward_Click(object sender, EventArgs e)
        {
            var reward = _rewards[pointer];
            var child = DataFileHandler.Instance.GetChildById(reward.GetAssignedTo());
            child.SetPoints(child.GetPoints() + reward.GetCost());
            reward.Delete();
            MessageBox.Show("Reward refunded");
        }
    }
}
