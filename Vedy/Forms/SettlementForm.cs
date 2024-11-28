using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Vedy.Abstractions;
using Vedy.Cache;
using Vedy.Common;
using Vedy.Common.DTOs.Company;
using Vedy.Common.DTOs.CustomerEntry;
using Vedy.Common.DTOs.Settlement;
using Vedy.Common.DTOs.Sign;
using Vedy.Extensions;
using Vedy.Models;
using Vedy.Services;
using Vedy.Services.Interfaces;

namespace Vedy.Forms
{
    public partial class SettlementForm : BaseForm
    {
        public SettlementForm(
            ICustomerEntryService customerEntryService,
            ISettlementService settlementService,
            IConfigService configService,
            CompanyForm companyForm,
            SettlementCreateForm settlementCreateForm,
            SignService signService
            )
        {
            InitializeComponent();
            this._customerEntryService = customerEntryService;
            this._settlementService = settlementService;
            this._configService = configService;
            _companyForm = companyForm;
            this._settlementCreateForm = settlementCreateForm;
            this._signService = signService;
            _companyModel = new();


        }

        private readonly ICustomerEntryService _customerEntryService;
        private readonly ISettlementService _settlementService;
        private readonly IConfigService _configService;
        private readonly CompanyForm _companyForm;
        private readonly SettlementCreateForm _settlementCreateForm;
        private readonly SignService _signService;
        private CompanyModel _companyModel;
        private AppConfig appConfig;
        private CustomerEntryModel _selectedEntry;
        private List<CustomerEntryModel> _customerEntryList = new();

        private async Task DgvUpdate()
        {
            var startDate = settlementDate.Value.Date;
            var endDate = settlementDate.Value.Date.AddDays(1);

            CancellationTokenSource tokenSource = new CancellationTokenSource();
            _customerEntryList = await _customerEntryService.GetByDate(
                startDate, endDate, tokenSource.Token);
            dgvSettlement.DataSource = _customerEntryList;

            if (dgvSettlement.DataSource != null)
            {
                dgvSettlement.SetSettings();
            }
            dgvSettlement.Update();
            dgvSettlement.Refresh();
        }

        private void ClearEntry()
        {
            settlementCompanyStr.Text = _selectedEntry.CompanyId == null ? string.Empty : _selectedEntry.CompanyName;

            _selectedEntry = new CustomerEntryModel()
            {
                CompanyId = _selectedEntry == null ? null : _selectedEntry.CompanyId,
            };

            settlementFullname.Text = string.Empty;
            settlementCar.Text = string.Empty;
            settlementAmount.Text = "0";
            settlementSum.Text = "0";

        }

        private void SetEntry()
        {
            settlementCompanyStr.Text = _selectedEntry.CompanyName;
            settlementFullname.Text = _selectedEntry.FullName;
            settlementCar.Text = _selectedEntry.CarNumber;
            settlementAmount.Text = _selectedEntry.Amount.ToString();
            settlementSum.Text = (_selectedEntry.Amount * appConfig.Tarif).ToString();

        }

        private void GetEntry(bool isNew = false)
        {
            if (isNew)
            {
                _selectedEntry = new CustomerEntryModel()
                {
                    Id = _selectedEntry.Id,
                    SettlementDate = DateTime.Parse(settlementDate.Text),
                    CompanyName = settlementCompanyStr.Text,
                    FullName = settlementFullname.Text,
                    CarNumber = settlementCar.Text,
                    Amount = long.Parse(settlementAmount.Text),
                    Sum = long.Parse(settlementSum.Text),
                    CompanyId = _selectedEntry.CompanyId.Value,
                    CreatedDate = DateTime.Now.Date,
                    SignHash = string.Empty,
                };
            }

        }

        private async void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var value = (long)dgvSettlement.Rows[e.RowIndex].Cells["Id"].Value;

            _selectedEntry = _customerEntryList.FirstOrDefault(x => x.Id != null && x.Id == value);

            SetEntry();
            //await DgvUpdate();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            GetEntry(true);

            _selectedEntry = await _customerEntryService.Add(_selectedEntry, TokenExtension.GetToken());
            //_customerEntryList.Add(_selectedEntry);
            await DgvUpdate();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearEntry();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedEntry.Id != null)
            {
                var id = await _customerEntryService.Delete(_selectedEntry.Id.Value, TokenExtension.GetToken());
                await DgvUpdate();
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            GetEntry(true);

            await _customerEntryService.Update(_selectedEntry, TokenExtension.GetToken());
            await DgvUpdate();
        }

        private async void btnSelect_Click(object sender, EventArgs e)
        {
            if (_companyForm.ShowDialog() == DialogResult.OK)
            {
                var result = _companyForm.GetResult();
                //_selectedEntry = new CustomerEntryModel();

                if (_selectedEntry == null)
                {
                    _selectedEntry = new CustomerEntryModel() { CreatedDate = DateTime.Now };
                }
                _selectedEntry.CompanyId = result.Id;
                _selectedEntry.CompanyName = result.Name;

                await DgvUpdate();
                SetEntry();
            }
        }

        private async void SettlementForm_Shown(object sender, EventArgs e)
        {
            appConfig = await _configService.GetConfig(TokenExtension.GetToken());

            await _signService.Connect<SettlementForm>(this, SignMethod);

            //if (SettlementData.CurrentSettlementId <= 0)
            //{
            //    //if (_settlementCreateForm.ShowDialog() == DialogResult.OK)
            //    //{
            //    //    var newSettlement = await _settlementService.Add(new SettlementModel
            //    //    {
            //    //        Number = _settlementCreateForm.GetName(),
            //    //        Date = DateTimeOffset.Now.ToUniversalTime(),
            //    //    }, TokenExtension.GetToken());
            //    //    SettlementData.CurrentSettlementId = newSettlement.Id.Value;
            //    //}
            //}
            //_settlementModel = await _settlementService.GetById(SettlementData.CurrentSettlementId, TokenExtension.GetToken());

            //if (_settlementModel != null)
            //{
            //    //_customerEntryList = _settlementModel.CustomerEntries ?? new List<CustomerEntryModel>();
            //    await DgvUpdate();
            //}
            //ClearEntry();
            //SetEntry();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            SettlementData.CurrentSettlementId = 0;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Сохранить?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (_selectedEntry.Id == null)
                {
                    btnAdd_Click(sender, e);
                }
                else
                {
                    btnUpdate_Click(sender, e);
                }
                await DgvUpdate();
                ClearEntry();
            }
        }

        private void settlementAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            settlementSum.Text = $"{long.Parse(settlementAmount.Text) * appConfig.Tarif}";
        }

        private async void settlementDate_ValueChanged(object sender, EventArgs e)
        {
            await DgvUpdate();
        }

        private async void btnSign_Click(object sender, EventArgs e)
        {
            await _signService.StartSign(new SignModel());
        }

        public async Task SignMethod(SignModelResponse model)
        {

        }

        private async void SettlementForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
