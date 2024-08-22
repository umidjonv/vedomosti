using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Vedy.Models;
using Vedy.Common.DTOs.Company;

namespace Vedy.ViewModels
{
    internal class CompanyViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private CompanyModel _company;

        public CompanyViewModel()
        {
            _company = new CompanyModel();
        }
        
        public CompanyViewModel(CompanyModel company)
        {
            _company = company;
        }

        public long Id
        {
            get { return _company.Id; }
            set
            {
                if (_company.Id == value)
                {
                    _company.Id = value;
                    OnPropertyChanged(nameof(CompanyModel.Id));
                }
            }
        }

        public string Name
        {
            get { return _company.Name; }
            set
            {
                if (_company.Name == value)
                {
                    _company.Name = value;
                    OnPropertyChanged(nameof(CompanyModel.Name));
                }
            }
        }

        public string Tin
        {
            get { return _company.TIN; }
            set
            {
                if (_company.TIN == value)
                {
                    _company.TIN = value;
                    OnPropertyChanged(nameof(CompanyModel.TIN));
                }
            }
        }

        protected void OnPropertyChanged(string propertyName) 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
