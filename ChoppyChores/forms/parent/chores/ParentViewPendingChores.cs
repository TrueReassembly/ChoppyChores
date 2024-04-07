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
        private int pointer;
        private List<Chore> pendingChores;
        public ParentViewPendingChores()
        {
            InitializeComponent();

            FormClosed += new FormClosedEventHandler(ParentViewPendingChores_FormClosed);
            pointer = 0;
            LoadEverything();
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


        private void buttonChores_Click(object sender, EventArgs e)
        {
            Hide();
            new ParentViewChoresPage().ShowDialog();
        }
        
        private void ParentViewPendingChores_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        
        private void LoadEverything()
        {
            pendingChores = DataFileHandler.Instance.GetPendingChores();
            if (pendingChores.Count == 0)
            {
                lbl_ChoreName.Text = "";
                lbl_AssignedTo.Text = "";
                lbl_Worth.Text = "";
                MessageBox.Show("There are no pending chores");
                return;
            }

            Chore chore = pendingChores[pointer];
            lbl_ChoreName.Text = chore.GetName();
            lbl_AssignedTo.Text = DataFileHandler.Instance.GetChildById(chore.GetClaimedBy()).GetUsername();
            lbl_Worth.Text = chore.GetReward().ToString();
        }

        private void buttonPrevPage_Click(object sender, EventArgs e)
        {
            if (pointer > 0) pointer--;
            else pointer = pendingChores.Count - 1;
            
            LoadEverything();
        }

        private void buttonNextPage_Click(object sender, EventArgs e)
        {
            if (pointer < pendingChores.Count - 1) pointer++;
            else pointer = 0;
            
            LoadEverything();
        }

        private void buttonAcceptChore_Click(object sender, EventArgs e)
        {
            if (pendingChores.Count == 0)
            {
                MessageBox.Show("There are no pending chores to accept");
                return;
            }
            var chore = pendingChores[pointer];
            var child = DataFileHandler.Instance.GetChildById(chore.GetClaimedBy());
            child.SetPoints(child.GetPoints() + chore.GetReward());
            child.Save();
            chore.Delete();
            pointer = 0;
            MessageBox.Show("Chore accepted, points awarded to child");
            LoadEverything();
        }

        private void buttonRejectChore_Click(object sender, EventArgs e)
        {
            if (pendingChores.Count == 0)
            {
                MessageBox.Show("There are no pending chores to reject");
                return;
            }
            var chore = pendingChores[pointer];
            chore.SetStatus(ChoreState.Claimed);
            chore.Save();
            pointer = 0;
            LoadEverything();
        }
    }
}
