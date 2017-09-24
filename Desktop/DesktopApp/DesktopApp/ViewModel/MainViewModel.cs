using System.Collections.Generic;
using System.Linq;
using DesktopApp.DBModel;
using GalaSoft.MvvmLight;

namespace DesktopApp.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            var models = DB.GetModel().Categories.ToList();
            var c = new List<CategoryViewModel>();


            _categories = models.Select(x => new CategoryViewModel(x)).ToList();
        }

        private CategoryViewModel _selected;

        public CategoryViewModel Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
                RaisePropertyChanged(nameof(Selected));
            }
        }

        private IEnumerable<CategoryViewModel> _categories;

        public IEnumerable<CategoryViewModel> Categories
        {
            get
            {
                return _categories;
            }
        }
    }
}