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
            dgvSettlement = new DataGridView();
            gpSettlement = new GroupBox();
            btnClose = new Button();
            tbxTin = new TextBox();
            label2 = new Label();
            tbxName = new TextBox();
            label1 = new Label();
            btnSave = new Button();
            btnAdd = new Button();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSettlement).BeginInit();
            gpSettlement.SuspendLayout();
            SuspendLayout();
            // 
            // dgvSettlement
            // 
            dgvSettlement.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSettlement.Location = new Point(5, -1);
            dgvSettlement.Name = "dgvSettlement";
            dgvSettlement.Size = new Size(576, 449);
            dgvSettlement.TabIndex = 12;
            // 
            // gpSettlement
            // 
            gpSettlement.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            gpSettlement.Controls.Add(btnDelete);
            gpSettlement.Controls.Add(btnAdd);
            gpSettlement.Controls.Add(btnClose);
            gpSettlement.Controls.Add(tbxTin);
            gpSettlement.Controls.Add(label2);
            gpSettlement.Controls.Add(tbxName);
            gpSettlement.Controls.Add(label1);
            gpSettlement.Controls.Add(btnSave);
            gpSettlement.Location = new Point(587, -1);
            gpSettlement.Margin = new Padding(3, 4, 3, 4);
            gpSettlement.Name = "gpSettlement";
            gpSettlement.Padding = new Padding(3, 4, 3, 4);
            gpSettlement.Size = new Size(317, 465);
            gpSettlement.TabIndex = 13;
            gpSettlement.TabStop = false;
            gpSettlement.Text = "Компания ";
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
            // tbxTin
            // 
            tbxTin.Location = new Point(119, 136);
            tbxTin.Name = "tbxTin";
            tbxTin.Size = new Size(176, 23);
            tbxTin.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 137);
            label2.Name = "label2";
            label2.Size = new Size(30, 15);
            label2.TabIndex = 4;
            label2.Text = "Инн";
            // 
            // tbxName
            // 
            tbxName.Location = new Point(113, 54);
            tbxName.Name = "tbxName";
            tbxName.Size = new Size(182, 23);
            tbxName.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 58);
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
            // btnAdd
            // 
            btnAdd.Location = new Point(220, 420);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(91, 29);
            btnAdd.TabIndex = 11;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(123, 420);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(91, 29);
            btnDelete.TabIndex = 12;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // CompanyForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(908, 460);
            Controls.Add(gpSettlement);
            Controls.Add(dgvSettlement);
            Name = "CompanyForm";
            Text = "CompanyForm";
            ((System.ComponentModel.ISupportInitialize)dgvSettlement).EndInit();
            gpSettlement.ResumeLayout(false);
            gpSettlement.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvSettlement;
        private GroupBox gpSettlement;
        private Button btnDelete;
        private Button btnAdd;
        private Button btnClose;
        private TextBox tbxTin;
        private Label label2;
        private TextBox tbxName;
        private Label label1;
        private Button btnSave;
    }
}