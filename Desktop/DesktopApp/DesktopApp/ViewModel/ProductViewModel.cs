using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopApp.DBModel;
using GalaSoft.MvvmLight;

namespace DesktopApp.ViewModel
{
    class ProductViewModel : ViewModelBase
    {
        private readonly Product _model;

        public ProductViewModel(Product model)
        {
            _model = model;
        }
        public int ID
        {
            get
            {
                return _model.ID;
            }
        }
        public string Name
        {
            get
            {
                return _model.Name;
            }
        }
    }
}
