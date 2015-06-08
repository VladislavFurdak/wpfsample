using ReferenceData.DAL.Model;
using ReferenceData.ViewModels;
using System.ComponentModel;

namespace ReferenceData.BAL.BusModels
{
    public class UserViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Old fields to keep previous state of the entity
        /// </summary>
        public int? countryIdOld;
        public int? locationIdOld;
        public int? subdivisionIdOld;
        public string FirstNameOld;
        public string SecondNameOld;
        public string CountryOld;
        public string SubdivisionOld;
        public string LocationOld;

        /// <summary>
        /// Shows is the entity was modified
        /// </summary>
        public bool isDirty
        {
            get
            {
                return !(countryIdOld == countryId &&
                        locationIdOld == locationId &&
                        subdivisionIdOld == SubdivisionId &&
                        FirstNameOld == FirstName &&
                        SecondNameOld == SecondName);
            }
        }

        /// <summary>
        /// Makes copy of one instance of entity in other one
        /// </summary>
        /// <param name="u"></param>
        public void Apply(UserViewModel u)
        {
            this.countryId = u.countryId;
            this.locationId = u.locationId;
            this.SubdivisionId = u.SubdivisionId;
            this.FirstName = u.FirstName;
            this.SecondName = u.SecondName;

            this.Country = u.Country;
            this.Subdivision = u.Subdivision;
            this.Location = u.Location;

            SetNotModified();
            NotifyPropertyChanged("CountryId");
            NotifyPropertyChanged("SubdivisionId");
            NotifyPropertyChanged("LocationId");
            NotifyPropertyChanged("FirstName");
            NotifyPropertyChanged("SecondName");
            NotifyPropertyChanged("Country");
            NotifyPropertyChanged("Subdivision");
            NotifyPropertyChanged("Location");
        }
        /// <summary>
        /// makes entity instance not modified
        /// </summary>
        public void SetNotModified()
        {
            countryIdOld = countryId;
            locationIdOld = locationId;
            subdivisionIdOld = SubdivisionId;
            FirstNameOld = FirstName;
            SecondNameOld = SecondName;
            CountryOld = Country;
            SubdivisionOld = Subdivision;
            LocationOld = Location;
        }

        /// <summary>
        /// Sets previous values that were set earlier
        /// </summary>
        public void Revert()
        {
            countryId = countryIdOld;
            locationId = locationIdOld;
            SubdivisionId = subdivisionIdOld;
            FirstName = FirstNameOld;
            SecondName = SecondNameOld;
            Country = CountryOld;
            Subdivision = SubdivisionOld;
            Location = LocationOld;
        }
        /// <summary>
        /// Entity fields that contains main information about User
        /// </summary>
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Subdivision { get; set; }
        public string Location { get; set; }
        public string Country { get; set; }

        public int? countryId { get; set; }

        public int? locationId { get; set; }

        public int? subdivisionId { get; set; }

        public int? LocationId
        {
            get
            {
                return locationId;
            }
            set
            {
                locationId = value;
                NotifyPropertyChanged("LocationId");
            }
        }

        public int? SubdivisionId
        {
            get
            {
                return subdivisionId;
            }
            set
            {
                subdivisionId = value;
                NotifyPropertyChanged("SubdivisionId");
   
            }
        }

        public int? CountryId
        {
            get
            {
                return countryId;
            }
            set
            {
                countryId = value;
                NotifyPropertyChanged("CountryId");
            }
        }

        private MainViewModel context;
        public UserViewModel(MainViewModel context)
        {
            this.context = context;
        }
         
        /// <summary>
        /// Copy information from the User instance to the UserViewModel instance
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public UserViewModel SetUser(User u)
        {
            this.Id = u.Id;
            this.subdivisionId = u.SubDivisionId;
            this.countryId = u.CountryId;
            this.FirstName = u.FirstName;
            this.SecondName = u.SecondName;
            this.locationId = u.LocationId;
            this.Country = u.Country == null ? string.Empty : u.Country.Description; 
            this.Subdivision = u.Subdivision == null ? string.Empty : u.Subdivision.Description;
            this.Location = u.Location == null ? string.Empty : u.Location.Description;
            return this;
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
