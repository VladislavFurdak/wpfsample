using Microsoft.Practices.Unity;
using ReferenceData.BAL;
using ReferenceData.DAL;
using ReferenceData.ViewModels;

namespace ReferenceData
{
    /// <summary>
    /// Contains registration settings for Unity IoC
    /// </summary>
    public static class Container
    {
        public static void LoadConfiguration(this UnityContainer container)
        {
            container.RegisterType<IMainViewModel, MainViewModel>();

            container.RegisterType<IRepoCountry, CountriesRepo>();
            container.RegisterType<IRepoLocations, LocationsRepo>();
            container.RegisterType<IRepoSubdivision, SubdivisionRepo>();
            container.RegisterType<IRepoUser, UsersRepo>();

            container.RegisterType<IBusCountry, BusCountry>();
            container.RegisterType<IBusLocation, BusLocation>();
            container.RegisterType<IBusSubdivision, BusSubdivision>();
            container.RegisterType<IBusUser, BusUser>();

            container.RegisterType<MainWindow, MainWindow>();
        }
    }
}
