using Humanizer;
using Vedy.Common.DTOs.CustomerEntry;
using Vedy.Common.DTOs.Settlement;
using Vedy.Extensions;
using Vedy.Services.Interfaces;

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
                var dates = GetStartAndEndDate();
                var settlement = await _settlementService.Add(new SettlementModel
                {
                    Number = tbxSettlementNumber.Text.Trim(),
                    Date = DateTime.Now,
                    CompanyId = CompanyId,
                    UserId = Program.UserId,
                    StartDate = dates.start,
                    EndDate = dates.end,
                    
                }, TokenExtension.GetToken());

                await _customerEntryService.Update(_customerEntryModels, settlement.Id.Value, TokenExtension.GetToken());
                DialogResult = DialogResult.OK;
                this.Close();
            }
            
        }
        
        private void LoadMonths()
        {
            // Add the months to the dropdown
            cmbMonth.Items.Add($"Январь {GetYear(1)}");
            cmbMonth.Items.Add($"Февраль {GetYear(2)}");
            cmbMonth.Items.Add($"Март {GetYear(3)}");
            cmbMonth.Items.Add($"Апрель {GetYear(4)}");
            cmbMonth.Items.Add($"Май {GetYear(5)}");
            cmbMonth.Items.Add($"Июнь {GetYear(6)}");
            cmbMonth.Items.Add($"Июль {GetYear(7)}");
            cmbMonth.Items.Add($"Август {GetYear(8)}");
            cmbMonth.Items.Add($"Сентябрь {GetYear(9)}");
            cmbMonth.Items.Add($"Октябрь {GetYear(10)}");
            cmbMonth.Items.Add($"Ноябрь {GetYear(11)}");
            cmbMonth.Items.Add($"Декабрь {GetYear(12)}");
        }

        private int GetYear(int selectedMonth)
        {
            var year = DateTime.Now.Year;

            if (selectedMonth > DateTime.Now.Month)
            {
                year--;
            };
            return year;
        }

        private (DateTime start, DateTime end) GetStartAndEndDate()
        {
            var selectedMonth = cmbMonth.SelectedIndex;
            var year = GetYear(selectedMonth);

            DateTime startDate = new DateTime(year, selectedMonth + 1, 1, 0, 0, 0);
            DateTime endDate = startDate.AddMonths(+1).AddDays(-1).AddHours(23).AddMinutes(59).AddSeconds(59);

            return (start:startDate, end:endDate);
        }

        private async void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedMonth = cmbMonth.SelectedIndex;
            var year = GetYear(selectedMonth);

            DateTime startDate = new DateTime(year, selectedMonth + 1, 1, 0,0,0);
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
