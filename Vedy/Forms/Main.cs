using Vedy.Cache;
using Vedy.Extensions;
using Vedy.Forms;
using Vedy.Libs;
using Vedy.Services;
namespace Vedy
{
    public partial class Main : Form
    {
        public Main(SettlementForm settlementForm, ISettlementService settlementService)
        {
            InitializeComponent();
            this._settlementForm = settlementForm;
            _settlementService = settlementService;
        }
        public STU_Tablet stu_Tablet;
        private readonly SettlementForm _settlementForm;
        private readonly ISettlementService _settlementService;

        private void dgvSettlements_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = (long)dgvSettlements.Rows[e.RowIndex].Cells["Id"].Value;
            SettlementData.CurrentSettlementId = id;
            _settlementForm.Show();


        }

        private void menuSettlement_Click(object sender, EventArgs e)
        {
            _settlementForm.Show();
        }

        private async void Main_Load(object sender, EventArgs e)
        {
            dgvSettlements.DataSource = await _settlementService.GetList(TokenExtension.GetToken());
        }
    }
}
