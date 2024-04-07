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
using ChoppyChores.forms.parent.chores;
using ChoppyChores.models;

namespace ChoppyChores.forms.child.rewards
{
    public partial class ChildViewRewards : Form
    {
        
        List<Reward> _rewards;
        int pointer;
        public ChildViewRewards()
        {
            InitializeComponent();
            FormClosed += new FormClosedEventHandler(ChildViewRewards_FormClosed);
            pointer = 0;
            LoadEverything();
        }

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

        private void btnClaim_Click(object sender, EventArgs e)
        {
            var childPoints = DataFileHandler.Instance.GetLoggedInChild().GetPoints();
            var reward = _rewards[pointer];
            
            if (childPoints < reward.GetCost())
            {
                MessageBox.Show("You do not have enough points to claim this reward");
                return;
            }
            
            DataFileHandler.Instance.GetLoggedInChild().SetPoints(childPoints - reward.GetCost());
            new PendingReward(reward.GetName(), reward.GetCost(), DataFileHandler.Instance.GetLoggedInChild().GetId()).Save();
            MessageBox.Show("Reward claimed, please talk to your parent to redeem it");
        }

        private void btnPrevPageChildChore_Click(object sender, EventArgs e)
        {
            if (pointer == 0)
            {
                pointer = _rewards.Count - 1;
            }
            else pointer--;
            
            LoadEverything();
        }

        private void btnNextPageChildChore_Click(object sender, EventArgs e)
        {
            if (pointer == _rewards.Count - 1)
            {
                pointer = 0;
            }
            else pointer++;
            
            LoadEverything();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Hide();
            new ChildDashboard().ShowDialog();
        }

        private void btnChores_Click(object sender, EventArgs e)
        {
            Hide();
            new ChildViewChoresPage().ShowDialog();
        }
        
        private void ChildViewRewards_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
