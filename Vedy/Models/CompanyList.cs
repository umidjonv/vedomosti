using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vedy.Models
{
    public class CompanyList
    {
        public CompanyList(List<CompanyModel> companyModels) 
        {
            _companyModels = companyModels;
        }
        private int _currentIndex = 0;
        private List<CompanyModel> _companyModels;

        public void Add(CompanyModel companyModel)
        { _companyModels.Add(companyModel); }

        public void Remove(CompanyModel companyModel)
        { _companyModels.Remove(companyModel); }

        public CompanyModel CurrentModel 
        {
            get { return _companyModels[_currentIndex]; }
        }

        public CompanyModel MoveNext()
        {
            if (_currentIndex < _companyModels.Count-1)
            {
                _currentIndex++;
            }
            return _companyModels[_currentIndex];
        }

        public CompanyModel MovePrevious()
        {
            if (_currentIndex > 1)
                _currentIndex--;
            return _companyModels[_currentIndex];
        }

        
    }

}
