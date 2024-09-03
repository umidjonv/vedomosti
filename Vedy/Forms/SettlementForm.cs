﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Vedy.Cache;
using Vedy.Common.DTOs.Company;
using Vedy.Common.DTOs.CustomerEntry;
using Vedy.Common.DTOs.Settlement;
using Vedy.Extensions;
using Vedy.Models;
using Vedy.Services;

namespace Vedy.Forms
{
    public partial class SettlementForm : Form
    {
        public SettlementForm(
            ICustomerEntryService customerEntryService,
            ISettlementService settlementService,
            CompanyForm companyForm
            )
        {
            InitializeComponent();
            this._customerEntryService = customerEntryService;
            this._settlementService = settlementService;
            _companyForm = companyForm;
            _companyModel = new();
        }

        private readonly ICustomerEntryService _customerEntryService;
        private readonly ISettlementService _settlementService;
        private readonly CompanyForm _companyForm;
        private CompanyModel _companyModel;
        private CustomerEntryModel _selectedEntry;
        private List<CustomerEntryModel> _customerEntryList = new();
        private SettlementModel _settlementModel = new();

        private async Task DgvUpdate()
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            _customerEntryList = await _customerEntryService.GetList(tokenSource.Token);
            dgvSettlement.DataSource = _customerEntryList;
            dgvSettlement.Update();
            dgvSettlement.Refresh();
        }

        private void ClearEntry()
        {
            _selectedEntry = new CustomerEntryModel();

            settlementCompanyStr.Text = string.Empty;
            settlementFullname.Text = string.Empty;
            settlementCar.Text = string.Empty;
            settlementAmount.Text = string.Empty;

        }

        private void SetEntry()
        {
            settlementNumber.Text = _settlementModel.Number;
            settlementDate.Text = _settlementModel.Date.ToString();
            settlementCompanyStr.Text = _selectedEntry.CompanyName;
            settlementFullname.Text = _selectedEntry.FullName;
            settlementCar.Text = _selectedEntry.CarNumber;
            settlementAmount.Text = _selectedEntry.Amount.ToString();
            
        }

        private void GetEntry(bool isNew = false)
        {
            if (isNew)
            {
                _selectedEntry = new CustomerEntryModel() 
                {
                    SettlementNumber = settlementNumber.Text,
                    SettlementDate = DateTime.Parse(settlementDate.Text),
                    CompanyName = settlementCompanyStr.Text,
                    FullName = settlementFullname.Text,
                    CarNumber = settlementCar.Text,
                    SettlementId = _settlementModel.Id.Value,
                    Amount = long.Parse(settlementAmount.Text),
                    CompanyId = _selectedEntry.CompanyId.Value,
                    CreatedDate = DateTime.Now.Date,
                    SignHash = string.Empty,
                };
            }

            
            
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var value = (long)dgvSettlement.Rows[e.RowIndex].Cells["Id"].Value;

            _selectedEntry = _customerEntryList.FirstOrDefault(x => x.Id != null && x.Id == value);

            SetEntry();

        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            GetEntry(true);

            _selectedEntry = await _customerEntryService.Add(_selectedEntry, TokenExtension.GetToken());
            _customerEntryList.Add(_selectedEntry);
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

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (_companyForm.ShowDialog() == DialogResult.OK)
            {
                var result = _companyForm.GetResult();
                _selectedEntry.CompanyId = result.Id;
                _selectedEntry.CompanyName = result.Name;
                SetEntry();
            }
        }

        private async void SettlementForm_Shown(object sender, EventArgs e)
        {
            if (SettlementData.CurrentSettlementId > 0)
                _settlementModel = await _settlementService.GetById(SettlementData.CurrentSettlementId, TokenExtension.GetToken());
            if (_settlementModel != null)
            {
                _customerEntryList = _settlementModel.CustomerEntries ?? new List<CustomerEntryModel>();
                await DgvUpdate();
            }
            ClearEntry();
            SetEntry();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_selectedEntry.Id == null)
            {
                btnAdd_Click(sender, e);
            }else 
            {
                btnUpdate_Click(sender, e);
            }
            ClearEntry();
        }

        private void settlementAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    }
}
