using Vedy.Services;

namespace Vedy.Forms
{
    public partial class SettlementCreateForm : Form
    {
        private readonly ISettlementService _settlementService;

        public SettlementCreateForm()
        {
            InitializeComponent();
        }

        public string GetName()
        {
            return tbxName.Text;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbxName.Text))
            {
                DialogResult = DialogResult.OK;
                this.Close(); 
            }
        }
    }
}
