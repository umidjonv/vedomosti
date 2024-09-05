using System.ComponentModel;
using System.Reflection;
using Vedy.Common.DTOs.Company;
using Vedy.Common.DTOs.CustomerEntry;
using Vedy.Common.DTOs.Settlement;

namespace Vedy.Extensions
{
    public static class GridSettings
    {
        public static void SetSettings(this DataGridView dataGridView)
        {
            if (dataGridView.DataSource != null)
            {
                switch (dataGridView.Name)
                {
                    case "dgvSettlement":
                        dataGridView.Columns[nameof(CustomerEntryModel.SettlementDate)].Visible = false;
                        dataGridView.Columns[nameof(CustomerEntryModel.CompanyId)].Visible = false;
                        dataGridView.Columns[nameof(CustomerEntryModel.SettlementId)].Visible = false;
                        dataGridView.Columns[nameof(CustomerEntryModel.SignHash)].Visible = false;
                        
                        break;
                    case "dgvSettlements":
                        dataGridView.Columns[nameof(SettlementModel.UserId)].Visible = false;
                        break;
                    case "dgvCompany":
                        break;
                }
                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
                dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
        }

        private static string GetDisplayName<T>(string propertyName)
        {
            Type type = typeof(T);
            
            // Получаем свойство "Name"
            PropertyInfo property = type.GetProperty(propertyName);

            // Получаем атрибут DisplayName
            DisplayNameAttribute displayNameAttr = (DisplayNameAttribute)Attribute.GetCustomAttribute(property, typeof(DisplayNameAttribute));

            if (displayNameAttr != null)
            {
                return displayNameAttr.DisplayName;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
