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

        public void SelectedCompany(CompanyModel company)
        {
            _company = company;
            OnPropertyChanged(nameof(CompanyModel.Name));
            OnPropertyChanged(nameof(CompanyModel.Tin));
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
                    //OnPropertyChanged(nameof(CompanyModel.Id));
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
                    //OnPropertyChanged(nameof(CompanyModel.Name));
                }
            }
        }

        public string Tin
        {
            get { return _company.Tin; }
            set
            {
                if (_company.Tin == value)
                {
                    _company.Tin = value;
                    OnPropertyChanged(nameof(CompanyModel.Tin));
                }
            }
        }

        protected void OnPropertyChanged(string propertyName) 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
