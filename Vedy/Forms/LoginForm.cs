using Vedy.Abstractions;
using Vedy.Cache;
using Vedy.Common.DTOs.Company;
using Vedy.Common.DTOs.Settlement;
using Vedy.Common.DTOs.User;
using Vedy.Extensions;
using Vedy.Forms;
using Vedy.Libs;
using Vedy.Services;
using Vedy.Services.Interfaces;
namespace Vedy
{
    public partial class LoginForm : BaseForm
    {
        private readonly IUserService _userService;
        private readonly SignService _signService;

        public LoginForm(IUserService userService,
            SignService signService)
        {
            InitializeComponent();
            _userService = userService;
            _signService = signService;
        }

        private async void btnEnter_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxUserName.Text) || string.IsNullOrEmpty(tbxPass.Text))
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            var result = await _userService.Login(tbxUserName.Text, tbxPass.Text, TokenExtension.GetToken());

            if (result == null)
            {
                MessageBox.Show("Логин или пароль неправильный");
                return;
            }

            Program.UserId = result.Id;
            Program.Role = result.Role;
            Program.UserName = result.FullName;
            Program.LoggedIn = true;
            DialogResult = DialogResult.OK;
            this.Close();

        }

        private void tbxPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (int)Keys.Enter))
            {
                btnEnter_Click((object)sender, e);
            }
        }

        private async void SettlementForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            await _signService.CloseSign();
        }

        private async void LoginForm_Shown(object sender, EventArgs e)
        {
            await _signService.Connect<LoginForm>(this);
        }
    }
}
