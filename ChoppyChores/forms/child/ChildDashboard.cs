using System;
using System.Windows.Forms;
using ChoppyChores.data;
using ChoppyChores.forms.child.rewards;
using ChoppyChores.forms.parent.chores;

namespace ChoppyChores.forms.child
{
    public partial class ChildDashboard : Form
    {
        // Constructor for the ChildDashboard form
        public ChildDashboard()
        {
            InitializeComponent();

            label_name.Text = "Welcome, " + DataFileHandler.Instance.GetLoggedInChild().GetUsername() + "!";
            var chores = DataFileHandler.Instance.GetAllChores();

            int claimedByChild = 0; // Counter for the number of chores claimed by the child
            foreach (var chore in chores)
            {
                // If the chore is claimed by the child, increment the counter
                if (chore.GetClaimedBy() == DataFileHandler.Instance.GetLoggedInChild().GetId())
                {
                    claimedByChild++;
                }
            }
            // Display the number of chores claimed by the child
            lbl_ClaimedChores.Text = "You have " + claimedByChild + " chores to complete!";
            lbl_points.Text = "You have " + DataFileHandler.Instance.GetLoggedInChild().GetPoints() + " points!";
            FormClosed += new FormClosedEventHandler(ChildDashboard_FormClosed);
        }

        // Go to the Child chores page
        private void btnChores_Click(object sender, EventArgs e)
        {
            Hide();
            new ChildViewChoresPage().ShowDialog();
        }

        // Go to the Child rewards page
        private void btnRewards_Click(object sender, EventArgs e)
        {
            Hide();
            new ChildViewRewards().ShowDialog();
        }

        private void ChildDashboard_Load(object sender, EventArgs e)
        {

        }
        
        private void ChildDashboard_FormClosed(object sender, EventArgs e)
        {
            Application.Exit(); 
        }
    }
}
