using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vedy.Common.DTOs.CustomerEntry;
using Vedy.Common.DTOs.Settlement;

namespace Vedy.Extensions
{
    public static class GridSettings
    {
        public static void SetSettings(DataGridView dataGridView)
        {
            if (dataGridView.DataSource != null)
            {
                switch (dataGridView.Name)
                {
                    case "dgvSettlement":
                        dataGridView.Columns[nameof(CustomerEntryModel.CompanyName)].HeaderText = GetDisplayName<SettlementModel>(nameof(CustomerEntryModel.CompanyName)) ;
                        dataGridView.Columns[nameof(CustomerEntryModel.FullName)].HeaderText = GetDisplayName<SettlementModel>(nameof(CustomerEntryModel.FullName)) ;
                        dataGridView.Columns[nameof(CustomerEntryModel.CarNumber)].HeaderText = GetDisplayName<SettlementModel>(nameof(CustomerEntryModel.CarNumber)) ;
                        dataGridView.Columns[nameof(CustomerEntryModel.Amount)].HeaderText = GetDisplayName<SettlementModel>(nameof(CustomerEntryModel.Amount)) ;
                        dataGridView.Columns[nameof(CustomerEntryModel.Id)].HeaderText = GetDisplayName<SettlementModel>(nameof(CustomerEntryModel.Id)) ;
                        dataGridView.Columns[nameof(CustomerEntryModel.CreatedDate)].HeaderText = GetDisplayName<SettlementModel>(nameof(CustomerEntryModel.CreatedDate)) ;
                        dataGridView.Columns[nameof(CustomerEntryModel.SettlementDate)].HeaderText = GetDisplayName<SettlementModel>(nameof(CustomerEntryModel.SettlementDate)) ;
                        
                        break;
                }
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
