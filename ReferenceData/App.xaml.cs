using Microsoft.Practices.Unity;
using ReferenceData.BAL;
using System.Windows;

namespace ReferenceData
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        void App_Startup(object sender, StartupEventArgs e)
        {
            base.OnStartup(e);
            UnityContainer.Resolve<MainWindow>().Show();
        }

        public static UnityContainer UnityContainer
        {
            get
            {
                if (App.Current.Properties["UnityContainer"] == null)
                {
                    UnityContainer unityContainer = new UnityContainer();
                    unityContainer.LoadConfiguration();
                    MapperInitialization.Init();
                    App.Current.Properties["UnityContainer"] = unityContainer;
                }
                return (UnityContainer)App.Current.Properties["UnityContainer"];
            }
        }
    }

}
