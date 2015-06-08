using Microsoft.Practices.Unity;
using ReferenceData.BAL;
using ReferenceData.BAL.BusModels;
using ReferenceData.Validation;
using ReferenceData.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReferenceData.View
{
    /// <summary>
    /// Interaction logic for UserView.xaml
    /// </summary>
    public partial class UserView : UserControl
    {
        MainViewModel viewModel;

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            this.DataContext = App.UnityContainer.Resolve<MainViewModel>();
            viewModel = (MainViewModel)this.DataContext;
            viewModel.GridBindingComplete += () => this.Dispatcher.Invoke(()=>this.progress.Visibility = Visibility.Hidden);
            viewModel.RefreshGrid += Refresh;
        }

        public UserView()
        {
            InitializeComponent();
            this.Country.SelectionChanged += OnCountryChanged;
            this.Subdivision.SelectionChanged += OnSubdivChanged;
        }
        /// <summary>
        /// Method for DataGrid refresh from ViewModel 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Refresh()
        {
            this.Dispatcher.Invoke(() =>
            {
                BindingOperations.GetBindingExpressionBase(this.UserGrid,DataGrid.SelectedItemProperty).UpdateTarget();
            });
        }
        /// <summary>
        /// Fiered when Country dropdown has been selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCountryChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender != null && (sender as ComboBox).SelectedItem != null)
            {
                var item = (KeyValuePair<int, CountryBusModel>)(sender as ComboBox).SelectedItem;
                var context = this.DataContext as MainViewModel;

                if (context == null || context.SelectedItem == null) return;

                context.SelectedItem.countryId = item.Value.Id;

                var subdivisions = context.busSubdivision.GetAllByCountryId(item.Key).ToDictionary(x => x.Id);
                this.Subdivision.ItemsSource = subdivisions;
                context.NotifyPropertyChanged("SelectedItem");
            }
        }
        /// <summary>
        /// Fiered when Subdivision dropdown has been selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSubdivChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender != null && (sender as ComboBox).SelectedItem != null)
            {
                var item = (KeyValuePair<int, SubdivisionBusModel>)(sender as ComboBox).SelectedItem;
                var context = this.DataContext as MainViewModel;
                if (context == null || context.SelectedItem == null) return;

                context.SelectedItem._subdivisionId = item.Value.Id;

                var locations = context.busLocation.GetBySubdivisionId(item.Key).ToDictionary(x => x.Id);
                this.Location.ItemsSource = locations;
            }
        }
     
    }
    }

