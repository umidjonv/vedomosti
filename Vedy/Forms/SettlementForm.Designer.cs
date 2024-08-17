namespace Vedy.Forms
{
    partial class SettlementForm
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
            gpSettlement = new GroupBox();
            textBox3 = new TextBox();
            label3 = new Label();
            textBox2 = new TextBox();
            label2 = new Label();
            btnSelectCompany = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            btnSave = new Button();
            label4 = new Label();
            settlementNumber = new Label();
            pictureBox1 = new PictureBox();
            label5 = new Label();
            label6 = new Label();
            dgvSettlement = new DataGridView();
            btnClose = new Button();
            gpSettlement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSettlement).BeginInit();
            SuspendLayout();
            // 
            // gpSettlement
            // 
            gpSettlement.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            gpSettlement.Controls.Add(btnClose);
            gpSettlement.Controls.Add(pictureBox1);
            gpSettlement.Controls.Add(textBox3);
            gpSettlement.Controls.Add(label3);
            gpSettlement.Controls.Add(textBox2);
            gpSettlement.Controls.Add(label2);
            gpSettlement.Controls.Add(btnSelectCompany);
            gpSettlement.Controls.Add(textBox1);
            gpSettlement.Controls.Add(label1);
            gpSettlement.Controls.Add(btnSave);
            gpSettlement.Location = new Point(0, 143);
            gpSettlement.Margin = new Padding(3, 4, 3, 4);
            gpSettlement.Name = "gpSettlement";
            gpSettlement.Padding = new Padding(3, 4, 3, 4);
            gpSettlement.Size = new Size(342, 614);
            gpSettlement.TabIndex = 0;
            gpSettlement.TabStop = false;
            gpSettlement.Text = "Регистрация Авто";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(113, 207);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(223, 27);
            textBox3.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 207);
            label3.Name = "label3";
            label3.Size = new Size(42, 20);
            label3.TabIndex = 6;
            label3.Text = "Авто";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(119, 136);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(223, 27);
            textBox2.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 136);
            label2.Name = "label2";
            label2.Size = new Size(58, 20);
            label2.TabIndex = 4;
            label2.Text = "Клиент";
            // 
            // btnSelectCompany
            // 
            btnSelectCompany.Location = new Point(245, 87);
            btnSelectCompany.Name = "btnSelectCompany";
            btnSelectCompany.Size = new Size(91, 29);
            btnSelectCompany.TabIndex = 3;
            btnSelectCompany.Text = "Выбрать";
            btnSelectCompany.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(113, 54);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(223, 27);
            textBox1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 57);
            label1.Name = "label1";
            label1.Size = new Size(81, 20);
            label1.TabIndex = 1;
            label1.Text = "Компания";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(101, 558);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(105, 44);
            btnSave.TabIndex = 0;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 23);
            label4.Name = "label4";
            label4.Size = new Size(108, 20);
            label4.TabIndex = 8;
            label4.Text = "№ ведомости:";
            // 
            // settlementNumber
            // 
            settlementNumber.AutoSize = true;
            settlementNumber.Location = new Point(127, 26);
            settlementNumber.Name = "settlementNumber";
            settlementNumber.Size = new Size(57, 20);
            settlementNumber.TabIndex = 8;
            settlementNumber.Text = "123456";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(6, 310);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(330, 224);
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(127, 6);
            label5.Name = "label5";
            label5.Size = new Size(79, 20);
            label5.TabIndex = 9;
            label5.Text = "02.02.2024";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(76, 3);
            label6.Name = "label6";
            label6.Size = new Size(44, 20);
            label6.TabIndex = 10;
            label6.Text = "Дата:";
            // 
            // dgvSettlement
            // 
            dgvSettlement.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSettlement.Location = new Point(348, 3);
            dgvSettlement.Name = "dgvSettlement";
            dgvSettlement.Size = new Size(765, 742);
            dgvSettlement.TabIndex = 11;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(231, 558);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(105, 44);
            btnClose.TabIndex = 10;
            btnClose.Text = "Закрыть";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // SettlementForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1125, 757);
            Controls.Add(dgvSettlement);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(gpSettlement);
            Controls.Add(settlementNumber);
            Controls.Add(label4);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "SettlementForm";
            Text = "Ведомость";
            gpSettlement.ResumeLayout(false);
            gpSettlement.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSettlement).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox gpSettlement;
        private Button btnSelectCompany;
        private TextBox textBox1;
        private Label label1;
        private Button btnSave;
        private TextBox textBox2;
        private Label label2;
        private TextBox textBox3;
        private Label label3;
        private PictureBox pictureBox1;
        private Label settlementNumber;
        private Label label4;
        private Label label5;
        private Label label6;
        private DataGridView dgvSettlement;
        private Button btnClose;
    }
}