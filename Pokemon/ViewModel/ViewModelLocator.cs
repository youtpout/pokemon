/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:Toolkit_Pokemon_Go"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using Navegar.Libs.Interfaces;
using Navegar.XamarinForms;
using Pokemon.View;

namespace Pokemon.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            //Enregistrement de Navegar dans l'IOC
            SimpleIoc.Default.Register<INavigation, Navigation>();

            //Liaisons entre les ViewModels et les Views
            ServiceLocator.Current.GetInstance<INavigation>().RegisterView<PokedexViewModel, PokedexPage>();
        }

        //public  MainViewModel Main
        //{
        //    get
        //    {
        //        return ServiceLocator.Current.GetInstance<MainViewModel>();
        //    }
        //}

        //public PokedexViewModel Pokedex {

        //    get
        //    {
        //        return ServiceLocator.Current.GetInstance<PokedexViewModel>();
        //    }
        //}

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}