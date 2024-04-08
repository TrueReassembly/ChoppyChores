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
using ChoppyChores.forms.parent.accounts;
using ChoppyChores.forms.parent.chores;
using ChoppyChores.models;

namespace ChoppyChores.forms.parent.rewards
{

    
    
    public partial class ParentViewRewards : Form
    {
        int pointer;
        List<Reward> _rewards;
        
        // Constructor for the ParentViewRewards form
        public ParentViewRewards()
        {
            InitializeComponent();
            
            FormClosed += new FormClosedEventHandler(ParentViewRewards_FormClosed);
            _rewards = DataFileHandler.Instance.GetAllRewards();
            pointer = 0;
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
        private void button_ViewPending_Click(object sender, EventArgs e)
        {
            Hide();
            new ParentViewPendingRewards().ShowDialog();
        }

        // Load the reward information
        private void LoadEverything()
        {
            if (_rewards.Count == 0)
            {
                txtRewardName.Text = "";
                numPoints.Text = "";
                MessageBox.Show("Please enter parameters into the empty option boxes then click 'New Reward' to create a new reward");
                return;
            }

            Reward reward = _rewards[pointer];
            txtRewardName.Text = reward.GetName();
            numPoints.Text = reward.GetCost().ToString();
        }
        
        // Go to the previous page
        private void buttonPrevPage_Click(object sender, EventArgs e)
        {
            if (pointer > 0) pointer--;
            else pointer = _rewards.Count - 1;
            
            LoadEverything();
        }
        
        // Load the ParentViewRewards form
        private void ParentViewRewards_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        // Go to the next page
        private void buttonNextPage_Click_1(object sender, EventArgs e)
        {
            if (pointer < _rewards.Count - 1) pointer++;
            else pointer = 0;
            
            LoadEverything();
        }

        // Create a new reward
        private void buttonNewReward_Click(object sender, EventArgs e)
        {
            // Validation for the reward name and cost
            if (txtRewardName.Text == "")
            {
                MessageBox.Show("Please enter a reward name");
                return;
            }
            if (numPoints.Text == "")
            {
                MessageBox.Show("Please enter a cost");
                return;
            }
            new Reward(txtRewardName.Text, int.Parse(numPoints.Text)).Save();
            MessageBox.Show("Reward created");
            _rewards = DataFileHandler.Instance.GetAllRewards();
            pointer = _rewards.Count - 1;
            LoadEverything();
        }

        // Save the reward information
        private void buttonSaveReward_Click(object sender, EventArgs e)
        {
            if (txtRewardName.Text == "")
            {
                MessageBox.Show("Please enter a reward name");
                return;
            }
            if (numPoints.Text == "")
            {
                MessageBox.Show("Please enter a cost");
                return;
            }
            Reward reward = _rewards[pointer];
            reward.SetName(txtRewardName.Text);
            reward.SetCost(int.Parse(numPoints.Text));
            reward.Save();
            MessageBox.Show("Reward saved");
        }
    }
}
