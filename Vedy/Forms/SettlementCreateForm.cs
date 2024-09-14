using Vedy.Common.DTOs.CustomerEntry;
using Vedy.Common.DTOs.Settlement;
using Vedy.Extensions;
using Vedy.Services;

namespace Vedy.Forms
{
    public partial class SettlementCreateForm : Form
    {
        private readonly ISettlementService _settlementService;
        private readonly ICustomerEntryService _customerEntryService;
        public long CompanyId { get; set; }
        public SettlementCreateForm(ICustomerEntryService customerEntryService, ISettlementService settlementService)
        {
            InitializeComponent();
            _customerEntryService = customerEntryService;
            _settlementService = settlementService;
            LoadMonths(); // Call the method to load the months dropdown
            
            cmbMonth.SelectedIndexChanged += cmbMonth_SelectedIndexChanged; // Attach event handler for selected index change
        }

        private List<CustomerEntryModel> _customerEntryModels = new();

        private async Task DgvUpdate()
        {
            dgvCustomerEntries.DataSource = _customerEntryModels;
            dgvCustomerEntries.Update();
            dgvCustomerEntries.Refresh();
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            if (_customerEntryModels.Count > 0)
            {
                //var ids = _customerEntryModels.Where(x => x.Id != null).Select(x => x.Id.Value).AsEnumerable();
                
                var settlement = await _settlementService.Add(new SettlementModel
                {
                    Number = $"{Guid.NewGuid()}",
                    Date = DateTime.Now.ToUniversalTime(),
                    
                }, TokenExtension.GetToken());

                await _customerEntryService.Update(_customerEntryModels, settlement.Id.Value, TokenExtension.GetToken());
                DialogResult = DialogResult.OK;
                this.Close();
            }
            
        }
        
        private void LoadMonths()
        {
            // Add the months to the dropdown
            cmbMonth.Items.Add("Январь");
            cmbMonth.Items.Add("Февраль");
            cmbMonth.Items.Add("Март");
            cmbMonth.Items.Add("Апрель");
            cmbMonth.Items.Add("Май");
            cmbMonth.Items.Add("Июнь");
            cmbMonth.Items.Add("Июль");
            cmbMonth.Items.Add("Август");
            cmbMonth.Items.Add("Сентябрь");
            cmbMonth.Items.Add("Октябрь");
            cmbMonth.Items.Add("Ноябрь");
            cmbMonth.Items.Add("Декабрь");
        }

        private async void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedMonth = cmbMonth.SelectedIndex;
            var year = DateTime.Now.Year;

            if (selectedMonth > DateTime.Now.Month)
            {
                year--;
            }

            DateTime startDate = new DateTime(year, selectedMonth + 1, 1, 0,0,0,DateTimeKind.Utc);
            DateTime endDate = startDate.AddMonths(+1).AddDays(-1).AddHours(23).AddMinutes(59).AddSeconds(59);

            lblDateRange.Text = $"Период: {startDate.ToShortDateString()} - {endDate.ToShortDateString()}";

            _customerEntryModels = await _customerEntryService.GetByDate(startDate, endDate, TokenExtension.GetToken());
            _customerEntryModels = _customerEntryModels.Where(x=>x.CompanyId == CompanyId).ToList();
            await DgvUpdate();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            ////_customerEntryService.Update()
            //DialogResult = DialogResult.OK;
            //this.Close();

        }
    }
}
