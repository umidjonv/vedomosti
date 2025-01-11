namespace Vedy.Forms
{
    partial class CompanyForm
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
            dgvCompany = new DataGridView();
            gpSettlement = new GroupBox();
            btnSelect = new Button();
            button1 = new Button();
            btnClear = new Button();
            btnDelete = new Button();
            btnAdd = new Button();
            tbxTin = new TextBox();
            label2 = new Label();
            btnClose = new Button();
            tbxName = new TextBox();
            label1 = new Label();
            btnSave = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCompany).BeginInit();
            gpSettlement.SuspendLayout();
            SuspendLayout();
            // 
            // dgvCompany
            // 
            dgvCompany.AllowUserToAddRows = false;
            dgvCompany.AllowUserToDeleteRows = false;
            dgvCompany.AllowUserToOrderColumns = true;
            dgvCompany.AllowUserToResizeColumns = false;
            dgvCompany.AllowUserToResizeRows = false;
            dgvCompany.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvCompany.BackgroundColor = Color.White;
            dgvCompany.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCompany.Location = new Point(8, 214);
            dgvCompany.Margin = new Padding(4, 6, 4, 6);
            dgvCompany.Name = "dgvCompany";
            dgvCompany.RowHeadersWidth = 51;
            dgvCompany.Size = new Size(969, 622);
            dgvCompany.TabIndex = 12;
            dgvCompany.CellClick += dgvCompany_CellClick;
            dgvCompany.CellDoubleClick += dgvCompany_CellDoubleClick;
            // 
            // gpSettlement
            // 
            gpSettlement.Controls.Add(btnSelect);
            gpSettlement.Controls.Add(button1);
            gpSettlement.Controls.Add(btnClear);
            gpSettlement.Controls.Add(btnDelete);
            gpSettlement.Controls.Add(btnAdd);
            gpSettlement.Controls.Add(tbxTin);
            gpSettlement.Controls.Add(label2);
            gpSettlement.Controls.Add(btnClose);
            gpSettlement.Controls.Add(tbxName);
            gpSettlement.Controls.Add(label1);
            gpSettlement.Controls.Add(btnSave);
            gpSettlement.Location = new Point(8, 6);
            gpSettlement.Margin = new Padding(4, 7, 4, 7);
            gpSettlement.Name = "gpSettlement";
            gpSettlement.Padding = new Padding(4, 7, 4, 7);
            gpSettlement.Size = new Size(969, 196);
            gpSettlement.TabIndex = 13;
            gpSettlement.TabStop = false;
            gpSettlement.Text = "Компания ";
            // 
            // btnSelect
            // 
            btnSelect.Location = new Point(509, 62);
            btnSelect.Margin = new Padding(4, 6, 4, 6);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(296, 55);
            btnSelect.TabIndex = 15;
            btnSelect.Text = "Выбрать";
            btnSelect.UseVisualStyleBackColor = true;
            btnSelect.Click += btnSelect_Click;
            // 
            // button1
            // 
            button1.Location = new Point(661, 134);
            button1.Margin = new Padding(4, 6, 4, 6);
            button1.Name = "button1";
            button1.Size = new Size(143, 55);
            button1.TabIndex = 14;
            button1.Text = "Обновить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnUpdate_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(811, 62);
            btnClear.Margin = new Padding(4, 6, 4, 6);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(143, 55);
            btnClear.TabIndex = 13;
            btnClear.Text = "Очистить";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(814, 134);
            btnDelete.Margin = new Padding(4, 6, 4, 6);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(143, 55);
            btnDelete.TabIndex = 12;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(509, 134);
            btnAdd.Margin = new Padding(4, 6, 4, 6);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(143, 55);
            btnAdd.TabIndex = 11;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // tbxTin
            // 
            tbxTin.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbxTin.Location = new Point(194, 140);
            tbxTin.Margin = new Padding(4, 6, 4, 6);
            tbxTin.Name = "tbxTin";
            tbxTin.Size = new Size(283, 38);
            tbxTin.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 147);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(51, 28);
            label2.TabIndex = 4;
            label2.Text = "Инн";
            // 
            // btnClose
            // 
            btnClose.Location = new Point(363, 1042);
            btnClose.Margin = new Padding(4, 6, 4, 6);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(165, 83);
            btnClose.TabIndex = 10;
            btnClose.Text = "Закрыть";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // tbxName
            // 
            tbxName.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbxName.Location = new Point(194, 67);
            tbxName.Margin = new Padding(4, 6, 4, 6);
            tbxName.Name = "tbxName";
            tbxName.Size = new Size(283, 38);
            tbxName.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 74);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(150, 28);
            label1.TabIndex = 1;
            label1.Text = "Имя компании";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(158, 1042);
            btnSave.Margin = new Padding(4, 6, 4, 6);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(165, 83);
            btnSave.TabIndex = 0;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // CompanyForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(980, 858);
            Controls.Add(gpSettlement);
            Controls.Add(dgvCompany);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 6, 4, 6);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CompanyForm";
            Text = "CompanyForm";
            Load += CompanyForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCompany).EndInit();
            gpSettlement.ResumeLayout(false);
            gpSettlement.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvCompany;
        private GroupBox gpSettlement;
        private Button btnDelete;
        private Button btnAdd;
        private Button btnClose;
        private TextBox tbxTin;
        private Label label2;
        private TextBox tbxName;
        private Label label1;
        private Button btnSave;
        private Button btnClear;
        private Button button1;
        private Button btnSelect;
    }
}