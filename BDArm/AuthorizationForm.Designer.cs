namespace BDArm
{
    partial class AuthorizationForm
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
            this.LogTextBox = new System.Windows.Forms.TextBox();
            this.PassTextBox = new System.Windows.Forms.TextBox();
            this.LoginLabel = new System.Windows.Forms.Label();
            this.PassLabel = new System.Windows.Forms.Label();
            this.LogButton = new System.Windows.Forms.Button();
            this.SwitchLinkLabel = new System.Windows.Forms.LinkLabel();
            this.RePassTextBox = new System.Windows.Forms.TextBox();
            this.RePassLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LogTextBox
            // 
            this.LogTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LogTextBox.Location = new System.Drawing.Point(12, 55);
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.Size = new System.Drawing.Size(343, 31);
            this.LogTextBox.TabIndex = 0;
            // 
            // PassTextBox
            // 
            this.PassTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PassTextBox.Location = new System.Drawing.Point(12, 131);
            this.PassTextBox.Name = "PassTextBox";
            this.PassTextBox.Size = new System.Drawing.Size(343, 31);
            this.PassTextBox.TabIndex = 1;
            // 
            // LoginLabel
            // 
            this.LoginLabel.AutoSize = true;
            this.LoginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoginLabel.Location = new System.Drawing.Point(13, 27);
            this.LoginLabel.Name = "LoginLabel";
            this.LoginLabel.Size = new System.Drawing.Size(65, 25);
            this.LoginLabel.TabIndex = 2;
            this.LoginLabel.Text = "Login";
            // 
            // PassLabel
            // 
            this.PassLabel.AutoSize = true;
            this.PassLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PassLabel.Location = new System.Drawing.Point(12, 103);
            this.PassLabel.Name = "PassLabel";
            this.PassLabel.Size = new System.Drawing.Size(106, 25);
            this.PassLabel.TabIndex = 3;
            this.PassLabel.Text = "Password";
            // 
            // LogButton
            // 
            this.LogButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LogButton.Location = new System.Drawing.Point(111, 196);
            this.LogButton.Name = "LogButton";
            this.LogButton.Size = new System.Drawing.Size(150, 45);
            this.LogButton.TabIndex = 4;
            this.LogButton.Text = "Login";
            this.LogButton.UseVisualStyleBackColor = true;
            this.LogButton.Click += new System.EventHandler(this.LogButton_Click);
            // 
            // SwitchLinkLabel
            // 
            this.SwitchLinkLabel.AutoSize = true;
            this.SwitchLinkLabel.Location = new System.Drawing.Point(97, 333);
            this.SwitchLinkLabel.Name = "SwitchLinkLabel";
            this.SwitchLinkLabel.Size = new System.Drawing.Size(173, 13);
            this.SwitchLinkLabel.TabIndex = 5;
            this.SwitchLinkLabel.TabStop = true;
            this.SwitchLinkLabel.Text = "Нет профиля? Зарегистрируйся!";
            this.SwitchLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SwitchLinkLabel_LinkClicked);
            // 
            // RePassTextBox
            // 
            this.RePassTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RePassTextBox.Location = new System.Drawing.Point(12, 212);
            this.RePassTextBox.Name = "RePassTextBox";
            this.RePassTextBox.Size = new System.Drawing.Size(343, 31);
            this.RePassTextBox.TabIndex = 6;
            this.RePassTextBox.Visible = false;
            // 
            // RePassLabel
            // 
            this.RePassLabel.AutoSize = true;
            this.RePassLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RePassLabel.Location = new System.Drawing.Point(13, 184);
            this.RePassLabel.Name = "RePassLabel";
            this.RePassLabel.Size = new System.Drawing.Size(179, 25);
            this.RePassLabel.TabIndex = 7;
            this.RePassLabel.Text = "Repeat password";
            this.RePassLabel.Visible = false;
            // 
            // AuthorizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 355);
            this.Controls.Add(this.SwitchLinkLabel);
            this.Controls.Add(this.LogButton);
            this.Controls.Add(this.PassLabel);
            this.Controls.Add(this.LoginLabel);
            this.Controls.Add(this.PassTextBox);
            this.Controls.Add(this.LogTextBox);
            this.Controls.Add(this.RePassTextBox);
            this.Controls.Add(this.RePassLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AuthorizationForm";
            this.Text = "AuthorizationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox LogTextBox;
        private System.Windows.Forms.TextBox PassTextBox;
        private System.Windows.Forms.Label LoginLabel;
        private System.Windows.Forms.Label PassLabel;
        private System.Windows.Forms.Button LogButton;
        private System.Windows.Forms.LinkLabel SwitchLinkLabel;
        private System.Windows.Forms.TextBox RePassTextBox;
        private System.Windows.Forms.Label RePassLabel;
    }
}