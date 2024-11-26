using System.IO;
using System.Windows.Forms;

namespace GasPriceChronicles
{
    partial class Gas_Price_Analyzer
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            titleLabel = new Label();
            themeBtn = new Button();
            gasPumpImg = new PictureBox();
            outputBox = new ListBox();
            APPY_Btn = new Button();
            APPM_Btn = new Button();
            PLH_Btn = new Button();
            PHL_Btn = new Button();
            HLPPY_Btn = new Button();
            closeBtn = new Button();
            displayLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)gasPumpImg).BeginInit();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.Font = new Font("Georgia", 18F, FontStyle.Italic);
            titleLabel.Location = new Point(259, 22);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(275, 82);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Gas Price Trends From 1993 - 2013";
            // 
            // themeBtn
            // 
            themeBtn.BackColor = Color.White;
            themeBtn.FlatAppearance.BorderSize = 2;
            themeBtn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            themeBtn.ForeColor = Color.Black;
            themeBtn.Location = new Point(28, 41);
            themeBtn.Name = "themeBtn";
            themeBtn.Size = new Size(121, 43);
            themeBtn.TabIndex = 3;
            themeBtn.Text = "Light Mode";
            themeBtn.UseVisualStyleBackColor = false;
            themeBtn.Click += themeBtn_Click;
            // 
            // gasPumpImg
            // 
            gasPumpImg.Location = new Point(563, 3);
            gasPumpImg.Name = "gasPumpImg";
            gasPumpImg.Size = new Size(76, 110);
            gasPumpImg.SizeMode = PictureBoxSizeMode.StretchImage;
            gasPumpImg.TabIndex = 4;
            gasPumpImg.TabStop = false;
            // 
            // outputBox
            // 
            outputBox.FormattingEnabled = true;
            outputBox.Location = new Point(217, 147);
            outputBox.Name = "outputBox";
            outputBox.Size = new Size(341, 244);
            outputBox.TabIndex = 5;
            // 
            // APPY_Btn
            // 
            APPY_Btn.Location = new Point(28, 168);
            APPY_Btn.Name = "APPY_Btn";
            APPY_Btn.Size = new Size(151, 64);
            APPY_Btn.TabIndex = 6;
            APPY_Btn.Text = "Average Price Per Year";
            APPY_Btn.UseVisualStyleBackColor = true;
            APPY_Btn.Click += APPY_Btn_Click;
            // 
            // APPM_Btn
            // 
            APPM_Btn.Location = new Point(605, 168);
            APPM_Btn.Name = "APPM_Btn";
            APPM_Btn.Size = new Size(151, 64);
            APPM_Btn.TabIndex = 7;
            APPM_Btn.Text = "Average Price Per Month";
            APPM_Btn.UseVisualStyleBackColor = true;
            APPM_Btn.Click += APPM_Click;
            // 
            // PLH_Btn
            // 
            PLH_Btn.Location = new Point(28, 248);
            PLH_Btn.Name = "PLH_Btn";
            PLH_Btn.Size = new Size(151, 64);
            PLH_Btn.TabIndex = 8;
            PLH_Btn.Text = "Prices Lowest To Highest";
            PLH_Btn.UseVisualStyleBackColor = true;
            PLH_Btn.Click += PLH_Btn_Click;
            // 
            // PHL_Btn
            // 
            PHL_Btn.Location = new Point(605, 248);
            PHL_Btn.Name = "PHL_Btn";
            PHL_Btn.Size = new Size(151, 64);
            PHL_Btn.TabIndex = 9;
            PHL_Btn.Text = "Prices Highest To Lowest";
            PHL_Btn.UseVisualStyleBackColor = true;
            PHL_Btn.Click += PHL_Btn_Click;
            // 
            // HLPPY_Btn
            // 
            HLPPY_Btn.Location = new Point(28, 327);
            HLPPY_Btn.Name = "HLPPY_Btn";
            HLPPY_Btn.Size = new Size(151, 64);
            HLPPY_Btn.TabIndex = 10;
            HLPPY_Btn.Text = "Highest And Lowest Price Per Year";
            HLPPY_Btn.UseVisualStyleBackColor = true;
            HLPPY_Btn.Click += HLPPY_Btn_Click;
            // 
            // closeBtn
            // 
            closeBtn.Location = new Point(605, 327);
            closeBtn.Name = "closeBtn";
            closeBtn.Size = new Size(151, 64);
            closeBtn.TabIndex = 11;
            closeBtn.Text = "Close";
            closeBtn.BackColor = Color.Red;
            closeBtn.ForeColor = Color.White;
            closeBtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            closeBtn.FlatAppearance.BorderSize = 0;
            closeBtn.FlatStyle = FlatStyle.Flat;
            closeBtn.UseVisualStyleBackColor = true;
            closeBtn.Click += closeBtn_Click;
            // 
            // displayLabel
            // 
            displayLabel.AutoSize = true;
            displayLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            displayLabel.Location = new Point(326, 404);
            displayLabel.Name = "displayLabel";
            displayLabel.Size = new Size(112, 23);
            displayLabel.TabIndex = 12;
            displayLabel.Text = "Data Display";
            // 
            // Gas_Price_Analyzer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(displayLabel);
            Controls.Add(closeBtn);
            Controls.Add(HLPPY_Btn);
            Controls.Add(PHL_Btn);
            Controls.Add(PLH_Btn);
            Controls.Add(APPM_Btn);
            Controls.Add(APPY_Btn);
            Controls.Add(outputBox);
            Controls.Add(gasPumpImg);
            Controls.Add(themeBtn);
            Controls.Add(titleLabel);
            Name = "Gas_Price_Analyzer";
            Text = "Gas Price Analyzer";
            ((System.ComponentModel.ISupportInitialize)gasPumpImg).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }




        #endregion

        private Label titleLabel;
        private Button themeBtn;
        private PictureBox gasPumpImg;
        private ListBox outputBox;
        private Button APPY_Btn;
        private Button APPM_Btn;
        private Button PLH_Btn;
        private Button PHL_Btn;
        private Button HLPPY_Btn;
        private Button closeBtn;
        private Label displayLabel;
    }
}
