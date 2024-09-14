namespace Vedy
{
    partial class Main
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
            GpCompanies = new GroupBox();
            lblSearchCompany = new Label();
            tbxSearchCompany = new TextBox();
            btnCreate = new Button();
            dgvCompanies = new DataGridView();
            groupBox1 = new GroupBox();
            label2 = new Label();
            tbxSearchSettlement = new TextBox();
            btnDownload = new Button();
            dgvSettlement = new DataGridView();
            GpCompanies.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCompanies).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSettlement).BeginInit();
            SuspendLayout();
            // 
            // GpCompanies
            // 
            GpCompanies.Controls.Add(lblSearchCompany);
            GpCompanies.Controls.Add(tbxSearchCompany);
            GpCompanies.Controls.Add(btnCreate);
            GpCompanies.Controls.Add(dgvCompanies);
            GpCompanies.Location = new Point(12, 14);
            GpCompanies.Margin = new Padding(4, 5, 4, 5);
            GpCompanies.Name = "GpCompanies";
            GpCompanies.Padding = new Padding(4, 5, 4, 5);
            GpCompanies.Size = new Size(496, 701);
            GpCompanies.TabIndex = 1;
            GpCompanies.TabStop = false;
            GpCompanies.Text = "Компании";
            // 
            // lblSearchCompany
            // 
            lblSearchCompany.AutoSize = true;
            lblSearchCompany.Location = new Point(8, 40);
            lblSearchCompany.Name = "lblSearchCompany";
            lblSearchCompany.Size = new Size(70, 25);
            lblSearchCompany.TabIndex = 9;
            lblSearchCompany.Text = "Поиск:";
            // 
            // tbxSearchCompany
            // 
            tbxSearchCompany.Location = new Point(85, 37);
            tbxSearchCompany.Margin = new Padding(4);
            tbxSearchCompany.Name = "tbxSearchCompany";
            tbxSearchCompany.Size = new Size(294, 33);
            tbxSearchCompany.TabIndex = 8;
            tbxSearchCompany.KeyPress += tbxSearchCompany_KeyPress;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(387, 37);
            btnCreate.Margin = new Padding(4);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(100, 33);
            btnCreate.TabIndex = 7;
            btnCreate.Text = "Создать";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreateSettlement_Click;
            // 
            // dgvCompanies
            // 
            dgvCompanies.Anchor = AnchorStyles.Top;
            dgvCompanies.BackgroundColor = Color.White;
            dgvCompanies.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCompanies.Location = new Point(8, 97);
            dgvCompanies.Margin = new Padding(4, 5, 4, 5);
            dgvCompanies.Name = "dgvCompanies";
            dgvCompanies.Size = new Size(479, 574);
            dgvCompanies.TabIndex = 3;
            dgvCompanies.CellClick += dgv_CompanyCellClick;
            dgvCompanies.CellDoubleClick += dgvCompany_CellDoubleClick;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(tbxSearchSettlement);
            groupBox1.Controls.Add(btnDownload);
            groupBox1.Controls.Add(dgvSettlement);
            groupBox1.Location = new Point(527, 14);
            groupBox1.Margin = new Padding(4, 5, 4, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 5, 4, 5);
            groupBox1.Size = new Size(524, 701);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ведомости";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 42);
            label2.Name = "label2";
            label2.Size = new Size(70, 25);
            label2.TabIndex = 9;
            label2.Text = "Поиск:";
            // 
            // tbxSearchSettlement
            // 
            tbxSearchSettlement.Location = new Point(85, 37);
            tbxSearchSettlement.Margin = new Padding(4);
            tbxSearchSettlement.Name = "tbxSearchSettlement";
            tbxSearchSettlement.Size = new Size(292, 33);
            tbxSearchSettlement.TabIndex = 8;
            // 
            // btnDownload
            // 
            btnDownload.Location = new Point(385, 37);
            btnDownload.Margin = new Padding(4);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(131, 33);
            btnDownload.TabIndex = 7;
            btnDownload.Text = "Скачать";
            btnDownload.UseVisualStyleBackColor = true;
            // 
            // dgvSettlement
            // 
            dgvSettlement.Anchor = AnchorStyles.Top;
            dgvSettlement.BackgroundColor = Color.White;
            dgvSettlement.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSettlement.Location = new Point(12, 97);
            dgvSettlement.Margin = new Padding(4, 5, 4, 5);
            dgvSettlement.Name = "dgvSettlement";
            dgvSettlement.Size = new Size(504, 574);
            dgvSettlement.TabIndex = 3;
            dgvSettlement.CellClick += dgvSettlement_CellClick;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1060, 715);
            Controls.Add(groupBox1);
            Controls.Add(GpCompanies);
            Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Main";
            Text = "Главная";
            FormClosed += Main_FormClosed;
            Load += Main_Load;
            GpCompanies.ResumeLayout(false);
            GpCompanies.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCompanies).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSettlement).EndInit();
            ResumeLayout(false);
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
    }
}
