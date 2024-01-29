using System.ComponentModel;

namespace ChoppyChores.forms.parent.chores
{
    partial class ParentCreateChore
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.txtChoreName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtChoreName
            // 
            this.txtChoreName.Location = new System.Drawing.Point(72, 40);
            this.txtChoreName.Name = "txtChoreName";
            this.txtChoreName.Size = new System.Drawing.Size(337, 20);
            this.txtChoreName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(160, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chore Name";
            // 
            // ParentCreateChore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(492, 719);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtChoreName);
            this.Name = "ParentCreateChore";
            this.Text = "Create New Chore";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.TextBox txtChoreName;

        #endregion
    }
}