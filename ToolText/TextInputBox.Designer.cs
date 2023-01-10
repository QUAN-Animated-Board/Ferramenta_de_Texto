namespace ToolText
{
    partial class TextInputBox
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.checkButton1 = new System.Windows.Forms.CheckBox();
            this.checkButton2 = new System.Windows.Forms.CheckBox();
            this.checkButton3 = new System.Windows.Forms.CheckBox();
            this.checkButton4 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Font:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(79, 8);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(234, 23);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Size:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(79, 45);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(45, 23);
            this.numericUpDown1.TabIndex = 3;
            this.numericUpDown1.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // checkButton1
            // 
            this.checkButton1.BackgroundImage = global::ToolText.Properties.Resources.bold;
            this.checkButton1.Location = new System.Drawing.Point(130, 44);
            this.checkButton1.Name = "checkButton1";
            this.checkButton1.Size = new System.Drawing.Size(38, 23);
            this.checkButton1.TabIndex = 4;
            this.checkButton1.UseVisualStyleBackColor = true;
            this.checkButton1.Click += new System.EventHandler(this.checkButton1_Click);
            // 
            // checkButton2
            // 
            this.checkButton2.BackgroundImage = global::ToolText.Properties.Resources.italic1;
            this.checkButton2.Location = new System.Drawing.Point(174, 44);
            this.checkButton2.Name = "checkButton2";
            this.checkButton2.Size = new System.Drawing.Size(38, 23);
            this.checkButton2.TabIndex = 5;
            this.checkButton2.UseVisualStyleBackColor = true;
            this.checkButton2.Click += new System.EventHandler(this.checkButton2_Click);
            // 
            // checkButton3
            // 
            this.checkButton3.BackgroundImage = global::ToolText.Properties.Resources.strike;
            this.checkButton3.Location = new System.Drawing.Point(218, 44);
            this.checkButton3.Name = "checkButton3";
            this.checkButton3.Size = new System.Drawing.Size(38, 23);
            this.checkButton3.TabIndex = 6;
            this.checkButton3.UseVisualStyleBackColor = true;
            this.checkButton3.Click += new System.EventHandler(this.checkButton3_Click);
            // 
            // checkButton4
            // 
            this.checkButton4.BackgroundImage = global::ToolText.Properties.Resources.underline;
            this.checkButton4.Location = new System.Drawing.Point(262, 44);
            this.checkButton4.Name = "checkButton4";
            this.checkButton4.Size = new System.Drawing.Size(38, 23);
            this.checkButton4.TabIndex = 7;
            this.checkButton4.UseVisualStyleBackColor = true;
            this.checkButton4.Click += new System.EventHandler(this.checkButton4_Click);
            // 
            // TextInputBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(323, 76);
            this.Controls.Add(this.checkButton4);
            this.Controls.Add(this.checkButton3);
            this.Controls.Add(this.checkButton2);
            this.Controls.Add(this.checkButton1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TextInputBox";
            this.Text = "TextInputBox";
            this.Load += new System.EventHandler(this.TextInputBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private ComboBox comboBox1;
        private Label label2;
        private NumericUpDown numericUpDown1;
        private CheckBox checkButton1;
        private CheckBox checkButton2;
        private CheckBox checkButton3;
        private CheckBox checkButton4;
    }
}