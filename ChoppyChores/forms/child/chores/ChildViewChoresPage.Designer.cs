
namespace ChoppyChores.forms.parent.chores
{
    partial class ChildViewChoresPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChildViewChoresPage));
            this.btnHome = new System.Windows.Forms.Button();
            this.btnChores = new System.Windows.Forms.Button();
            this.btnRewards = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lblChoreName = new System.Windows.Forms.Label();
            this.lblWorth = new System.Windows.Forms.Label();
            this.lblClaimedBy = new System.Windows.Forms.Label();
            this.btnClaim = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnPrevPage = new System.Windows.Forms.Button();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.lblAge = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnHome
            // 
            this.btnHome.Location = new System.Drawing.Point(3, 3);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(265, 51);
            this.btnHome.TabIndex = 0;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = true;
            // 
            // btnChores
            // 
            this.btnChores.Location = new System.Drawing.Point(274, 3);
            this.btnChores.Name = "btnChores";
            this.btnChores.Size = new System.Drawing.Size(259, 51);
            this.btnChores.TabIndex = 1;
            this.btnChores.Text = "Chores";
            this.btnChores.UseVisualStyleBackColor = true;
            // 
            // btnRewards
            // 
            this.btnRewards.Location = new System.Drawing.Point(539, 3);
            this.btnRewards.Name = "btnRewards";
            this.btnRewards.Size = new System.Drawing.Size(249, 51);
            this.btnRewards.TabIndex = 2;
            this.btnRewards.Text = "Rewards";
            this.btnRewards.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(-64, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(1087, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = resources.GetString("label7.Text");
            // 
            // lblChoreName
            // 
            this.lblChoreName.AutoSize = true;
            this.lblChoreName.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChoreName.Location = new System.Drawing.Point(330, 68);
            this.lblChoreName.Name = "lblChoreName";
            this.lblChoreName.Size = new System.Drawing.Size(121, 44);
            this.lblChoreName.TabIndex = 5;
            this.lblChoreName.Text = "label8";
            // 
            // lblWorth
            // 
            this.lblWorth.AutoSize = true;
            this.lblWorth.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorth.Location = new System.Drawing.Point(334, 112);
            this.lblWorth.Name = "lblWorth";
            this.lblWorth.Size = new System.Drawing.Size(130, 24);
            this.lblWorth.TabIndex = 6;
            this.lblWorth.Text = "Worth x points";
            this.lblWorth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblClaimedBy
            // 
            this.lblClaimedBy.AutoSize = true;
            this.lblClaimedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClaimedBy.Location = new System.Drawing.Point(334, 136);
            this.lblClaimedBy.Name = "lblClaimedBy";
            this.lblClaimedBy.Size = new System.Drawing.Size(118, 24);
            this.lblClaimedBy.TabIndex = 7;
            this.lblClaimedBy.Text = "Claimed by y";
            this.lblClaimedBy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClaim
            // 
            this.btnClaim.Location = new System.Drawing.Point(121, 370);
            this.btnClaim.Name = "btnClaim";
            this.btnClaim.Size = new System.Drawing.Size(283, 68);
            this.btnClaim.TabIndex = 8;
            this.btnClaim.Text = "Claim";
            this.btnClaim.UseVisualStyleBackColor = true;
            this.btnClaim.Click += new System.EventHandler(this.btnClaim_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(410, 370);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(269, 68);
            this.btnSubmit.TabIndex = 9;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(352, 160);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(79, 24);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "Status: z";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPrevPage
            // 
            this.btnPrevPage.Location = new System.Drawing.Point(12, 370);
            this.btnPrevPage.Name = "btnPrevPage";
            this.btnPrevPage.Size = new System.Drawing.Size(103, 68);
            this.btnPrevPage.TabIndex = 11;
            this.btnPrevPage.Text = "<---";
            this.btnPrevPage.UseVisualStyleBackColor = true;
            // 
            // btnNextPage
            // 
            this.btnNextPage.Location = new System.Drawing.Point(685, 370);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(103, 68);
            this.btnNextPage.TabIndex = 12;
            this.btnNextPage.Text = "--->";
            this.btnNextPage.UseVisualStyleBackColor = true;
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAge.Location = new System.Drawing.Point(310, 184);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(174, 24);
            this.lblAge.TabIndex = 13;
            this.lblAge.Text = "For children aged s";
            this.lblAge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ChildViewChoresPage
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.btnNextPage);
            this.Controls.Add(this.btnPrevPage);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnClaim);
            this.Controls.Add(this.lblClaimedBy);
            this.Controls.Add(this.lblWorth);
            this.Controls.Add(this.lblChoreName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnRewards);
            this.Controls.Add(this.btnChores);
            this.Controls.Add(this.btnHome);
            this.Name = "ChildViewChoresPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonNextPage;
        private System.Windows.Forms.Button buttonPrevPage;
        private System.Windows.Forms.Button buttonSaveChore;
        private System.Windows.Forms.Button buttonNewChore;
        private System.Windows.Forms.TextBox txtChoreName;
        private System.Windows.Forms.Label button;
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.Button buttonChores;
        private System.Windows.Forms.Button buttonAccounts;
        private System.Windows.Forms.Button buttonRewards;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numPoints;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numAge;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboAssignedTo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblPage;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnChores;
        private System.Windows.Forms.Button btnRewards;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblChoreName;
        private System.Windows.Forms.Label lblWorth;
        private System.Windows.Forms.Label lblClaimedBy;
        private System.Windows.Forms.Button btnClaim;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnPrevPage;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Label lblAge;
    }
}