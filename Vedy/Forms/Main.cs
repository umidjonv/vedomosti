using Vedy.Cache;
using Vedy.Common.DTOs.Company;
using Vedy.Common.DTOs.Settlement;
using Vedy.Extensions;
using Vedy.Forms;
using Vedy.Libs;
using Vedy.Services;
namespace Vedy
{
    public partial class Main : Form
    {
        public Main(ICompanyService companyService, ICustomerEntryService customerEntryService,
            ISettlementService settlementService, SettlementCreateForm settlementCreateForm)
        {
            InitializeComponent();
            _companyService = companyService;
            this._customerEntryService = customerEntryService;
            this._settlementService = settlementService;
            this._settlementCreateForm = settlementCreateForm;
        }
        public STU_Tablet stu_Tablet;
        private readonly ICompanyService _companyService;
        private readonly ICustomerEntryService _customerEntryService;
        private readonly ISettlementService _settlementService;
        private SettlementCreateForm _settlementCreateForm;
        private List<CompanyModel> _companyList;
        private CompanyModel _selectedCompany = new CompanyModel();

        private List<SettlementModel> _settlementList;
        private SettlementModel _settlementModel;
        private async Task DgvUpdate()
        {
            _companyList = await _companyService.GetCompanyList(TokenExtension.GetToken());
            dgvCompanies.DataSource = _companyList.Filter(tbxSearchCompany.Text);

            if (dgvCompanies.DataSource != null)
            {
                dgvCompanies.SetSettings();
            }
        }

        private void dgvSettlements_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = (long)dgvCompanies.Rows[e.RowIndex].Cells["Id"].Value;
            SettlementData.CurrentSettlementId = id;


        }

        #region Company Actions
        private async void dgv_CompanyCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var value = (long)dgvCompanies.Rows[e.RowIndex].Cells["Id"].Value;

            var model = _companyList.FirstOrDefault(x => x.Id != null && x.Id == value);

            if (model is not null)
                _selectedCompany = model;

        }

        private async void btnCreateSettlement_Click(object sender, EventArgs e)
        {
            if (dgvCompanies.SelectedRows.Count > 0)
            {
                _settlementCreateForm = new SettlementCreateForm(_customerEntryService, _settlementService);
                _settlementCreateForm.CompanyId = _selectedCompany.Id;

                if (_settlementCreateForm.CompanyId > 0)
                {
                    dgv_CompanyCellClick(dgvCompanies, new DataGridViewCellEventArgs(dgvCompanies.SelectedRows[0].Cells["Id"].ColumnIndex, dgvCompanies.SelectedRows[0].Index));

                    _settlementCreateForm.ShowDialog();

                    await DgvUpdate();
                }

            }

        }

        private void dgvCompany_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnCreateSettlement_Click(sender, new EventArgs());
        }
        #endregion

        private void menuSettlement_Click(object sender, EventArgs e)
        {

        }

        private async void Main_Load(object sender, EventArgs e)
        {
            await DgvUpdate();
        }



        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (_settlementModel != null && saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                PdfService pdfService = new PdfService();
                pdfService.CreateFile(_settlementModel, saveFileDialog.FileName);
            }
        }



        private void dgvSettlement_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void tbxSearchCompany_KeyPress(object sender, KeyPressEventArgs e)
        {
            await DgvUpdate();
        }
    }
}
