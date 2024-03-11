
namespace ChoppyChores.forms.parent
{
    partial class ParentDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParentDashboard));
            this.label1 = new System.Windows.Forms.Label();
            this.buttonHome = new System.Windows.Forms.Button();
            this.buttonChores = new System.Windows.Forms.Button();
            this.buttonAccounts = new System.Windows.Forms.Button();
            this.buttonRewards = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblChoresWaiting = new System.Windows.Forms.Label();
            this.lblRewardsPending = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(-152, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1591, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // buttonHome
            // 
            this.buttonHome.Location = new System.Drawing.Point(6, 7);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(196, 47);
            this.buttonHome.TabIndex = 7;
            this.buttonHome.Text = "Home";
            this.buttonHome.UseVisualStyleBackColor = true;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // buttonChores
            // 
            this.buttonChores.Location = new System.Drawing.Point(208, 7);
            this.buttonChores.Name = "buttonChores";
            this.buttonChores.Size = new System.Drawing.Size(184, 47);
            this.buttonChores.TabIndex = 8;
            this.buttonChores.Text = "Chores";
            this.buttonChores.UseVisualStyleBackColor = true;
            this.buttonChores.Click += new System.EventHandler(this.buttonChores_Click);
            // 
            // buttonAccounts
            // 
            this.buttonAccounts.Location = new System.Drawing.Point(398, 7);
            this.buttonAccounts.Name = "buttonAccounts";
            this.buttonAccounts.Size = new System.Drawing.Size(196, 47);
            this.buttonAccounts.TabIndex = 9;
            this.buttonAccounts.Text = "Accounts";
            this.buttonAccounts.UseVisualStyleBackColor = true;
            this.buttonAccounts.Click += new System.EventHandler(this.buttonAccounts_Click);
            // 
            // buttonRewards
            // 
            this.buttonRewards.Location = new System.Drawing.Point(600, 7);
            this.buttonRewards.Name = "buttonRewards";
            this.buttonRewards.Size = new System.Drawing.Size(196, 47);
            this.buttonRewards.TabIndex = 10;
            this.buttonRewards.Text = "Rewards";
            this.buttonRewards.UseVisualStyleBackColor = true;
            this.buttonRewards.Click += new System.EventHandler(this.buttonRewards_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(243, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(317, 73);
            this.label2.TabIndex = 11;
            this.label2.Text = "Welcome!";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblChoresWaiting
            // 
            this.lblChoresWaiting.AutoSize = true;
            this.lblChoresWaiting.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChoresWaiting.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblChoresWaiting.Location = new System.Drawing.Point(159, 150);
            this.lblChoresWaiting.Name = "lblChoresWaiting";
            this.lblChoresWaiting.Size = new System.Drawing.Size(482, 29);
            this.lblChoresWaiting.TabIndex = 12;
            this.lblChoresWaiting.Text = "There are x chores waiting for your approval";
            this.lblChoresWaiting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRewardsPending
            // 
            this.lblRewardsPending.AutoSize = true;
            this.lblRewardsPending.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRewardsPending.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblRewardsPending.Location = new System.Drawing.Point(159, 179);
            this.lblRewardsPending.Name = "lblRewardsPending";
            this.lblRewardsPending.Size = new System.Drawing.Size(496, 29);
            this.lblRewardsPending.TabIndex = 13;
            this.lblRewardsPending.Text = "There are x rewards waiting for your approval";
            this.lblRewardsPending.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ParentDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblRewardsPending);
            this.Controls.Add(this.lblChoresWaiting);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonRewards);
            this.Controls.Add(this.buttonAccounts);
            this.Controls.Add(this.buttonChores);
            this.Controls.Add(this.buttonHome);
            this.Controls.Add(this.label1);
            this.Name = "ParentDashboard";
            this.Text = "ParentDashboard";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.Button buttonChores;
        private System.Windows.Forms.Button buttonAccounts;
        private System.Windows.Forms.Button buttonRewards;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblChoresWaiting;
        private System.Windows.Forms.Label lblRewardsPending;
    }
}