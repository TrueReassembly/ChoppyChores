
namespace ChoppyChores.forms.parent.chores
{
    partial class ParentViewChoresPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParentViewChoresPage));
            this.buttonNextPage = new System.Windows.Forms.Button();
            this.buttonPrevPage = new System.Windows.Forms.Button();
            this.buttonSaveChore = new System.Windows.Forms.Button();
            this.buttonNewChore = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button = new System.Windows.Forms.Label();
            this.buttonHome = new System.Windows.Forms.Button();
            this.buttonChores = new System.Windows.Forms.Button();
            this.buttonAccounts = new System.Windows.Forms.Button();
            this.buttonRewards = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonNextPage
            // 
            this.buttonNextPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNextPage.Location = new System.Drawing.Point(675, 364);
            this.buttonNextPage.Name = "buttonNextPage";
            this.buttonNextPage.Size = new System.Drawing.Size(113, 74);
            this.buttonNextPage.TabIndex = 0;
            this.buttonNextPage.Text = "-->";
            this.buttonNextPage.UseVisualStyleBackColor = true;
            // 
            // buttonPrevPage
            // 
            this.buttonPrevPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPrevPage.Location = new System.Drawing.Point(12, 364);
            this.buttonPrevPage.Name = "buttonPrevPage";
            this.buttonPrevPage.Size = new System.Drawing.Size(113, 74);
            this.buttonPrevPage.TabIndex = 1;
            this.buttonPrevPage.Text = "<--";
            this.buttonPrevPage.UseVisualStyleBackColor = true;
            // 
            // buttonSaveChore
            // 
            this.buttonSaveChore.Location = new System.Drawing.Point(400, 364);
            this.buttonSaveChore.Name = "buttonSaveChore";
            this.buttonSaveChore.Size = new System.Drawing.Size(273, 74);
            this.buttonSaveChore.TabIndex = 2;
            this.buttonSaveChore.Text = "Save Chore";
            this.buttonSaveChore.UseVisualStyleBackColor = true;
            // 
            // buttonNewChore
            // 
            this.buttonNewChore.Location = new System.Drawing.Point(127, 364);
            this.buttonNewChore.Name = "buttonNewChore";
            this.buttonNewChore.Size = new System.Drawing.Size(273, 74);
            this.buttonNewChore.TabIndex = 3;
            this.buttonNewChore.Text = "New Chore";
            this.buttonNewChore.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(271, 60);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(251, 20);
            this.textBox1.TabIndex = 4;
            // 
            // button
            // 
            this.button.AutoSize = true;
            this.button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button.Location = new System.Drawing.Point(-85, 44);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(2287, 13);
            this.button.TabIndex = 5;
            this.button.Text = resources.GetString("button.Text");
            // 
            // buttonHome
            // 
            this.buttonHome.Location = new System.Drawing.Point(2, 2);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(196, 47);
            this.buttonHome.TabIndex = 6;
            this.buttonHome.Text = "Home";
            this.buttonHome.UseVisualStyleBackColor = true;
            // 
            // buttonChores
            // 
            this.buttonChores.Location = new System.Drawing.Point(204, 2);
            this.buttonChores.Name = "buttonChores";
            this.buttonChores.Size = new System.Drawing.Size(184, 47);
            this.buttonChores.TabIndex = 7;
            this.buttonChores.Text = "Chores";
            this.buttonChores.UseVisualStyleBackColor = true;
            // 
            // buttonAccounts
            // 
            this.buttonAccounts.Location = new System.Drawing.Point(394, 2);
            this.buttonAccounts.Name = "buttonAccounts";
            this.buttonAccounts.Size = new System.Drawing.Size(196, 47);
            this.buttonAccounts.TabIndex = 8;
            this.buttonAccounts.Text = "Accounts";
            this.buttonAccounts.UseVisualStyleBackColor = true;
            // 
            // buttonRewards
            // 
            this.buttonRewards.Location = new System.Drawing.Point(596, 2);
            this.buttonRewards.Name = "buttonRewards";
            this.buttonRewards.Size = new System.Drawing.Size(196, 47);
            this.buttonRewards.TabIndex = 9;
            this.buttonRewards.Text = "Rewards";
            this.buttonRewards.UseVisualStyleBackColor = true;
            // 
            // ParentViewChoresPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonRewards);
            this.Controls.Add(this.buttonAccounts);
            this.Controls.Add(this.buttonChores);
            this.Controls.Add(this.buttonHome);
            this.Controls.Add(this.button);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonNewChore);
            this.Controls.Add(this.buttonSaveChore);
            this.Controls.Add(this.buttonPrevPage);
            this.Controls.Add(this.buttonNextPage);
            this.Name = "ParentViewChoresPage";
            this.Text = "ParentViewChoresPage";
            this.Load += new System.EventHandler(this.ParentViewChoresPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonNextPage;
        private System.Windows.Forms.Button buttonPrevPage;
        private System.Windows.Forms.Button buttonSaveChore;
        private System.Windows.Forms.Button buttonNewChore;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label button;
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.Button buttonChores;
        private System.Windows.Forms.Button buttonAccounts;
        private System.Windows.Forms.Button buttonRewards;
    }
}