using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using OliverCode.Commands;
using System.ComponentModel;
using ReferenceData.DAL.Model;
using ReferenceData.BAL;
using ReferenceData.BAL.BusModels;
using System.Collections.ObjectModel;
using AutoMapper;
using System.Threading;

namespace ReferenceData.ViewModels
{
    /// <summary>
    //  Application main viewmodel
    /// </summary>
    public class MainViewModel : IMainViewModel,  INotifyPropertyChanged
    {
        #region injected services
        /// <summary>
        /// Injected services that can be used in this class and in the appropriate view class
        /// </summary>
        public IBusCountry busCountry { get; private set; }
        public IBusSubdivision busSubdivision { get; private set; }
        public IBusLocation busLocation { get; private set; }
        public IBusUser busUser { get; private set; }
        #endregion

        /// <summary>
        /// Users collection
        /// </summary>
        public ObservableCollection<UserViewModel> UserList { get; set; }

        public Dictionary<int, SubdivisionBusModel> GetSimpleSubdivisionList { get; private set; }
        public Dictionary<int, LocationBusModel> GetSimpleLocationList { get; private set; }
        public Dictionary<int, CountryBusModel> GetSimpleCountryList { get; private set; }
       
        private UserViewModel selected;

        /// <summary>
        /// Indicates if data is currently loading with async operation
        /// </summary>
        private bool contentIsAvaliable = true;

        /// <summary>
        /// Currently selected User item
        /// </summary>
        public UserViewModel SelectedItem
        {
            get
            {
                return selected;
            }
            set
            {
                if (selected == value) 
                    return;
                selected = value;

                if (selected != null)
                    selected.SetNotModified();

                NotifyPropertyChanged("SelectedItem");
            }
        }

        /// <summary>
        /// The event that can be called when we need to update Users grid
        /// </summary>
        public event Action SeekUsersCompleted;

        /// <summary>
        /// Commands for bottom buttons
        /// </summary>
        private DelegateCommand saveCommand;
        private DelegateCommand newCommand;
        private DelegateCommand cancelCommand;

        private bool isDirty;

        #region Commandswrappers
        /// <summary>
        /// Wrapper for the save command
        /// </summary>
        public ICommand SaveCommand
        {
            get
            {
                if (saveCommand == null)
                    saveCommand = new DelegateCommand(new Action(SaveExecuted), new Func<bool>(SaveCanExecute));
                return saveCommand;
            }
        }
        /// <summary>
        /// Wrapper for the new command
        /// </summary>
        public ICommand NewCommand
        {
            get
            {
                if (newCommand == null)
                    newCommand = new DelegateCommand(new Action(NewExecuted), new Func<bool>(NewCanExecute));
                return newCommand;
            }
        }
        /// <summary>
        /// Wrapper for the cancel command
        /// </summary>
        public ICommand CancelCommand
        {
            get
            {
                if (cancelCommand == null)
                    cancelCommand = new DelegateCommand(new Action(CancelExecuted), new Func<bool>(CancelCanExecuted));
                return cancelCommand;
            }
        }
        #endregion Commandswrappers
        /// <summary>
        /// New command execution method
        /// </summary>
        private void NewExecuted()
        {
            SelectedItem = new UserViewModel(this);
            isDirty = true;
        }

        /// <summary>
        /// Save command execution method
        /// </summary>
        private void SaveExecuted()
        {
            try
            {
                if (SelectedItem == null || SelectedItem.Id == 0)
                {
                    var added = busUser.AddBusModel(Mapper.Map<UserBusModel>(SelectedItem));
                    if (added != null)
                    {
                        var mapToViewNew = Mapper.Map(added, new UserViewModel(this));
                        UserList.Add(mapToViewNew);
                        NotifyPropertyChanged("UserList");

                        isDirty = false;
                        SelectedItem = new UserViewModel(this);
                    }
                }
                else
                {
                    var maptoBus = Mapper.Map<UserBusModel>(SelectedItem);
                    var busUpdated = busUser.UpdateBusModel(maptoBus);
                    var mapToViewNew = Mapper.Map(busUpdated, new UserViewModel(this));

                    var item = UserList.FirstOrDefault(x => x.Id == SelectedItem.Id);
                    var index = UserList.IndexOf(item);
                    UserList[index].Apply(mapToViewNew);
                    SelectedItem = UserList[index];
                    isDirty = false;
                }
            }
            catch (ArgumentException)
            {
                System.Windows.MessageBox.Show("Please, input correct values");
            }
            catch
            {
                System.Windows.MessageBox.Show("Unknown error");
            }
        }

        /// <summary>
        /// Cancel command execution method
        /// </summary>
        private void CancelExecuted()
        {
            isDirty = false;
            SelectedItem.Revert();
            NotifyPropertyChanged("SelectedItem");
            if (SelectedItem.isDirty) 
            {
                //double check for location change if subdivision has been changed
                SelectedItem.Revert();
                NotifyPropertyChanged("SelectedItem");
            }
        }
        /// <summary>
        /// Check whether the save command can be executed 
        /// </summary>
        /// <returns></returns>
        private bool SaveCanExecute()
        {
            return contentIsAvaliable && SelectedItem != null && (isDirty || SelectedItem.isDirty);
        }
        /// <summary>
        /// Check whether the new command can be executed 
        /// </summary>
        /// <returns></returns>
        private bool NewCanExecute()
        {
            return contentIsAvaliable;
        }
        /// <summary>
        /// Check whether the cancel command can be executed 
        /// </summary>
        /// <returns></returns>
        private bool CancelCanExecuted()
        {
            return SelectedItem != null && (isDirty || SelectedItem.isDirty);
        }

        /// Need a void constructor in order to use as an object element 
        /// in the XAML.
        public MainViewModel(IBusCountry busCountry, IBusLocation busLocation, IBusSubdivision busSubdivision, IBusUser busUser)
        {
            this.busCountry = busCountry;
            this.busUser = busUser;
            this.busLocation = busLocation;
            this.busSubdivision = busSubdivision;
            this.SelectedItem = new UserViewModel(this);

            GetSimpleCountryList = busCountry.GetSimpleCountryList();
            UserList = new ObservableCollection<UserViewModel>();

            var _dispatcher = System.Windows.Threading.Dispatcher.CurrentDispatcher;
            contentIsAvaliable = false;
            ThreadPool.QueueUserWorkItem(x =>
            {
                var tmp = new ObservableCollection<UserViewModel>();
                foreach (var user in Users)
                {
                    if (user.Id != 0)
                        tmp.Add(new UserViewModel(this).SetUser(user));
                }

                _dispatcher.Invoke(new Action(() =>
                {
                    UserList = tmp;
                    NotifyPropertyChanged("UserList");

                    if (SeekUsersCompleted != null)
                        SeekUsersCompleted();

                    contentIsAvaliable = true;
                }));
            });
        }

        /// <summary>
        /// Returns all users
        /// </summary>
        public IEnumerable<User> Users
        {
            get
            {
                return busUser.GetAll().ToList();
            }
        }

        #region INotifyPropertyChanged Members

        /// Need to implement this interface in order to get data binding
        /// to work properly.
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
