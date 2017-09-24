using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using DesktopApp.DBModel;
using GalaSoft.MvvmLight;

namespace DesktopApp.ViewModel
{
   public class CategoryViewModel : ViewModelBase
    {
        private readonly Category _model;

        public CategoryViewModel(Category model)
        {
            _model = model;
          
        }

        public short ID
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

        public IEnumerable<Product> Products
        {
            get
            {
                return GetProducts();
            }
        }

        static MemoryCache cache = MemoryCache.Default;
        private IEnumerable<Product> GetProducts()
        {
    
         var c=   cache.Contains(_model.ID.ToString());
            if (!c)
            {
                cache.Add(_model.ID.ToString(), _model.Products,DateTime.Now.AddHours(1));
            }
            return (IEnumerable<Product>)cache.Get(_model.ID.ToString());
        }
    }
}
