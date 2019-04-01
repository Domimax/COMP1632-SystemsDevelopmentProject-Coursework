namespace SystemsDevProject
{
    partial class PaymentForm
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
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxCVV = new System.Windows.Forms.TextBox();
            this.SaveChangesbtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.radioButtonOnline = new System.Windows.Forms.RadioButton();
            this.radioButtonAtBooth = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // cardtypelbl
            // 
            this.cardtypelbl.AutoSize = true;
            this.cardtypelbl.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cardtypelbl.Location = new System.Drawing.Point(33, 208);
            this.cardtypelbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.cardtypelbl.Name = "cardtypelbl";
            this.cardtypelbl.Size = new System.Drawing.Size(111, 20);
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
            this.comboBoxCardtype.Location = new System.Drawing.Point(180, 208);
            this.comboBoxCardtype.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxCardtype.Name = "comboBoxCardtype";
            this.comboBoxCardtype.Size = new System.Drawing.Size(160, 24);
            this.comboBoxCardtype.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter New Card Details:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 131);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Card Number:";
            // 
            // textBoxCardNumber
            // 
            this.textBoxCardNumber.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCardNumber.Location = new System.Drawing.Point(181, 128);
            this.textBoxCardNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxCardNumber.Name = "textBoxCardNumber";
            this.textBoxCardNumber.Size = new System.Drawing.Size(219, 27);
            this.textBoxCardNumber.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(434, 62);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Expiry Date:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(33, 173);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "CVV Number:";
            // 
            // textBoxCVV
            // 
            this.textBoxCVV.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCVV.Location = new System.Drawing.Point(180, 173);
            this.textBoxCVV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxCVV.Name = "textBoxCVV";
            this.textBoxCVV.Size = new System.Drawing.Size(71, 27);
            this.textBoxCVV.TabIndex = 11;
            // 
            // SaveChangesbtn
            // 
            this.SaveChangesbtn.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveChangesbtn.Location = new System.Drawing.Point(317, 342);
            this.SaveChangesbtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SaveChangesbtn.Name = "SaveChangesbtn";
            this.SaveChangesbtn.Size = new System.Drawing.Size(179, 34);
            this.SaveChangesbtn.TabIndex = 12;
            this.SaveChangesbtn.Text = "Save Changes";
            this.SaveChangesbtn.UseVisualStyleBackColor = true;
            this.SaveChangesbtn.Click += new System.EventHandler(this.SaveChangesbtn_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(28, 50);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "Collection:";
            // 
            // radioButtonOnline
            // 
            this.radioButtonOnline.AutoSize = true;
            this.radioButtonOnline.Checked = true;
            this.radioButtonOnline.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonOnline.Location = new System.Drawing.Point(180, 49);
            this.radioButtonOnline.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonOnline.Name = "radioButtonOnline";
            this.radioButtonOnline.Size = new System.Drawing.Size(85, 24);
            this.radioButtonOnline.TabIndex = 14;
            this.radioButtonOnline.TabStop = true;
            this.radioButtonOnline.Text = "Online";
            this.radioButtonOnline.UseVisualStyleBackColor = true;
            // 
            // radioButtonAtBooth
            // 
            this.radioButtonAtBooth.AutoSize = true;
            this.radioButtonAtBooth.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonAtBooth.Location = new System.Drawing.Point(273, 49);
            this.radioButtonAtBooth.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonAtBooth.Name = "radioButtonAtBooth";
            this.radioButtonAtBooth.Size = new System.Drawing.Size(80, 24);
            this.radioButtonAtBooth.TabIndex = 15;
            this.radioButtonAtBooth.TabStop = true;
            this.radioButtonAtBooth.Text = "Booth";
            this.radioButtonAtBooth.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(28, 90);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(147, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "Name on card:";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(183, 90);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(219, 27);
            this.textBox1.TabIndex = 17;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(438, 103);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 18;
            // 
            // PaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 402);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.radioButtonAtBooth);
            this.Controls.Add(this.radioButtonOnline);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.SaveChangesbtn);
            this.Controls.Add(this.textBoxCVV);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxCardNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxCardtype);
            this.Controls.Add(this.cardtypelbl);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PaymentForm";
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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxCVV;
        private System.Windows.Forms.Button SaveChangesbtn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton radioButtonOnline;
        private System.Windows.Forms.RadioButton radioButtonAtBooth;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}