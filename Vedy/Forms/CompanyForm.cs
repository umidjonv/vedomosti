using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vedy.Common.DTOs.Company;
using Vedy.Extensions;
using Vedy.Services;
using Vedy.ViewModels;

namespace Vedy.Forms
{
    public partial class CompanyForm : Form
    {
        private readonly ICompanyService _companyService;
        private CompanyViewModel _viewModel;
        public CompanyForm(ICompanyService companyService)
        {
            InitializeComponent();
            _companyService = companyService;
            _viewModel = new CompanyViewModel();

        }

        private List<CompanyModel> companyList = new List<CompanyModel>();
        private CompanyModel _selectedCompany;
        private async Task DgvUpdate()
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            companyList = await _companyService.GetCompanyList(tokenSource.Token);
            dgvCompany.DataSource = companyList;
            dgvCompany.Update();
            dgvCompany.Refresh();
        }


        private async void CompanyForm_Load(object sender, EventArgs e)
        {
            await DgvUpdate();

        }

        private void dgvCompany_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var value = (long)dgvCompany.Rows[e.RowIndex].Cells["Id"].Value;

            _selectedCompany = companyList.FirstOrDefault(x => x.Id == value);

            tbxName.Text = _selectedCompany.Name;
            tbxTin.Text = _selectedCompany.Tin;

        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var company = new CompanyModel
            {
                Name = tbxName.Text,
                Tin = tbxTin.Text,
            };

            _selectedCompany = await _companyService.AddCompany(company, TokenExtension.GetToken());
            companyList.Add(_selectedCompany);
            await DgvUpdate();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbxName.Text = string.Empty;
            tbxTin.Text = string.Empty;
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var id = await _companyService.Delete(_selectedCompany.Id, TokenExtension.GetToken());
            await DgvUpdate();
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            var company = new CompanyModel
            {
                Id = _selectedCompany.Id,
                Name = tbxName.Text,
                Tin = tbxTin.Text,
            };

            await _companyService.UpdateCompany(company, TokenExtension.GetToken());
            await DgvUpdate();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        public CompanyModel GetResult()
        {
            return _selectedCompany;
        }

        private void dgvCompany_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
