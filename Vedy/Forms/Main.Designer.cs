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
            dgvSettlements = new DataGridView();
            dgvCustomer = new DataGridView();
            gpCustomer = new GroupBox();
            label1 = new Label();
            searchClients = new TextBox();
            menuStrip1 = new MenuStrip();
            клиентыToolStripMenuItem = new ToolStripMenuItem();
            gpSettlements.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSettlements).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCustomer).BeginInit();
            gpCustomer.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // gpSettlements
            // 
            gpSettlements.Controls.Add(dgvSettlements);
            gpSettlements.Dock = DockStyle.Right;
            gpSettlements.Location = new Point(368, 24);
            gpSettlements.Margin = new Padding(3, 4, 3, 4);
            gpSettlements.Name = "gpSettlements";
            gpSettlements.Padding = new Padding(3, 4, 3, 4);
            gpSettlements.Size = new Size(941, 811);
            gpSettlements.TabIndex = 1;
            gpSettlements.TabStop = false;
            gpSettlements.Text = "Ведомости";
            // 
            // dgvSettlements
            // 
            dgvSettlements.Anchor = AnchorStyles.Top;
            dgvSettlements.BackgroundColor = Color.White;
            dgvSettlements.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSettlements.Location = new Point(6, 36);
            dgvSettlements.Margin = new Padding(3, 4, 3, 4);
            dgvSettlements.Name = "dgvSettlements";
            dgvSettlements.Size = new Size(929, 795);
            dgvSettlements.TabIndex = 3;
            dgvSettlements.CellDoubleClick += dgvSettlements_CellDoubleClick;
            // 
            // dgvCustomer
            // 
            dgvCustomer.Anchor = AnchorStyles.Top;
            dgvCustomer.BackgroundColor = Color.White;
            dgvCustomer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomer.Location = new Point(6, 68);
            dgvCustomer.Margin = new Padding(3, 4, 3, 4);
            dgvCustomer.Name = "dgvCustomer";
            dgvCustomer.Size = new Size(349, 763);
            dgvCustomer.TabIndex = 2;
            // 
            // gpCustomer
            // 
            gpCustomer.Controls.Add(label1);
            gpCustomer.Controls.Add(searchClients);
            gpCustomer.Controls.Add(dgvCustomer);
            gpCustomer.Dock = DockStyle.Left;
            gpCustomer.Location = new Point(0, 24);
            gpCustomer.Margin = new Padding(3, 4, 3, 4);
            gpCustomer.Name = "gpCustomer";
            gpCustomer.Padding = new Padding(3, 4, 3, 4);
            gpCustomer.Size = new Size(361, 811);
            gpCustomer.TabIndex = 2;
            gpCustomer.TabStop = false;
            gpCustomer.Text = "Клиенты";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 30);
            label1.Name = "label1";
            label1.Size = new Size(55, 20);
            label1.TabIndex = 4;
            label1.Text = "Поиск:";
            // 
            // searchClients
            // 
            searchClients.Location = new Point(77, 27);
            searchClients.Name = "searchClients";
            searchClients.Size = new Size(278, 27);
            searchClients.TabIndex = 3;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { клиентыToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1309, 24);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // клиентыToolStripMenuItem
            // 
            клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
            клиентыToolStripMenuItem.Size = new Size(136, 20);
            клиентыToolStripMenuItem.Text = "Компании и клиенты";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1309, 835);
            Controls.Add(gpCustomer);
            Controls.Add(gpSettlements);
            Controls.Add(menuStrip1);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Main";
            Text = "Главная";
            gpSettlements.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSettlements).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCustomer).EndInit();
            gpCustomer.ResumeLayout(false);
            gpCustomer.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox gpSettlements;
        private DataGridView dgvCustomer;
        private GroupBox gpCustomer;
        private Label label1;
        private TextBox searchClients;
        private DataGridView dgvSettlements;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem клиентыToolStripMenuItem;
    }
}
