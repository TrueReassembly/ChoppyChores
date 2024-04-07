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
using ChoppyChores.forms.child.rewards;
using ChoppyChores.forms.parent.chores;

namespace ChoppyChores.forms.child
{
    public partial class ChildDashboard : Form
    {
        public ChildDashboard()
        {
            InitializeComponent();

            label_name.Text = "Welcome, " + DataFileHandler.Instance.GetLoggedInChild().GetUsername() + "!";
            var chores = DataFileHandler.Instance.GetAllChores();

            int claimedByChild = 0;
            foreach (var chore in chores)
            {
                if (chore.GetClaimedBy() == DataFileHandler.Instance.GetLoggedInChild().GetId())
                {
                    claimedByChild++;
                }
            }
            lbl_ClaimedChores.Text = "You have " + claimedByChild + " chores to complete!";
            lbl_points.Text = "You have " + DataFileHandler.Instance.GetLoggedInChild().GetPoints() + " points!";
        }

        private void btnChores_Click(object sender, EventArgs e)
        {
            Hide();
            new ChildViewChoresPage().ShowDialog();
        }

        private void btnRewards_Click(object sender, EventArgs e)
        {
            Hide();
            new ChildViewRewards().ShowDialog();
        }
    }
}
