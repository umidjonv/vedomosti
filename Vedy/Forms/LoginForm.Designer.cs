namespace Vedy
{
    partial class LoginForm
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
            btnEnter = new Button();
            label1 = new Label();
            tbxUserName = new TextBox();
            tbxPass = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // btnEnter
            // 
            btnEnter.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEnter.Location = new Point(149, 188);
            btnEnter.Name = "btnEnter";
            btnEnter.Size = new Size(185, 35);
            btnEnter.TabIndex = 3;
            btnEnter.Text = "ВОЙТИ";
            btnEnter.UseVisualStyleBackColor = true;
            btnEnter.Click += btnEnter_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(66, 40);
            label1.Name = "label1";
            label1.Size = new Size(69, 25);
            label1.TabIndex = 11;
            label1.Text = "Логин:";
            // 
            // tbxUserName
            // 
            tbxUserName.Location = new Point(149, 37);
            tbxUserName.Name = "tbxUserName";
            tbxUserName.Size = new Size(185, 33);
            tbxUserName.TabIndex = 0;
            tbxUserName.KeyPress += tbxPass_KeyPress;
            // 
            // tbxPass
            // 
            tbxPass.Location = new Point(149, 105);
            tbxPass.Name = "tbxPass";
            tbxPass.PasswordChar = '*';
            tbxPass.Size = new Size(185, 33);
            tbxPass.TabIndex = 1;
            tbxPass.KeyPress += tbxPass_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(53, 108);
            label2.Name = "label2";
            label2.Size = new Size(82, 25);
            label2.TabIndex = 12;
            label2.Text = "Пароль:";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(488, 235);
            Controls.Add(tbxPass);
            Controls.Add(label2);
            Controls.Add(tbxUserName);
            Controls.Add(label1);
            Controls.Add(btnEnter);
            Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Главная";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox GpCompanies;
        private DataGridView dgvCompanies;
        private Button btnCreate;
        private Label lblSearchCompany;
        private TextBox tbxSearchCompany;
        private GroupBox groupBox1;
        private Label label2;
        private TextBox tbxSearchSettlement;
        private Button btnDownload;
        private DataGridView dgvSettlement;
        private Button btnEnter;
        private Label label1;
        private TextBox tbxUserName;
        private TextBox tbxPass;
    }
}
