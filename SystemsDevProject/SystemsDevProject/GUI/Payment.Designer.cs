namespace SystemsDevProject
{
    partial class Payment
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
            this.cardtypelbl = new System.Windows.Forms.Label();
            this.comboBoxCardtype = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCardNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxExpiryMM = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxExpiryYY = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxCVV = new System.Windows.Forms.TextBox();
            this.SaveChangesbtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.radioButtonOnline = new System.Windows.Forms.RadioButton();
            this.radioButtonAtBooth = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // cardtypelbl
            // 
            this.cardtypelbl.AutoSize = true;
            this.cardtypelbl.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cardtypelbl.Location = new System.Drawing.Point(21, 92);
            this.cardtypelbl.Name = "cardtypelbl";
            this.cardtypelbl.Size = new System.Drawing.Size(86, 16);
            this.cardtypelbl.TabIndex = 0;
            this.cardtypelbl.Text = "Card Type:";
            // 
            // comboBoxCardtype
            // 
            this.comboBoxCardtype.FormattingEnabled = true;
            this.comboBoxCardtype.Items.AddRange(new object[] {
            "Visa",
            "MasterCard",
            "Diners Club",
            "American Express"});
            this.comboBoxCardtype.Location = new System.Drawing.Point(135, 87);
            this.comboBoxCardtype.Name = "comboBoxCardtype";
            this.comboBoxCardtype.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCardtype.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter New Card Details:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Card Number:";
            // 
            // textBoxCardNumber
            // 
            this.textBoxCardNumber.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCardNumber.Location = new System.Drawing.Point(135, 135);
            this.textBoxCardNumber.Name = "textBoxCardNumber";
            this.textBoxCardNumber.Size = new System.Drawing.Size(165, 23);
            this.textBoxCardNumber.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Expiry Date:";
            // 
            // textBoxExpiryMM
            // 
            this.textBoxExpiryMM.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxExpiryMM.Location = new System.Drawing.Point(135, 183);
            this.textBoxExpiryMM.Name = "textBoxExpiryMM";
            this.textBoxExpiryMM.Size = new System.Drawing.Size(34, 23);
            this.textBoxExpiryMM.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(175, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "/";
            // 
            // textBoxExpiryYY
            // 
            this.textBoxExpiryYY.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxExpiryYY.Location = new System.Drawing.Point(195, 183);
            this.textBoxExpiryYY.Name = "textBoxExpiryYY";
            this.textBoxExpiryYY.Size = new System.Drawing.Size(33, 23);
            this.textBoxExpiryYY.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(234, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "(MM/YY)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(21, 235);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "CVV Number:";
            // 
            // textBoxCVV
            // 
            this.textBoxCVV.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCVV.Location = new System.Drawing.Point(135, 228);
            this.textBoxCVV.Name = "textBoxCVV";
            this.textBoxCVV.Size = new System.Drawing.Size(54, 23);
            this.textBoxCVV.TabIndex = 11;
            // 
            // SaveChangesbtn
            // 
            this.SaveChangesbtn.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveChangesbtn.Location = new System.Drawing.Point(66, 276);
            this.SaveChangesbtn.Name = "SaveChangesbtn";
            this.SaveChangesbtn.Size = new System.Drawing.Size(134, 28);
            this.SaveChangesbtn.TabIndex = 12;
            this.SaveChangesbtn.Text = "Save Changes";
            this.SaveChangesbtn.UseVisualStyleBackColor = true;
            this.SaveChangesbtn.Click += new System.EventHandler(this.SaveChangesbtn_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(21, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "Collection:";
            // 
            // radioButtonOnline
            // 
            this.radioButtonOnline.AutoSize = true;
            this.radioButtonOnline.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonOnline.Location = new System.Drawing.Point(135, 40);
            this.radioButtonOnline.Name = "radioButtonOnline";
            this.radioButtonOnline.Size = new System.Drawing.Size(66, 20);
            this.radioButtonOnline.TabIndex = 14;
            this.radioButtonOnline.TabStop = true;
            this.radioButtonOnline.Text = "Online";
            this.radioButtonOnline.UseVisualStyleBackColor = true;
            // 
            // radioButtonAtBooth
            // 
            this.radioButtonAtBooth.AutoSize = true;
            this.radioButtonAtBooth.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonAtBooth.Location = new System.Drawing.Point(205, 40);
            this.radioButtonAtBooth.Name = "radioButtonAtBooth";
            this.radioButtonAtBooth.Size = new System.Drawing.Size(64, 20);
            this.radioButtonAtBooth.TabIndex = 15;
            this.radioButtonAtBooth.TabStop = true;
            this.radioButtonAtBooth.Text = "Booth";
            this.radioButtonAtBooth.UseVisualStyleBackColor = true;
            // 
            // Payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 327);
            this.Controls.Add(this.radioButtonAtBooth);
            this.Controls.Add(this.radioButtonOnline);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.SaveChangesbtn);
            this.Controls.Add(this.textBoxCVV);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxExpiryYY);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxExpiryMM);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxCardNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxCardtype);
            this.Controls.Add(this.cardtypelbl);
            this.Name = "Payment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label cardtypelbl;
        private System.Windows.Forms.ComboBox comboBoxCardtype;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxCardNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxExpiryMM;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxExpiryYY;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxCVV;
        private System.Windows.Forms.Button SaveChangesbtn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton radioButtonOnline;
        private System.Windows.Forms.RadioButton radioButtonAtBooth;
    }
}