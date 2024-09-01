namespace Vedy.Forms
{
    partial class Companies
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
            lbxCompanies = new ListBox();
            tbxCompany = new TextBox();
            label1 = new Label();
            label2 = new Label();
            tbxTin = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // lbxCompanies
            // 
            lbxCompanies.FormattingEnabled = true;
            lbxCompanies.ItemHeight = 20;
            lbxCompanies.Location = new Point(5, 25);
            lbxCompanies.Name = "lbxCompanies";
            lbxCompanies.Size = new Size(417, 564);
            lbxCompanies.TabIndex = 0;
            // 
            // tbxCompany
            // 
            tbxCompany.Location = new Point(525, 25);
            tbxCompany.Name = "tbxCompany";
            tbxCompany.Size = new Size(181, 27);
            tbxCompany.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(438, 25);
            label1.Name = "label1";
            label1.Size = new Size(81, 20);
            label1.TabIndex = 2;
            label1.Text = "Компания";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(477, 73);
            label2.Name = "label2";
            label2.Size = new Size(42, 20);
            label2.TabIndex = 4;
            label2.Text = "ИНН";
            // 
            // tbxTin
            // 
            tbxTin.Location = new Point(525, 70);
            tbxTin.Name = "tbxTin";
            tbxTin.Size = new Size(181, 27);
            tbxTin.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(620, 159);
            button1.Name = "button1";
            button1.Size = new Size(96, 36);
            button1.TabIndex = 5;
            button1.Text = "Сохранить";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(518, 159);
            button2.Name = "button2";
            button2.Size = new Size(96, 36);
            button2.TabIndex = 6;
            button2.Text = "Новый";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(620, 543);
            button3.Name = "button3";
            button3.Size = new Size(96, 36);
            button3.TabIndex = 7;
            button3.Text = "Закрыть";
            button3.UseVisualStyleBackColor = true;
            // 
            // Companies
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(718, 591);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(tbxTin);
            Controls.Add(label1);
            Controls.Add(tbxCompany);
            Controls.Add(lbxCompanies);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Companies";
            Text = "Companies";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lbxCompanies;
        private TextBox tbxCompany;
        private Label label1;
        private Label label2;
        private TextBox tbxTin;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}