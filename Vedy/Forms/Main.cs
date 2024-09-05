using Vedy.Cache;
using Vedy.Common.DTOs.Settlement;
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
        private SettlementModel _settlementModel = new SettlementModel();
        private List<SettlementModel> _settlementModels = new List<SettlementModel>();
        private readonly ISettlementService _settlementService;

        private void SetModel()
        {
            tbxDate.Text = _settlementModel.Date.ToString("dd.MM.yyyy");
            tbxNumber.Text = _settlementModel.Number;
        }

        private void dgvSettlements_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = (long)dgvSettlements.Rows[e.RowIndex].Cells["Id"].Value;
            SettlementData.CurrentSettlementId = id;
            _settlementForm.ShowDialog();


        }

        private void menuSettlement_Click(object sender, EventArgs e)
        {
            _settlementForm.Show();
        }

        private async void Main_Load(object sender, EventArgs e)
        {
            _settlementModels = await _settlementService.GetList(TokenExtension.GetToken());
            dgvSettlements.DataSource = _settlementModels;
            if (dgvSettlements.DataSource != null)
            {
                dgvSettlements.SetSettings();
            }
        }

        private async void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var value = (long)dgvSettlements.Rows[e.RowIndex].Cells["Id"].Value;

            _settlementModel = _settlementModels.FirstOrDefault(x => x.Id != null && x.Id == value);

            SetModel();
            //await DgvUpdate();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (_settlementModel != null)
            {
                
            }
        }
    }
}
