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

namespace ChoppyChores.forms.parent.chores
{
    public partial class ParentViewPendingChores : Form
    {
        private List<Chore> pendingChores;
        public ParentViewPendingChores()
        {
            InitializeComponent();
            
            pendingChores = DataFileHandler.Instance.
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            Hide();
            new ParentDashboard().ShowDialog();
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
    }
}
