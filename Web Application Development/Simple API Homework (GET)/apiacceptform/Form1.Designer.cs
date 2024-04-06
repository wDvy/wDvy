namespace apiacceptform
{
    partial class Form1
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
            Calc = new Button();
            nameLbl = new Label();
            locationLbl = new Label();
            imgBox = new PictureBox();
            nameBox = new TextBox();
            countryLbl = new Label();
            followerLbl = new Label();
            outPutlabel = new Label();
            nameOut = new Label();
            locationOut = new Label();
            countryOut = new Label();
            followersOut = new Label();
            ((System.ComponentModel.ISupportInitialize)imgBox).BeginInit();
            SuspendLayout();
            // 
            // Calc
            // 
            Calc.Location = new Point(155, 401);
            Calc.Name = "Calc";
            Calc.Size = new Size(75, 23);
            Calc.TabIndex = 0;
            Calc.Text = "Request";
            Calc.UseVisualStyleBackColor = true;
            Calc.Click += Calc_Click;
            // 
            // nameLbl
            // 
            nameLbl.AutoSize = true;
            nameLbl.Location = new Point(61, 299);
            nameLbl.Name = "nameLbl";
            nameLbl.Size = new Size(42, 15);
            nameLbl.TabIndex = 1;
            nameLbl.Text = "Name:";
            // 
            // locationLbl
            // 
            locationLbl.AutoSize = true;
            locationLbl.Location = new Point(61, 314);
            locationLbl.Name = "locationLbl";
            locationLbl.Size = new Size(56, 15);
            locationLbl.TabIndex = 2;
            locationLbl.Text = "Location:";
            // 
            // imgBox
            // 
            imgBox.Location = new Point(61, 31);
            imgBox.Name = "imgBox";
            imgBox.Size = new Size(264, 237);
            imgBox.TabIndex = 3;
            imgBox.TabStop = false;
            // 
            // nameBox
            // 
            nameBox.Location = new Point(148, 372);
            nameBox.Name = "nameBox";
            nameBox.Size = new Size(100, 23);
            nameBox.TabIndex = 4;
            // 
            // countryLbl
            // 
            countryLbl.AutoSize = true;
            countryLbl.Location = new Point(61, 329);
            countryLbl.Name = "countryLbl";
            countryLbl.Size = new Size(53, 15);
            countryLbl.TabIndex = 5;
            countryLbl.Text = "Country:";
            // 
            // followerLbl
            // 
            followerLbl.AutoSize = true;
            followerLbl.Location = new Point(61, 344);
            followerLbl.Name = "followerLbl";
            followerLbl.Size = new Size(60, 15);
            followerLbl.TabIndex = 6;
            followerLbl.Text = "Followers:";
            // 
            // outPutlabel
            // 
            outPutlabel.AutoSize = true;
            outPutlabel.Location = new Point(152, 220);
            outPutlabel.Name = "outPutlabel";
            outPutlabel.Size = new Size(0, 15);
            outPutlabel.TabIndex = 7;
            // 
            // nameOut
            // 
            nameOut.BorderStyle = BorderStyle.FixedSingle;
            nameOut.Location = new Point(152, 298);
            nameOut.Name = "nameOut";
            nameOut.Size = new Size(100, 15);
            nameOut.TabIndex = 8;
            // 
            // locationOut
            // 
            locationOut.BorderStyle = BorderStyle.FixedSingle;
            locationOut.Location = new Point(152, 313);
            locationOut.Name = "locationOut";
            locationOut.Size = new Size(100, 15);
            locationOut.TabIndex = 9;
            // 
            // countryOut
            // 
            countryOut.BorderStyle = BorderStyle.FixedSingle;
            countryOut.Location = new Point(152, 328);
            countryOut.Name = "countryOut";
            countryOut.Size = new Size(100, 15);
            countryOut.TabIndex = 10;
            // 
            // followersOut
            // 
            followersOut.BorderStyle = BorderStyle.FixedSingle;
            followersOut.Location = new Point(152, 342);
            followersOut.Name = "followersOut";
            followersOut.Size = new Size(100, 15);
            followersOut.TabIndex = 11;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(363, 498);
            Controls.Add(followersOut);
            Controls.Add(countryOut);
            Controls.Add(locationOut);
            Controls.Add(nameOut);
            Controls.Add(outPutlabel);
            Controls.Add(followerLbl);
            Controls.Add(countryLbl);
            Controls.Add(nameBox);
            Controls.Add(imgBox);
            Controls.Add(locationLbl);
            Controls.Add(nameLbl);
            Controls.Add(Calc);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)imgBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Calc;
        private Label nameLbl;
        private Label locationLbl;
        private PictureBox imgBox;
        private TextBox nameBox;
        private Label countryLbl;
        private Label followerLbl;
        private Label outPutlabel;
        private Label nameOut;
        private Label locationOut;
        private Label countryOut;
        private Label followersOut;
    }
}
