using GalaSoft.MvvmLight;
using Microsoft.Practices.ServiceLocation;
using Navegar.Libs.Class;
using Pokemon.Resx;
using Pokemon.View;
using Pokemon.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using INavigation = Navegar.Libs.Interfaces.INavigation;

namespace Pokemon
{
    public partial class App : Application
    {


        private static readonly Lazy<ViewModelLocator> lazy = new Lazy<ViewModelLocator>(() => new ViewModelLocator());

        public static ViewModelLocator Locator { get; set; }

        public App()
        {
            //On génére en premier le ViewModelLocator pour pouvoir utiliser le ServiceLocator tout de suite aprés
            Locator = new ViewModelLocator();

            var ci = DependencyService.Get<ILocale>().GetCurrentCultureInfo();
            L10n.SetLocale(ci);
            AppResources.Culture = ci;

            //Définition de la page de demarrage de l'application
            MainPage = (NavigationPage)ServiceLocator.Current.GetInstance<INavigation>().InitializeRootFrame<MainViewModel, MainPage>();          

            //Evenements de navigation
            ServiceLocator.Current.GetInstance<INavigation>().PreviewNavigate += PreviewNavigate;
            ServiceLocator.Current.GetInstance<INavigation>().NavigationCanceledOnPreviewNavigate +=
                OnNavigationCanceledOnPreviewNavigate;
        }

        private bool PreviewNavigate(ViewModelBase currentViewModelInstance, Type currentViewModel, Type viewModelToNavigate, out PreNavigationArgs preNavigationArgs)
        {
           
            preNavigationArgs = null;
            return true;
        }

        /// <summary>
        /// Se déclenche lorsque la pré-navigation a échoué car la fonction identifiée n'est pas satisfait aux condiditions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OnNavigationCanceledOnPreviewNavigate(object sender, EventArgs args)
        {
            //On revient à l'écran de login
            ServiceLocator.Current.GetInstance<INavigation>().Clear();
            ServiceLocator.Current.GetInstance<INavigation>().NavigateTo<MainViewModel>(true);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
