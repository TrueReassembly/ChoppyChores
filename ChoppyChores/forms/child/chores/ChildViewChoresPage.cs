using System;
using ChoppyChores.models;
using ChoppyChores.data;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ChoppyChores.forms.parent.chores
{
    public partial class ChildViewChoresPage : Form
    {

        List<Chore> chores;
        int pointer;

        public ChildViewChoresPage()
        {
            pointer = 0;
           
            
            InitializeComponent();
            chores = DataFileHandler.Instance.GetAllChores();
            Console.WriteLine(chores.Count);
            LoadEverything();
        }

        public void LoadEverything()
        {
            if (chores.Count == 0)
            {
                lblChoreName.Text = "Unavailable";
                lblWorth.Text = "Unavailable";
                lblClaimedBy.Text = "Unavailable";
                lblStatus.Text = "Unavailable";
                lblAge.Text = "Unavailable";
                MessageBox.Show("There are no chores. Come back later!");
                //TODO: Switch back to the old one
                return;
            }

            Chore chore = chores[pointer];
            lblChoreName.Text = chore.GetName();
            lblWorth.Text = "Worth " + chore.GetReward() + " Points";
            lblAge.Text = "For children aged at least  " + chore.GetMinAge() + " years old";
            lblChildChorePage.Text = (pointer + 1) + " / " + chores.Count;

            btnClaim.Enabled = false;
            btnSubmit.Enabled = false;

            
            if (chore.GetClaimedBy() != DataFileHandler.Instance.GetLoggedInChild().GetId() && chore.GetStatus() == ChoreState.Claimed)
            {
                lblClaimedBy.Text = "Claimed by: " + DataFileHandler.Instance.GetChildById(chore.GetClaimedBy()).GetUsername();
            }
            else if (chore.GetClaimedBy() == DataFileHandler.Instance.GetLoggedInChild().GetId())
            {
                lblClaimedBy.Text = "Claimed by: You";
                btnSubmit.Enabled = true;
            } else
            {
                lblClaimedBy.Text = "Claimed by: Noone";
                btnClaim.Enabled = true;
            }

            switch (chore.GetStatus())
            {
                case ChoreState.Unclaimed:
                    lblStatus.Text = "Status: Unclaimed";
                    break;
                case ChoreState.Claimed:
                    lblStatus.Text = "Status: Claimed";
                    break;
                case ChoreState.Pending:
                    lblStatus.Text = "Status: Pending Review";
                    btnSubmit.Enabled = false;
                    break;
            }
        }

        private void ChildViewChoresPage_Load(object sender, EventArgs e)
        {
            LoadEverything();
        }

        private void btnNextPageChildChore_Click_1(object sender, EventArgs e)
        {
            Console.WriteLine("CALL");
            if (pointer == chores.Count - 1)
            {
                pointer = 0;
            }
            else pointer++;

            LoadEverything();
            
        }

        private void btnPrevPageChildChore_Click_1(object sender, EventArgs e)
        {
            Console.WriteLine("CALL");
            if (pointer == 0)
            {
                pointer = chores.Count - 1;
            }
            else pointer--;

            LoadEverything();
        }

        private void btnClaim_Click(object sender, EventArgs e)
        {
            var chore = chores[pointer];
            chore.SetClaimedBy(DataFileHandler.Instance.GetLoggedInChild().GetId());
            chore.SetStatus(ChoreState.Claimed);
            chore.Save();
            MessageBox.Show("Chore claimed!");
            LoadEverything();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var chore = chores[pointer];
            chore.SetStatus(ChoreState.Pending);
            chore.Save();
            MessageBox.Show("Chore submitted for review!");
            LoadEverything();
        }
    }
}
