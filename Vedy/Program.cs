using Autofac;
using System.Windows.Forms;
using Vedy.Common.Enums;
using Vedy.Forms;
using Vedy.Services;

namespace Vedy
{
    internal static class Program
    {
        public static long UserId { get; set; } = 0;
        public static string UserName { get; set; } = string.Empty;
        public static UserRole Role { get; set; } = UserRole.Operator;
        public static bool LoggedIn = false;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 
        private static IContainer Container { get; set; }
        [STAThread]
        static void Main()
        {
            // Create your builder.
            var builder = new ContainerBuilder();

            // Usually you're only interested in exposing the type
            // via its interface:
            builder.RegisterType<NetworkClient>().As<INetworkClient>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<CompanyService>().As<ICompanyService>();
            builder.RegisterType<CustomerEntryService>().As<ICustomerEntryService>();
            builder.RegisterType<SettlementService>().As<ISettlementService>();

            builder.RegisterType<LoginForm>();
            builder.RegisterType<Main>();
            builder.RegisterType<CompanyForm>();
            builder.RegisterType<SettlementForm>();
            builder.RegisterType<SettlementCreateForm>();
            Container = builder.Build();

            using (var scope = Container.BeginLifetimeScope())
            {
                ApplicationConfiguration.Initialize();
                var form = scope.Resolve<LoginForm>();
                Application.Run(form);
                if (Program.LoggedIn)
                {
                    switch (Program.Role)
                    {
                        case UserRole.Administrator:
                            var main = scope.Resolve<Main>();
                            Application.Run(main);
                            break;
                        case UserRole.Operator:
                            var settlementForm = scope.Resolve<SettlementForm>();
                            Application.Run(settlementForm);
                            break;
                    }
                }

                
                
            }
        }
    }
}