using System;
using System.Windows.Forms;
using ChoppyChores.data;

namespace ChoppyChores.forms.parent
{
    public partial class ParentDashboard : Form
    {
        // Constructor for the ParentDashboard form
        public ParentDashboard()
        {
            InitializeComponent();

            FormClosed += new FormClosedEventHandler(ParentDashboard_FormClosed);

            lblChoresWaiting.Text = "There are " + DataFileHandler.Instance.GetPendingChores().Count + " chores pending approval";
            lblRewardsPending.Text = "There are " + DataFileHandler.Instance.GetAllPendingRewards().Count + " rewards pending approval";
        }

        // Go to the Parent dashboard
        private void buttonHome_Click(object sender, EventArgs e)
        {
            return;
        }

        // Go to the Parent chores page
        private void buttonChores_Click(object sender, EventArgs e)
        {
            Hide();
            new chores.ParentViewChoresPage().ShowDialog();
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
        
        // Close the application
        void ParentDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}