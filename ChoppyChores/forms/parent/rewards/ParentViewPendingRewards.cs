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

namespace ChoppyChores.forms.parent.rewards
{
    public partial class ParentViewPendingRewards : Form
    {
        public ParentViewPendingRewards()
        {
            InitializeComponent();
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

        }
    }
}
