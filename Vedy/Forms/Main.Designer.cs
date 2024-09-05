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
            gpSettlements = new GroupBox();
            btnSave = new Button();
            label3 = new Label();
            label2 = new Label();
            dgvSettlements = new DataGridView();
            tbxNumber = new TextBox();
            tbxDate = new TextBox();
            menuStrip1 = new MenuStrip();
            menuMain = new ToolStripMenuItem();
            menuSettlement = new ToolStripMenuItem();
            gpSettlements.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSettlements).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // gpSettlements
            // 
            gpSettlements.Controls.Add(btnSave);
            gpSettlements.Controls.Add(label3);
            gpSettlements.Controls.Add(label2);
            gpSettlements.Controls.Add(dgvSettlements);
            gpSettlements.Controls.Add(tbxNumber);
            gpSettlements.Controls.Add(tbxDate);
            gpSettlements.Location = new Point(9, 24);
            gpSettlements.Margin = new Padding(3, 4, 3, 4);
            gpSettlements.Name = "gpSettlements";
            gpSettlements.Padding = new Padding(3, 4, 3, 4);
            gpSettlements.Size = new Size(861, 548);
            gpSettlements.TabIndex = 1;
            gpSettlements.TabStop = false;
            gpSettlements.Text = "Ведомости";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(156, 139);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(105, 44);
            btnSave.TabIndex = 7;
            btnSave.Text = "Скачать";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnDownload_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 94);
            label3.Name = "label3";
            label3.Size = new Size(60, 20);
            label3.TabIndex = 6;
            label3.Text = "Номер:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 38);
            label2.Name = "label2";
            label2.Size = new Size(48, 20);
            label2.TabIndex = 6;
            label2.Text = "Дата: ";
            // 
            // dgvSettlements
            // 
            dgvSettlements.Anchor = AnchorStyles.Top;
            dgvSettlements.BackgroundColor = Color.White;
            dgvSettlements.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSettlements.Location = new Point(278, 23);
            dgvSettlements.Margin = new Padding(3, 4, 3, 4);
            dgvSettlements.Name = "dgvSettlements";
            dgvSettlements.Size = new Size(577, 512);
            dgvSettlements.TabIndex = 3;
            dgvSettlements.CellClick += dgv_CellClick;
            dgvSettlements.CellDoubleClick += dgvSettlements_CellDoubleClick;
            // 
            // tbxNumber
            // 
            tbxNumber.BackColor = Color.White;
            tbxNumber.Location = new Point(72, 94);
            tbxNumber.Name = "tbxNumber";
            tbxNumber.ReadOnly = true;
            tbxNumber.Size = new Size(189, 27);
            tbxNumber.TabIndex = 5;
            // 
            // tbxDate
            // 
            tbxDate.BackColor = Color.White;
            tbxDate.Location = new Point(72, 38);
            tbxDate.Name = "tbxDate";
            tbxDate.ReadOnly = true;
            tbxDate.Size = new Size(189, 27);
            tbxDate.TabIndex = 5;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuMain });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(873, 24);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuMain
            // 
            menuMain.DropDownItems.AddRange(new ToolStripItem[] { menuSettlement });
            menuMain.Name = "menuMain";
            menuMain.Size = new Size(79, 20);
            menuMain.Text = "Ведомости";
            // 
            // menuSettlement
            // 
            menuSettlement.Name = "menuSettlement";
            menuSettlement.Size = new Size(180, 22);
            menuSettlement.Text = "Новая ведомость";
            menuSettlement.Click += menuSettlement_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(873, 572);
            Controls.Add(gpSettlements);
            Controls.Add(menuStrip1);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Main";
            Text = "Главная";
            FormClosed += Main_FormClosed;
            Load += Main_Load;
            gpSettlements.ResumeLayout(false);
            gpSettlements.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSettlements).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox gpSettlements;
        private DataGridView dgvSettlements;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuMain;
        private ToolStripMenuItem menuSettlement;
        private Label label3;
        private Label label2;
        private TextBox tbxNumber;
        private TextBox tbxDate;
        private Button btnSave;
    }
}
