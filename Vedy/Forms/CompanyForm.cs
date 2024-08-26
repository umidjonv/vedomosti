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


        private async void CompanyForm_Load(object sender, EventArgs e)
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            companyList = await _companyService.GetCompanyList(tokenSource.Token);
            dgvCompany.DataSource = companyList;
            //dgvCompany.Columns[nameof(CompanyModel.Id)].\
            dgvCompany.Update();
            dgvCompany.Refresh();
            //if (tbxName.DataBindings.Count == 0)
            //    tbxName.DataBindings.Add("Text", _viewModel, "Name", false, DataSourceUpdateMode.OnPropertyChanged);
            //if (tbxTin.DataBindings.Count == 0)
            //    tbxTin.DataBindings.Add("Text", _viewModel, "Tin", false, DataSourceUpdateMode.OnPropertyChanged);

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
            tbxTin.Text = _selectedCompany.TIN;

            //if (company != null)
            //{
            //    _viewModel.SelectedCompany(company);
            //}
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var company = new CompanyModel
            {
                Name = tbxName.Text,
                TIN = tbxTin.Text,
            };

            _selectedCompany = await _companyService.AddCompany(company, TokenExtension.GetToken());
            companyList.Add(_selectedCompany);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbxName.Text = string.Empty;
            tbxTin.Text = string.Empty;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
