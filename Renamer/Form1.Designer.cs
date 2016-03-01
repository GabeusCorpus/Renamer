namespace Renamer
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.sSourceFolder = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.sDestFolder = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.sExcelFile = new System.Windows.Forms.TextBox();
            this.fldLookUpVal = new System.Windows.Forms.ComboBox();
            this.regExpression = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.fldLookupValTo = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(31, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(305, 53);
            this.button1.TabIndex = 0;
            this.button1.Text = "Select Source Folder";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // sSourceFolder
            // 
            this.sSourceFolder.Location = new System.Drawing.Point(380, 26);
            this.sSourceFolder.Name = "sSourceFolder";
            this.sSourceFolder.Size = new System.Drawing.Size(842, 31);
            this.sSourceFolder.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(31, 106);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(305, 53);
            this.button2.TabIndex = 2;
            this.button2.Text = "Select Destination Folder";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // sDestFolder
            // 
            this.sDestFolder.Location = new System.Drawing.Point(380, 106);
            this.sDestFolder.Name = "sDestFolder";
            this.sDestFolder.Size = new System.Drawing.Size(842, 31);
            this.sDestFolder.TabIndex = 3;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(31, 184);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(305, 52);
            this.button4.TabIndex = 5;
            this.button4.Text = "Select Excel File";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // sExcelFile
            // 
            this.sExcelFile.Location = new System.Drawing.Point(380, 184);
            this.sExcelFile.Name = "sExcelFile";
            this.sExcelFile.Size = new System.Drawing.Size(842, 31);
            this.sExcelFile.TabIndex = 6;
            // 
            // fldLookUpVal
            // 
            this.fldLookUpVal.DropDownWidth = 160;
            this.fldLookUpVal.FormattingEnabled = true;
            this.fldLookUpVal.Location = new System.Drawing.Point(380, 266);
            this.fldLookUpVal.Name = "fldLookUpVal";
            this.fldLookUpVal.Size = new System.Drawing.Size(160, 33);
            this.fldLookUpVal.TabIndex = 7;
            // 
            // regExpression
            // 
            this.regExpression.Location = new System.Drawing.Point(380, 354);
            this.regExpression.Name = "regExpression";
            this.regExpression.Size = new System.Drawing.Size(842, 31);
            this.regExpression.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 360);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Specify Regular Expression:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(199, 266);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Replace this:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(559, 266);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "with:";
            // 
            // fldLookupValTo
            // 
            this.fldLookupValTo.FormattingEnabled = true;
            this.fldLookupValTo.Location = new System.Drawing.Point(651, 266);
            this.fldLookupValTo.Name = "fldLookupValTo";
            this.fldLookupValTo.Size = new System.Drawing.Size(160, 33);
            this.fldLookupValTo.TabIndex = 12;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(31, 438);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(305, 52);
            this.button3.TabIndex = 13;
            this.button3.Text = "Run, Blinky, Run.";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1595, 570);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.fldLookupValTo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.regExpression);
            this.Controls.Add(this.fldLookUpVal);
            this.Controls.Add(this.sExcelFile);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.sDestFolder);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.sSourceFolder);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Renamer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox sSourceFolder;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox sDestFolder;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox sExcelFile;
        private System.Windows.Forms.ComboBox fldLookUpVal;
        private System.Windows.Forms.TextBox regExpression;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox fldLookupValTo;
        private System.Windows.Forms.Button button3;
    }
}

