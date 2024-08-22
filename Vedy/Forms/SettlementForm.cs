using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vedy.Common.DTOs.Company;
using Vedy.Services;

namespace Vedy.Forms
{
    public partial class SettlementForm : Form
    {
        public SettlementForm(ICompanyService companyService)
        {
            InitializeComponent();
            _companyService = companyService;
        }


        private readonly ICompanyService _companyService;
        private List<CompanyModel> _companyList;

        public void InitData()
        {
            
        }
        private CancellationToken GetToken()
        {

            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;
            return token;
        }

        private async void SettlementForm_Load(object sender, EventArgs e)
        {
            var companyModels = await _companyService.GetCompanyList(GetToken()).ConfigureAwait(false);
            if (companyModels == null)
            {
                _companyList = new List<CompanyModel>();
            }


        }
    }
}
