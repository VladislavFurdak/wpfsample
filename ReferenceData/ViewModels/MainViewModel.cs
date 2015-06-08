using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using OliverCode.Commands;
using System.ComponentModel;
using ReferenceData.DAL.Model;
using ReferenceData.BAL;
using ReferenceData.BAL.BusModels;
using System.Collections.ObjectModel;
using AutoMapper;

namespace ReferenceData.ViewModels
{

    public interface IMainViewModel
    {
    }

    /// <summary>
    //  Application main viewmodel
    /// </summary>
    public class MainViewModel : IMainViewModel,  INotifyPropertyChanged
    {
        #region injected services
        /// <summary>
        /// Injected services that can be used in this class and in the appropriate view class
        /// </summary>
        public readonly IBusCountry busCountry;
        public readonly IBusSubdivision busSubdivision;
        public readonly IBusLocation busLocation;
        public readonly IBusUser busUser;
        #endregion

        /// <summary>
        /// Collection that binds to main grid
        /// </summary>
        public ObservableCollection<UserViewModel> userList;

        public Dictionary<int, SubdivisionBusModel> getSimpleSubdivisionList;
        public Dictionary<int, LocationBusModel> getSimpleLocationList;
        public Dictionary<int, CountryBusModel> getSimpleCountryList;
        /// <summary>
        /// The event that can be called when we need to update Users grid
        /// </summary>
        public event Action RefreshGrid;
       
        private UserViewModel selected;

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
                selected = value;
                if (selected != null)
                selected.SetNotModified();
                NotifyPropertyChanged("SelectedItem");
            }
        }

        /// <summary>
        /// Fired after the binding has stopped
        /// </summary>
        public event Action GridBindingComplete;

        /// <summary>
        /// Commands for bottom buttons
        /// </summary>
        private DelegateCommand saveCommand;
        private DelegateCommand newCommand;
        private DelegateCommand cancelCommand;

        private bool isDirty;

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

        /// <summary>
        /// New command execution method
        /// </summary>
        private void NewExecuted()
        {
            SelectedItem = new UserViewModel(this);

            NotifyPropertyChanged("SelectedItem");
            isDirty = true;
        }

        /// <summary>
        /// Save command execution method
        /// </summary>
        private void SaveExecuted()
        {
                if (SelectedItem == null || SelectedItem.Id == 0)
                {
                    var added = busUser.AddBusModel(Mapper.Map<UserBusModel>(SelectedItem));
                    if (added != null)
                    {
                        var mapToViewNew = Mapper.Map(added, new UserViewModel(this));
                        userList.Add(mapToViewNew);
                        isDirty = false;
                        RefreshGrid();
                    }
                }
                else
                {
                    var maptoBus = Mapper.Map<UserBusModel>(SelectedItem);
                    var busUpdated = busUser.UpdateBusModel(maptoBus);
                    var mapToViewNew = Mapper.Map(busUpdated, new UserViewModel(this));

                    var item = userList.FirstOrDefault(x=>x.Id == SelectedItem.Id);
                    var index = userList.IndexOf(item);
                    userList[index].Apply(mapToViewNew);
                    SelectedItem = userList[index];
                    isDirty = false;
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
        }
        /// <summary>
        /// Check whether the save command can be executed 
        /// </summary>
        /// <returns></returns>
        private bool SaveCanExecute()
        {
            return SelectedItem != null && (isDirty || SelectedItem.isDirty);
        }
        /// <summary>
        /// Check whether the new command can be executed 
        /// </summary>
        /// <returns></returns>
        private bool NewCanExecute()
        {
            return true;
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

        /// <summary>
        /// Returns users wrapper into UserViewModel in ObservableCollection
        /// </summary>
        public ObservableCollection<UserViewModel> GetSimpleUserList
        {
            get
            {
                if (userList == null)
                {
                    userList = new ObservableCollection<UserViewModel>();
                    foreach (var user in Users)
                    {
                        if (user.Id != 0)
                            userList.Add(new UserViewModel(this).SetUser(user));
                    }
                }
                 GridBindingComplete();
                 return userList;
            }
            set
            {
                userList = value;
            }
        }

        /// <summary>
        /// Returns all subdivisions
        /// </summary>
        public Dictionary<int, SubdivisionBusModel> GetSimpleSubdivisionList
        {
            get
            {
                return getSimpleSubdivisionList;
            }
        }

        /// <summary>
        /// Returns all locations
        /// </summary>
        public Dictionary<int, LocationBusModel> GetSimpleLocationList
        {
            get
            {
                return getSimpleLocationList;
            }
        }

        /// <summary>
        /// Returns all countries
        /// </summary>
        public Dictionary<int, CountryBusModel> GetSimpleCountryList
        {
            get
            {
                if (getSimpleCountryList == null) getSimpleCountryList = busCountry.GetSimpleCountryList();

                return getSimpleCountryList;
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
