using AutoMapper;
using ReferenceData.BAL.BusModels;
using ReferenceData.DAL.Model;
namespace ReferenceData.BAL
{
    /// <summary>
    /// Contains mapping settings between business, data and view classes
    /// </summary>
    public static class MapperInitialization
    {
        public static void Init()
        {
            Mapper.CreateMap<User, UserBusModel>().
            ForMember(u => u.Id, m => m.MapFrom(map => map.Id)).
            ForMember(u => u.FirstName, m => m.MapFrom(map => map.FirstName)).
            ForMember(u => u.SecondName, m => m.MapFrom(map => map.SecondName)).
            ForMember(u => u.Subdivision, m => m.MapFrom(map => map.Subdivision == null ? string.Empty : map.Subdivision.Description)).
            ForMember(u => u.Location, m => m.MapFrom(map => map.Location == null ? string.Empty : map.Location.Description)).
            ForMember(u => u.Country, m => m.MapFrom(map => map.Country == null ? string.Empty : map.Country.Description)).
            ForMember(u => u.SubdivisionId, m => m.MapFrom(map => map.Subdivision == null ? (int?)null : map.Subdivision.Id)).
            ForMember(u => u.CountryId, m => m.MapFrom(map => map.Country == null ? (int?)null : map.Country.Id)).
            ForMember(u => u.LocationId, m => m.MapFrom(map => map.Location == null ? (int?)null : map.Location.Id));

            Mapper.CreateMap<UserBusModel, User>().
            ForMember(u => u.Id, m => m.MapFrom(map => map.Id)).
            ForMember(u => u.FirstName, m => m.MapFrom(map => map.FirstName)).
            ForMember(u => u.SecondName, m => m.MapFrom(map => map.SecondName)).
            ForMember(u => u.SubDivisionId, m => m.MapFrom(map => map.SubdivisionId)).
            ForMember(u => u.LocationId, m => m.MapFrom(map => map.LocationId)).
            ForMember(u => u.CountryId, m => m.MapFrom(map => map.CountryId)).
            ForMember(u => u.Country, m => m.MapFrom(map => (Country)null)).
            ForMember(u => u.Location, m => m.MapFrom(map => (Location)null)).
            ForMember(u => u.Subdivision, m => m.MapFrom(map => (Subdivision)null));


            Mapper.CreateMap<UserViewModel, User>().
            ForMember(u => u.Id, m => m.MapFrom(map => map.Id)).
            ForMember(u => u.FirstName, m => m.MapFrom(map => map.FirstName)).
            ForMember(u => u.SecondName, m => m.MapFrom(map => map.SecondName)).
            ForMember(u => u.SubDivisionId, m => m.MapFrom(map => map.subdivisionId)).
            ForMember(u => u.LocationId, m => m.MapFrom(map => map.locationId)).
            ForMember(u => u.CountryId, m => m.MapFrom(map => map.countryId));

            Mapper.CreateMap<User, UserViewModel>().
            ForMember(u => u.Id, m => m.MapFrom(map => map.Id)).
            ForMember(u => u.FirstName, m => m.MapFrom(map => map.FirstName)).
            ForMember(u => u.SecondName, m => m.MapFrom(map => map.SecondName)).
            ForMember(u => u.subdivisionId, m => m.MapFrom(map => map.SubDivisionId)).
            ForMember(u => u.locationId, m => m.MapFrom(map => map.LocationId)).
            ForMember(u => u.countryId, m => m.MapFrom(map => map.CountryId));

            Mapper.CreateMap<UserBusModel, UserViewModel>().
            ForMember(u => u.Id, m => m.MapFrom(map => map.Id)).
            ForMember(u => u.FirstName, m => m.MapFrom(map => map.FirstName)).
            ForMember(u => u.SecondName, m => m.MapFrom(map => map.SecondName)).
            ForMember(u => u.subdivisionId, m => m.MapFrom(map => map.SubdivisionId)).
            ForMember(u => u.locationId, m => m.MapFrom(map => map.LocationId)).
            ForMember(u => u.countryId, m => m.MapFrom(map => map.CountryId));

            Mapper.CreateMap<UserViewModel, UserBusModel>().
            ForMember(u => u.Id, m => m.MapFrom(map => map.Id)).
            ForMember(u => u.FirstName, m => m.MapFrom(map => map.FirstName)).
            ForMember(u => u.SecondName, m => m.MapFrom(map => map.SecondName)).
            ForMember(u => u.SubdivisionId, m => m.MapFrom(map => map.subdivisionId)).
            ForMember(u => u.LocationId, m => m.MapFrom(map => map.locationId)).
            ForMember(u => u.CountryId, m => m.MapFrom(map => map.countryId));


            Mapper.CreateMap<Subdivision, SubdivisionBusModel>().
            ForMember(u => u.Id, m => m.MapFrom(map => map.Id)).
            ForMember(u => u.Description, m => m.MapFrom(map => map.Description));

            Mapper.CreateMap<Country, CountryBusModel>().
            ForMember(u => u.Id, m => m.MapFrom(map => map.Id)).
            ForMember(u => u.Description, m => m.MapFrom(map => map.Description));

            Mapper.CreateMap<Location, LocationBusModel>().
            ForMember(u => u.Id, m => m.MapFrom(map => map.Id)).
            ForMember(u => u.Description, m => m.MapFrom(map => map.Description));
        }
    }
}
