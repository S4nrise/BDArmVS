namespace BDArm
{
    partial class ProductForm
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
            this.AddMakerLabel = new System.Windows.Forms.Label();
            this.AddModelLabel = new System.Windows.Forms.Label();
            this.AddCategoryLabel = new System.Windows.Forms.Label();
            this.AddSalesLabel = new System.Windows.Forms.Label();
            this.AddCountLabel = new System.Windows.Forms.Label();
            this.PriceNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.SalesNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.MakerComboBox = new System.Windows.Forms.ComboBox();
            this.ModelComboBox = new System.Windows.Forms.ComboBox();
            this.CategoryСomboBox = new System.Windows.Forms.ComboBox();
            this.AddPriceLabel = new System.Windows.Forms.Label();
            this.CountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AddButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PriceNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CountNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // AddMakerLabel
            // 
            this.AddMakerLabel.AutoSize = true;
            this.AddMakerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.AddMakerLabel.Location = new System.Drawing.Point(15, 79);
            this.AddMakerLabel.Name = "AddMakerLabel";
            this.AddMakerLabel.Size = new System.Drawing.Size(110, 17);
            this.AddMakerLabel.TabIndex = 0;
            this.AddMakerLabel.Text = "Производитель";
            // 
            // AddModelLabel
            // 
            this.AddModelLabel.AutoSize = true;
            this.AddModelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.AddModelLabel.Location = new System.Drawing.Point(15, 112);
            this.AddModelLabel.Name = "AddModelLabel";
            this.AddModelLabel.Size = new System.Drawing.Size(58, 17);
            this.AddModelLabel.TabIndex = 1;
            this.AddModelLabel.Text = "Модель";
            // 
            // AddCategoryLabel
            // 
            this.AddCategoryLabel.AutoSize = true;
            this.AddCategoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.AddCategoryLabel.Location = new System.Drawing.Point(15, 143);
            this.AddCategoryLabel.Name = "AddCategoryLabel";
            this.AddCategoryLabel.Size = new System.Drawing.Size(77, 17);
            this.AddCategoryLabel.TabIndex = 2;
            this.AddCategoryLabel.Text = "Категория";
            // 
            // AddSalesLabel
            // 
            this.AddSalesLabel.AutoSize = true;
            this.AddSalesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.AddSalesLabel.Location = new System.Drawing.Point(15, 173);
            this.AddSalesLabel.Name = "AddSalesLabel";
            this.AddSalesLabel.Size = new System.Drawing.Size(214, 17);
            this.AddSalesLabel.TabIndex = 3;
            this.AddSalesLabel.Text = "Колличество проданых едениц";
            // 
            // AddCountLabel
            // 
            this.AddCountLabel.AutoSize = true;
            this.AddCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.AddCountLabel.Location = new System.Drawing.Point(15, 239);
            this.AddCountLabel.Name = "AddCountLabel";
            this.AddCountLabel.Size = new System.Drawing.Size(97, 17);
            this.AddCountLabel.TabIndex = 4;
            this.AddCountLabel.Text = "Всего едениц";
            // 
            // PriceNumericUpDown
            // 
            this.PriceNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.PriceNumericUpDown.Location = new System.Drawing.Point(234, 204);
            this.PriceNumericUpDown.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.PriceNumericUpDown.Name = "PriceNumericUpDown";
            this.PriceNumericUpDown.Size = new System.Drawing.Size(90, 23);
            this.PriceNumericUpDown.TabIndex = 6;
            // 
            // SalesNumericUpDown
            // 
            this.SalesNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.SalesNumericUpDown.Location = new System.Drawing.Point(234, 171);
            this.SalesNumericUpDown.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.SalesNumericUpDown.Name = "SalesNumericUpDown";
            this.SalesNumericUpDown.Size = new System.Drawing.Size(90, 23);
            this.SalesNumericUpDown.TabIndex = 7;
            // 
            // MakerComboBox
            // 
            this.MakerComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.MakerComboBox.FormattingEnabled = true;
            this.MakerComboBox.Location = new System.Drawing.Point(234, 76);
            this.MakerComboBox.Name = "MakerComboBox";
            this.MakerComboBox.Size = new System.Drawing.Size(199, 25);
            this.MakerComboBox.TabIndex = 8;
            // 
            // ModelComboBox
            // 
            this.ModelComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.ModelComboBox.FormattingEnabled = true;
            this.ModelComboBox.Location = new System.Drawing.Point(234, 109);
            this.ModelComboBox.Name = "ModelComboBox";
            this.ModelComboBox.Size = new System.Drawing.Size(200, 25);
            this.ModelComboBox.TabIndex = 9;
            // 
            // CategoryСomboBox
            // 
            this.CategoryСomboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.CategoryСomboBox.FormattingEnabled = true;
            this.CategoryСomboBox.Location = new System.Drawing.Point(234, 140);
            this.CategoryСomboBox.Name = "CategoryСomboBox";
            this.CategoryСomboBox.Size = new System.Drawing.Size(200, 25);
            this.CategoryСomboBox.TabIndex = 10;
            // 
            // AddPriceLabel
            // 
            this.AddPriceLabel.AutoSize = true;
            this.AddPriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.AddPriceLabel.Location = new System.Drawing.Point(15, 206);
            this.AddPriceLabel.Name = "AddPriceLabel";
            this.AddPriceLabel.Size = new System.Drawing.Size(43, 17);
            this.AddPriceLabel.TabIndex = 11;
            this.AddPriceLabel.Text = "Цена";
            // 
            // CountNumericUpDown
            // 
            this.CountNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.CountNumericUpDown.Location = new System.Drawing.Point(234, 239);
            this.CountNumericUpDown.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.CountNumericUpDown.Name = "CountNumericUpDown";
            this.CountNumericUpDown.Size = new System.Drawing.Size(90, 23);
            this.CountNumericUpDown.TabIndex = 12;
            // 
            // AddButton
            // 
            this.AddButton.BackColor = System.Drawing.Color.LimeGreen;
            this.AddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.AddButton.Location = new System.Drawing.Point(330, 171);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(104, 91);
            this.AddButton.TabIndex = 13;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = false;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 271);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.CountNumericUpDown);
            this.Controls.Add(this.AddPriceLabel);
            this.Controls.Add(this.CategoryСomboBox);
            this.Controls.Add(this.ModelComboBox);
            this.Controls.Add(this.MakerComboBox);
            this.Controls.Add(this.SalesNumericUpDown);
            this.Controls.Add(this.PriceNumericUpDown);
            this.Controls.Add(this.AddCountLabel);
            this.Controls.Add(this.AddSalesLabel);
            this.Controls.Add(this.AddCategoryLabel);
            this.Controls.Add(this.AddModelLabel);
            this.Controls.Add(this.AddMakerLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ProductForm";
            this.Text = "ProductForm";
            ((System.ComponentModel.ISupportInitialize)(this.PriceNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CountNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label AddMakerLabel;
        private System.Windows.Forms.Label AddModelLabel;
        private System.Windows.Forms.Label AddCategoryLabel;
        private System.Windows.Forms.Label AddSalesLabel;
        private System.Windows.Forms.Label AddCountLabel;
        private System.Windows.Forms.NumericUpDown PriceNumericUpDown;
        private System.Windows.Forms.NumericUpDown SalesNumericUpDown;
        private System.Windows.Forms.ComboBox MakerComboBox;
        private System.Windows.Forms.ComboBox ModelComboBox;
        private System.Windows.Forms.ComboBox CategoryСomboBox;
        private System.Windows.Forms.Label AddPriceLabel;
        private System.Windows.Forms.NumericUpDown CountNumericUpDown;
        private System.Windows.Forms.Button AddButton;
    }
}