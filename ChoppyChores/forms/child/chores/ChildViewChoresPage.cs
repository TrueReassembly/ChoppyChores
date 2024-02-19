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
        List<Child> children;
        int pointer;

        public ChildViewChoresPage()
        {
            pointer = 0;
            children = DataFileHandler.Instance.GetChildrenSortedByName();
            
            InitializeComponent();
        }

        public void LoadEverything()
        {
            chores = DataFileHandler.Instance.GetAllChores();
            if (chores.Count == 0)
            {
                txtChoreName.Text = "";
                numAge.Text = "";
                numPoints.Text = "";
                lblPage.Text = "0/0";
                MessageBox.Show("Please enter parameters into the empty option boxes then click 'New Chore' to create a new chore");
                return;
            }

            Chore chore = chores[pointer];
            txtChoreName.Text = chore.GetName();
            var child = DataFileHandler.Instance.GetChildFromName(chore.GetClaimedBy().ToString());
            if (child != null)
            {
                comboAssignedTo.SelectedIndex = children.IndexOf(child);
            }
            else
                comboAssignedTo.SelectedIndex = 0;
            numAge.Text = chore.GetMinAge().ToString();
            numPoints.Text = chore.GetReward().ToString();
            lblPage.Text = (pointer + 1) + " / " + chores.Count;
            foreach (var theChild in children)
            {
                comboAssignedTo.Items.Add(theChild.GetUsername());
            }
        }

        private void ParentViewChoresPage_Load(object sender, EventArgs e)
        {
            LoadEverything();
        }

        private void buttonSaveChore_Click(object sender, EventArgs e)
        {

            if (chores.Count == 0)
            {
                MessageBox.Show("Please use the 'New Chore' button to create the new chore");
                return;
            }

            if (txtChoreName.Text == "")
            {
                MessageBox.Show("Please enter a chore name");
                return;
            }
            if (numAge.Text == "")
            {
                MessageBox.Show("Please enter a minimum age");
                return;
            }
            if (numPoints.Text == "")
            {
                MessageBox.Show("Please enter a reward");
                return;
            }
            Chore chore = chores[pointer];
            chore.SetName(txtChoreName.Text);
            chore.SetReward(int.Parse(numPoints.Text));
            chore.SetMinAge(int.Parse(numAge.Text));
            if (comboAssignedTo.SelectedIndex == 0)
            {
                chore.SetClaimedBy("-1");
            }
            else
            {
                chore.SetClaimedBy(children[comboAssignedTo.SelectedIndex - 1].GetId());
            }
            chore.Save();
            MessageBox.Show("Chore Information Saved!");
        }

        private void buttonNextPage_Click(object sender, EventArgs e)
        {
            if (pointer == chores.Count - 1)
            {
                pointer = 0;
            }
            else pointer++;

            txtChoreName.Text = chores[pointer].GetName();
            var child = DataFileHandler.Instance.GetChildById(chores[pointer].GetClaimedBy());
            if (child != null)
            {
                comboAssignedTo.SelectedIndex = children.IndexOf(child);
            }
            else
                comboAssignedTo.SelectedIndex = 0;
            numAge.Text = chores[pointer].GetMinAge().ToString();
            numPoints.Text = chores[pointer].GetReward().ToString();
            lblPage.Text = (pointer + 1) + " / " + chores.Count;
        }

        private void buttonPrevPage_Click(object sender, EventArgs e)
        {
            if (pointer == 0)
            {
                pointer = chores.Count - 1;
            }
            else pointer--;

            txtChoreName.Text = chores[pointer].GetName();
            var child = DataFileHandler.Instance.GetChildFromName(chores[pointer].GetClaimedBy());
            if (child != null)
            {
                comboAssignedTo.SelectedIndex = children.IndexOf(child);
            }
            else
                comboAssignedTo.SelectedIndex = 0;
            numAge.Text = chores[pointer].GetMinAge().ToString();
            numPoints.Text = chores[pointer].GetReward().ToString();
            lblPage.Text = (pointer + 1) + " / " + chores.Count;
        }

        private void buttonNewChore_Click(object sender, EventArgs e)
        {

            if (txtChoreName.Text == "")
            {
                MessageBox.Show("Please enter a chore name");
                return;
            }
            if (numAge.Text == "")
            {
                MessageBox.Show("Please enter a minimum age");
                return;
            }
            if (numPoints.Text == "")
            {
                MessageBox.Show("Please enter a reward");
                return;
            }
            String childID;
            Console.WriteLine(comboAssignedTo.SelectedIndex);
            if (comboAssignedTo.SelectedIndex == -1)
            {
                childID = "-1";
                new Chore(DataFileHandler.Instance.FindNewId(StorageFiles.Chores), txtChoreName.Text, int.Parse(numPoints.Text), true, int.Parse(numAge.Text), childID, ChoreState.Unclaimed).Save();
                LoadEverything();
            }
            else
            {
                childID = children[comboAssignedTo.SelectedIndex + 1].GetId();
                new Chore(DataFileHandler.Instance.FindNewId(StorageFiles.Chores), txtChoreName.Text, int.Parse(numPoints.Text), false, int.Parse(numAge.Text), childID, ChoreState.Claimed).Save();
                LoadEverything();
            }
        }
    }
}
