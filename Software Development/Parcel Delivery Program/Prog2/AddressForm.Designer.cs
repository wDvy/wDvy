namespace UPVApp
{
    partial class AddressForm
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
            this.components = new System.ComponentModel.Container();
            this.nameLbl = new System.Windows.Forms.Label();
            this.address1Lbl = new System.Windows.Forms.Label();
            this.cityLbl = new System.Windows.Forms.Label();
            this.stateLbl = new System.Windows.Forms.Label();
            this.zipLbl = new System.Windows.Forms.Label();
            this.nameTxt = new System.Windows.Forms.TextBox();
            this.address1Txt = new System.Windows.Forms.TextBox();
            this.address2Txt = new System.Windows.Forms.TextBox();
            this.cityTxt = new System.Windows.Forms.TextBox();
            this.stateCbo = new System.Windows.Forms.ComboBox();
            this.zipTxt = new System.Windows.Forms.TextBox();
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // nameLbl
            // 
            this.nameLbl.AutoSize = true;
            this.nameLbl.Location = new System.Drawing.Point(26, 9);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(38, 13);
            this.nameLbl.TabIndex = 0;
            this.nameLbl.Text = "Name:";
            // 
            // address1Lbl
            // 
            this.address1Lbl.AutoSize = true;
            this.address1Lbl.Location = new System.Drawing.Point(16, 34);
            this.address1Lbl.Name = "address1Lbl";
            this.address1Lbl.Size = new System.Drawing.Size(48, 13);
            this.address1Lbl.TabIndex = 1;
            this.address1Lbl.Text = "Address:";
            // 
            // cityLbl
            // 
            this.cityLbl.AutoSize = true;
            this.cityLbl.Location = new System.Drawing.Point(37, 88);
            this.cityLbl.Name = "cityLbl";
            this.cityLbl.Size = new System.Drawing.Size(27, 13);
            this.cityLbl.TabIndex = 2;
            this.cityLbl.Text = "City:";
            // 
            // stateLbl
            // 
            this.stateLbl.AutoSize = true;
            this.stateLbl.Location = new System.Drawing.Point(29, 110);
            this.stateLbl.Name = "stateLbl";
            this.stateLbl.Size = new System.Drawing.Size(35, 13);
            this.stateLbl.TabIndex = 3;
            this.stateLbl.Text = "State:";
            // 
            // zipLbl
            // 
            this.zipLbl.AutoSize = true;
            this.zipLbl.Location = new System.Drawing.Point(39, 134);
            this.zipLbl.Name = "zipLbl";
            this.zipLbl.Size = new System.Drawing.Size(25, 13);
            this.zipLbl.TabIndex = 4;
            this.zipLbl.Text = "Zip:";
            // 
            // nameTxt
            // 
            this.nameTxt.Location = new System.Drawing.Point(70, 6);
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.Size = new System.Drawing.Size(100, 20);
            this.nameTxt.TabIndex = 5;
            this.nameTxt.Validating += new System.ComponentModel.CancelEventHandler(this.RequiredTextFields_Validating);
            this.nameTxt.Validated += new System.EventHandler(this.AllFields_Validated);
            // 
            // address1Txt
            // 
            this.address1Txt.Location = new System.Drawing.Point(70, 31);
            this.address1Txt.Name = "address1Txt";
            this.address1Txt.Size = new System.Drawing.Size(100, 20);
            this.address1Txt.TabIndex = 6;
            this.address1Txt.Validating += new System.ComponentModel.CancelEventHandler(this.RequiredTextFields_Validating);
            this.address1Txt.Validated += new System.EventHandler(this.AllFields_Validated);
            // 
            // address2Txt
            // 
            this.address2Txt.Location = new System.Drawing.Point(70, 57);
            this.address2Txt.Name = "address2Txt";
            this.address2Txt.Size = new System.Drawing.Size(100, 20);
            this.address2Txt.TabIndex = 7;
            // 
            // cityTxt
            // 
            this.cityTxt.Location = new System.Drawing.Point(70, 85);
            this.cityTxt.Name = "cityTxt";
            this.cityTxt.Size = new System.Drawing.Size(100, 20);
            this.cityTxt.TabIndex = 8;
            this.cityTxt.Validating += new System.ComponentModel.CancelEventHandler(this.RequiredTextFields_Validating);
            this.cityTxt.Validated += new System.EventHandler(this.AllFields_Validated);
            // 
            // stateCbo
            // 
            this.stateCbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stateCbo.FormattingEnabled = true;
            this.stateCbo.Location = new System.Drawing.Point(70, 107);
            this.stateCbo.Name = "stateCbo";
            this.stateCbo.Size = new System.Drawing.Size(100, 21);
            this.stateCbo.TabIndex = 9;
            this.stateCbo.Validating += new System.ComponentModel.CancelEventHandler(this.stateCbo_Validating);
            this.stateCbo.Validated += new System.EventHandler(this.AllFields_Validated);
            // 
            // zipTxt
            // 
            this.zipTxt.Location = new System.Drawing.Point(70, 131);
            this.zipTxt.Name = "zipTxt";
            this.zipTxt.Size = new System.Drawing.Size(100, 20);
            this.zipTxt.TabIndex = 10;
            this.zipTxt.Validating += new System.ComponentModel.CancelEventHandler(this.zipTxt_Validating);
            this.zipTxt.Validated += new System.EventHandler(this.AllFields_Validated);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(13, 161);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 11;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(95, 161);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 12;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cancelBtn_MouseDown);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // AddressForm
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(194, 198);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.zipTxt);
            this.Controls.Add(this.stateCbo);
            this.Controls.Add(this.cityTxt);
            this.Controls.Add(this.address2Txt);
            this.Controls.Add(this.address1Txt);
            this.Controls.Add(this.nameTxt);
            this.Controls.Add(this.zipLbl);
            this.Controls.Add(this.stateLbl);
            this.Controls.Add(this.cityLbl);
            this.Controls.Add(this.address1Lbl);
            this.Controls.Add(this.nameLbl);
            this.Name = "AddressForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Address";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLbl;
        private System.Windows.Forms.Label address1Lbl;
        private System.Windows.Forms.Label cityLbl;
        private System.Windows.Forms.Label stateLbl;
        private System.Windows.Forms.Label zipLbl;
        private System.Windows.Forms.TextBox nameTxt;
        private System.Windows.Forms.TextBox address1Txt;
        private System.Windows.Forms.TextBox address2Txt;
        private System.Windows.Forms.TextBox cityTxt;
        private System.Windows.Forms.ComboBox stateCbo;
        private System.Windows.Forms.TextBox zipTxt;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}