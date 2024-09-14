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
            settlementAmount = new TextBox();
            label5 = new Label();
            btnClear = new Button();
            btnClose = new Button();
            pictureBox1 = new PictureBox();
            settlementCar = new TextBox();
            label3 = new Label();
            settlementFullname = new TextBox();
            label2 = new Label();
            btnSelectCompany = new Button();
            settlementCompanyStr = new TextBox();
            label1 = new Label();
            btnSave = new Button();
            label6 = new Label();
            dgvSettlement = new DataGridView();
            settlementDate = new DateTimePicker();
            menuStrip1 = new MenuStrip();
            gpSettlement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSettlement).BeginInit();
            SuspendLayout();
            // 
            // gpSettlement
            // 
            gpSettlement.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            gpSettlement.Controls.Add(settlementAmount);
            gpSettlement.Controls.Add(label5);
            gpSettlement.Controls.Add(btnClear);
            gpSettlement.Controls.Add(btnClose);
            gpSettlement.Controls.Add(pictureBox1);
            gpSettlement.Controls.Add(settlementCar);
            gpSettlement.Controls.Add(label3);
            gpSettlement.Controls.Add(settlementFullname);
            gpSettlement.Controls.Add(label2);
            gpSettlement.Controls.Add(btnSelectCompany);
            gpSettlement.Controls.Add(settlementCompanyStr);
            gpSettlement.Controls.Add(label1);
            gpSettlement.Controls.Add(btnSave);
            gpSettlement.Location = new Point(0, 150);
            gpSettlement.Margin = new Padding(3, 4, 3, 4);
            gpSettlement.Name = "gpSettlement";
            gpSettlement.Padding = new Padding(3, 4, 3, 4);
            gpSettlement.Size = new Size(385, 645);
            gpSettlement.TabIndex = 0;
            gpSettlement.TabStop = false;
            gpSettlement.Text = "Регистрация Авто";
            // 
            // settlementAmount
            // 
            settlementAmount.Location = new Point(108, 213);
            settlementAmount.Name = "settlementAmount";
            settlementAmount.Size = new Size(270, 29);
            settlementAmount.TabIndex = 12;
            settlementAmount.KeyPress += settlementAmount_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 216);
            label5.Name = "label5";
            label5.Size = new Size(80, 21);
            label5.TabIndex = 11;
            label5.Text = "Кубометр";
            // 
            // btnClear
            // 
            btnClear.Location = new Point(260, 425);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(118, 46);
            btnClear.TabIndex = 10;
            btnClear.Text = "Очистить";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(260, 586);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(118, 46);
            btnClose.TabIndex = 10;
            btnClose.Text = "Закрыть";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(7, 248);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(371, 158);
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // settlementCar
            // 
            settlementCar.Location = new Point(108, 163);
            settlementCar.Name = "settlementCar";
            settlementCar.Size = new Size(270, 29);
            settlementCar.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 166);
            label3.Name = "label3";
            label3.Size = new Size(66, 21);
            label3.TabIndex = 6;
            label3.Text = "№ Авто";
            // 
            // settlementFullname
            // 
            settlementFullname.Location = new Point(108, 109);
            settlementFullname.Name = "settlementFullname";
            settlementFullname.Size = new Size(270, 29);
            settlementFullname.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 112);
            label2.Name = "label2";
            label2.Size = new Size(60, 21);
            label2.TabIndex = 4;
            label2.Text = "Клиент";
            // 
            // btnSelectCompany
            // 
            btnSelectCompany.Location = new Point(285, 56);
            btnSelectCompany.Name = "btnSelectCompany";
            btnSelectCompany.Size = new Size(100, 30);
            btnSelectCompany.TabIndex = 3;
            btnSelectCompany.Text = "Выбрать";
            btnSelectCompany.UseVisualStyleBackColor = true;
            btnSelectCompany.Click += btnSelect_Click;
            // 
            // settlementCompanyStr
            // 
            settlementCompanyStr.Location = new Point(108, 57);
            settlementCompanyStr.Name = "settlementCompanyStr";
            settlementCompanyStr.Size = new Size(169, 29);
            settlementCompanyStr.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 60);
            label1.Name = "label1";
            label1.Size = new Size(82, 21);
            label1.TabIndex = 1;
            label1.Text = "Компания";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(135, 425);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(118, 46);
            btnSave.TabIndex = 0;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 25);
            label6.Name = "label6";
            label6.Size = new Size(47, 21);
            label6.TabIndex = 10;
            label6.Text = "Дата:";
            // 
            // dgvSettlement
            // 
            dgvSettlement.BackgroundColor = Color.White;
            dgvSettlement.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSettlement.Location = new Point(391, 3);
            dgvSettlement.Name = "dgvSettlement";
            dgvSettlement.Size = new Size(862, 779);
            dgvSettlement.TabIndex = 11;
            dgvSettlement.CellClick += dgv_CellClick;
            // 
            // settlementDate
            // 
            settlementDate.Format = DateTimePickerFormat.Short;
            settlementDate.Location = new Point(108, 20);
            settlementDate.Name = "settlementDate";
            settlementDate.Size = new Size(145, 29);
            settlementDate.TabIndex = 12;
            settlementDate.ValueChanged += settlementDate_ValueChanged;
            // 
            // menuStrip1
            // 
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(1266, 24);
            menuStrip1.TabIndex = 13;
            menuStrip1.Text = "menuStrip1";
            // 
            // SettlementForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1266, 795);
            Controls.Add(settlementDate);
            Controls.Add(dgvSettlement);
            Controls.Add(label6);
            Controls.Add(gpSettlement);
            Controls.Add(menuStrip1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            Name = "SettlementForm";
            Text = "Добавление записи";
            Shown += SettlementForm_Shown;
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
        private TextBox settlementCompanyStr;
        private Label label1;
        private Button btnSave;
        private TextBox settlementFullname;
        private Label label2;
        private TextBox settlementCar;
        private Label label3;
        private PictureBox pictureBox1;
        private Label label6;
        private DataGridView dgvSettlement;
        private Button btnClose;
        private Button btnClear;
        private DateTimePicker settlementDate;
        private Label label5;
        private TextBox settlementAmount;
        private MenuStrip menuStrip1;
    }
}