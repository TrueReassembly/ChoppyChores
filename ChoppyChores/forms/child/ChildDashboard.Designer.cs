
namespace ChoppyChores.forms.child
{
    partial class ChildDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChildDashboard));
            this.btnRewards = new System.Windows.Forms.Button();
            this.btnChores = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label_name = new System.Windows.Forms.Label();
            this.lbl_ClaimedChores = new System.Windows.Forms.Label();
            this.lbl_points = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRewards
            // 
            this.btnRewards.Location = new System.Drawing.Point(541, 5);
            this.btnRewards.Name = "btnRewards";
            this.btnRewards.Size = new System.Drawing.Size(249, 51);
            this.btnRewards.TabIndex = 5;
            this.btnRewards.Text = "Rewards";
            this.btnRewards.UseVisualStyleBackColor = true;
            this.btnRewards.Click += new System.EventHandler(this.btnRewards_Click);
            // 
            // btnChores
            // 
            this.btnChores.Location = new System.Drawing.Point(276, 5);
            this.btnChores.Name = "btnChores";
            this.btnChores.Size = new System.Drawing.Size(259, 51);
            this.btnChores.TabIndex = 4;
            this.btnChores.Text = "Chores";
            this.btnChores.UseVisualStyleBackColor = true;
            this.btnChores.Click += new System.EventHandler(this.btnChores_Click);
            // 
            // btnHome
            // 
            this.btnHome.Location = new System.Drawing.Point(5, 5);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(265, 51);
            this.btnHome.TabIndex = 3;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(-295, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(1447, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = resources.GetString("label7.Text");
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_name.Location = new System.Drawing.Point(269, 69);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(242, 37);
            this.label_name.TabIndex = 7;
            this.label_name.Text = "Welcome, Alan!";
            this.label_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_ClaimedChores
            // 
            this.lbl_ClaimedChores.AutoSize = true;
            this.lbl_ClaimedChores.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ClaimedChores.Location = new System.Drawing.Point(163, 106);
            this.lbl_ClaimedChores.Name = "lbl_ClaimedChores";
            this.lbl_ClaimedChores.Size = new System.Drawing.Size(521, 37);
            this.lbl_ClaimedChores.TabIndex = 8;
            this.lbl_ClaimedChores.Text = "You have got 3 chores to complete!";
            this.lbl_ClaimedChores.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_points
            // 
            this.lbl_points.AutoSize = true;
            this.lbl_points.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_points.Location = new System.Drawing.Point(163, 143);
            this.lbl_points.Name = "lbl_points";
            this.lbl_points.Size = new System.Drawing.Size(355, 37);
            this.lbl_points.TabIndex = 9;
            this.lbl_points.Text = "You have got 30 points!";
            this.lbl_points.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ChildDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbl_points);
            this.Controls.Add(this.lbl_ClaimedChores);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnRewards);
            this.Controls.Add(this.btnChores);
            this.Controls.Add(this.btnHome);
            this.Name = "ChildDashboard";
            this.Text = "ChildDashboard";
            this.Load += new System.EventHandler(this.ChildDashboard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lbl_points;

        #endregion

        private System.Windows.Forms.Button btnRewards;
        private System.Windows.Forms.Button btnChores;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Label lbl_ClaimedChores;
    }
}