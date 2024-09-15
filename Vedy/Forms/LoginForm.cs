using Vedy.Cache;
using Vedy.Common.DTOs.Company;
using Vedy.Common.DTOs.Settlement;
using Vedy.Extensions;
using Vedy.Forms;
using Vedy.Libs;
using Vedy.Services.Interfaces;
namespace Vedy
{
    public partial class LoginForm : Form
    {
        private readonly IUserService _userService;

        public LoginForm(IUserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }

        private async void btnEnter_Click(object sender, EventArgs e)
        {
            var result = await _userService.Login(tbxUserName.Text, tbxPass.Text, TokenExtension.GetToken());

            if (result == null) 
            {
                MessageBox.Show("Логин или пароль неправильный");
            }

            Program.UserId = result.Id;
            Program.Role = result.Role;
            Program.UserName = result.FullName;
            Program.LoggedIn = true;
            DialogResult = DialogResult.OK;
            this.Close();
            
        }
    }
}
