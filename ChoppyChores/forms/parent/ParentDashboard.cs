using System;
using System.Windows.Forms;
using ChoppyChores.data;

namespace ChoppyChores.forms.parent
{
    public partial class ParentDashboard : Form
    {
        public ParentDashboard()
        {
            InitializeComponent();

            FormClosed += new FormClosedEventHandler(ParentDashboard_FormClosed);

            lblChoresWaiting.Text = "There are " + DataFileHandler.Instance.GetPendingChores().Count + " chores pending approval";
            lblRewardsPending.Text = "There are " + DataFileHandler.Instance.GetAllPendingRewards().Count + " rewards pending approval";
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            return;
        }

        private void buttonChores_Click(object sender, EventArgs e)
        {
            Hide();
            new chores.ParentViewChoresPage().ShowDialog();
        }

        private void buttonAccounts_Click(object sender, EventArgs e)
        {
            Hide();
            new accounts.ParentViewAccountPage().ShowDialog();
        }

        private void buttonRewards_Click(object sender, EventArgs e)
        {
            Hide();
            new rewards.ParentViewRewards().ShowDialog();
        }
        
        void ParentDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
