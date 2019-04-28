namespace BDArm
{
    partial class AddEditFrom
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
            this.CompleteButton = new System.Windows.Forms.Button();
            this.EditTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // CompleteButton
            // 
            this.CompleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CompleteButton.Location = new System.Drawing.Point(98, 81);
            this.CompleteButton.Name = "CompleteButton";
            this.CompleteButton.Size = new System.Drawing.Size(141, 41);
            this.CompleteButton.TabIndex = 3;
            this.CompleteButton.Text = "Приминить";
            this.CompleteButton.UseVisualStyleBackColor = true;
            this.CompleteButton.Click += new System.EventHandler(this.CompleteButton_Click);
            // 
            // EditTextBox
            // 
            this.EditTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EditTextBox.Location = new System.Drawing.Point(12, 31);
            this.EditTextBox.Name = "EditTextBox";
            this.EditTextBox.Size = new System.Drawing.Size(315, 38);
            this.EditTextBox.TabIndex = 2;
            // 
            // AddEditFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 134);
            this.Controls.Add(this.CompleteButton);
            this.Controls.Add(this.EditTextBox);
            this.Name = "AddEditFrom";
            this.Text = "AddEditFrom";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CompleteButton;
        private System.Windows.Forms.TextBox EditTextBox;
    }
}