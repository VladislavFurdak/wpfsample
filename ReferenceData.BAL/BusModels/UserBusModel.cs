using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceData.BAL.BusModels
{
    public class UserBusModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Subdivision { get; set; }
        public string Location { get; set; }
        public string Country { get; set; }

        public int? SubdivisionId { get; set; }
        public int? LocationId { get; set; }
        public int? CountryId { get; set; }

        public bool IsValid
        {
            get
            {
                return !((string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(SecondName) || CountryId == null));
            }
        }
    }
}
