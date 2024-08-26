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
            dgvCompany.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCompany.Location = new Point(5, 115);
            dgvCompany.Name = "dgvCompany";
            dgvCompany.Size = new Size(576, 333);
            dgvCompany.TabIndex = 12;
            dgvCompany.CellClick += dgvCompany_CellClick;
            // 
            // gpSettlement
            // 
            gpSettlement.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            gpSettlement.Controls.Add(btnClear);
            gpSettlement.Controls.Add(btnDelete);
            gpSettlement.Controls.Add(btnAdd);
            gpSettlement.Controls.Add(tbxTin);
            gpSettlement.Controls.Add(label2);
            gpSettlement.Controls.Add(btnClose);
            gpSettlement.Controls.Add(tbxName);
            gpSettlement.Controls.Add(label1);
            gpSettlement.Controls.Add(btnSave);
            gpSettlement.Location = new Point(5, 3);
            gpSettlement.Margin = new Padding(3, 4, 3, 4);
            gpSettlement.Name = "gpSettlement";
            gpSettlement.Padding = new Padding(3, 4, 3, 4);
            gpSettlement.Size = new Size(576, 105);
            gpSettlement.TabIndex = 13;
            gpSettlement.TabStop = false;
            gpSettlement.Text = "Компания ";
            // 
            // btnClear
            // 
            btnClear.Location = new Point(479, 58);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(91, 29);
            btnClear.TabIndex = 13;
            btnClear.Text = "Очистить";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(382, 23);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(91, 29);
            btnDelete.TabIndex = 12;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(479, 23);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(91, 29);
            btnAdd.TabIndex = 11;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // tbxTin
            // 
            tbxTin.Location = new Point(123, 79);
            tbxTin.Name = "tbxTin";
            tbxTin.Size = new Size(182, 23);
            tbxTin.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 79);
            label2.Name = "label2";
            label2.Size = new Size(30, 15);
            label2.TabIndex = 4;
            label2.Text = "Инн";
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
            // tbxName
            // 
            tbxName.Location = new Point(123, 36);
            tbxName.Name = "tbxName";
            tbxName.Size = new Size(182, 23);
            tbxName.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 40);
            label1.Name = "label1";
            label1.Size = new Size(90, 15);
            label1.TabIndex = 1;
            label1.Text = "Имя компании";
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
            // CompanyForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(585, 460);
            Controls.Add(gpSettlement);
            Controls.Add(dgvCompany);
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
    }
}