using Vedy.Forms;
using Vedy.Libs;
namespace Vedy
{
    public partial class Main : Form
    {
        public Main(SettlementForm settlementForm)
        {
            InitializeComponent();
            this._settlementForm = settlementForm;
        }
        public STU_Tablet stu_Tablet;
        private readonly SettlementForm _settlementForm;

        private void dgvSettlements_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = (long)dgvCustomer.Rows[e.RowIndex].Cells["Id"].Value;
            _settlementForm.Show();


        }
    }
}
