namespace Vedy.Forms
{
    partial class SettlementCreateForm
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
            btnCreate = new Button();
            lblDateRange = new Label();
            dgvCustomerEntries = new DataGridView();
            btnSelect = new Button();
            cmbMonth = new ComboBox();
            label1 = new Label();
            tbxSettlementNumber = new TextBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvCustomerEntries).BeginInit();
            SuspendLayout();
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(829, 6);
            btnCreate.Margin = new Padding(4);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(195, 38);
            btnCreate.TabIndex = 1;
            btnCreate.Text = "Создать ведомость";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // lblDateRange
            // 
            lblDateRange.AutoSize = true;
            lblDateRange.Location = new Point(4, 54);
            lblDateRange.Name = "lblDateRange";
            lblDateRange.Size = new Size(87, 28);
            lblDateRange.TabIndex = 4;
            lblDateRange.Text = "Период:";
            // 
            // dgvCustomerEntries
            // 
            dgvCustomerEntries.Anchor = AnchorStyles.Top;
            dgvCustomerEntries.BackgroundColor = Color.White;
            dgvCustomerEntries.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomerEntries.Location = new Point(5, 87);
            dgvCustomerEntries.Margin = new Padding(4, 5, 4, 5);
            dgvCustomerEntries.Name = "dgvCustomerEntries";
            dgvCustomerEntries.RowHeadersWidth = 51;
            dgvCustomerEntries.Size = new Size(1161, 418);
            dgvCustomerEntries.TabIndex = 6;
            // 
            // btnSelect
            // 
            btnSelect.Location = new Point(269, 10);
            btnSelect.Margin = new Padding(4);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(106, 35);
            btnSelect.TabIndex = 7;
            btnSelect.Text = "Выбрать";
            btnSelect.UseVisualStyleBackColor = true;
            btnSelect.Click += btnSelect_Click;
            // 
            // cmbMonth
            // 
            cmbMonth.FormattingEnabled = true;
            cmbMonth.Location = new Point(86, 10);
            cmbMonth.Name = "cmbMonth";
            cmbMonth.Size = new Size(176, 36);
            cmbMonth.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(5, 13);
            label1.Name = "label1";
            label1.Size = new Size(75, 28);
            label1.TabIndex = 9;
            label1.Text = "Месяц:";
            // 
            // tbxSettlementNumber
            // 
            tbxSettlementNumber.Location = new Point(578, 8);
            tbxSettlementNumber.Name = "tbxSettlementNumber";
            tbxSettlementNumber.Size = new Size(186, 34);
            tbxSettlementNumber.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(401, 13);
            label2.Name = "label2";
            label2.Size = new Size(182, 28);
            label2.TabIndex = 9;
            label2.Text = "Номер ведомости:";
            // 
            // SettlementCreateForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1166, 551);
            Controls.Add(tbxSettlementNumber);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmbMonth);
            Controls.Add(btnSelect);
            Controls.Add(dgvCustomerEntries);
            Controls.Add(lblDateRange);
            Controls.Add(btnCreate);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SettlementCreateForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Создание ведомости";
            ((System.ComponentModel.ISupportInitialize)dgvCustomerEntries).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnCreate;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private Label lblDateRange;
        private DataGridView dgvCustomerEntries;
        private Label label2;
        private Button btnSelect;
        private ComboBox cmbMonth;
        private Label label1;
        private TextBox tbxSettlementNumber;
    }
}