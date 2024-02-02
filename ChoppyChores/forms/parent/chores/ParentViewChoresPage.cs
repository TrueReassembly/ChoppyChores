using System;
using ChoppyChores.models;
using ChoppyChores.data;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ChoppyChores.forms.parent.chores
{
    public partial class ParentViewChoresPage : Form
    {

        List<Chore> chores;

        public ParentViewChoresPage()
        {
            chores = DataFileHandler.Instance.GetAllChores();
            if (chores.Count == 0)
            {
                // Open Create Chores popup
            }
            InitializeComponent();
        }

        private void ParentViewChoresPage_Load(object sender, EventArgs e)
        {
            
        }
    }
}
