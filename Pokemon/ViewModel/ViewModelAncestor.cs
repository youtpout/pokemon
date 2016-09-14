using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Navegar.Libs.Enums;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.ServiceLocation;
using Navegar.Libs.Interfaces;

namespace Pokemon.ViewModel
{
    public class ViewModelAncestor : ViewModelBase
    {
        #region properties

        /// <summary>
        /// Permet de retourner l'instance en cours de la navigation Navegar
        /// </summary>
        public INavigation NavigationService
        {
            get { return ServiceLocator.Current.GetInstance<INavigation>(); }
        }

        /// <summary>
        /// Indique si l'application est de type Windows et non Windows Phone
        /// </summary>
        private bool _isWindowsApp;

        public bool IsWindowsApp
        {
            get { return _isWindowsApp; }
            set
            {
                _isWindowsApp = value;
                RaisePropertyChanged(() => IsWindowsApp);
            }
        }

        public RelayCommand CancelCommand { get; set; }

        #endregion


        public ViewModelAncestor()
        {
            if (NavigationService.HasBackButton == BackButtonTypeEnum.None)
            {
                IsWindowsApp = true;
                CancelCommand = new RelayCommand(Cancel, CanCancel);
            }
        }

        #region relaycommand

        /// <summary>
        /// Permet de revenir en arriére
        /// Cette fonction n'est utile que pour les versions sans bouton physique
        /// ou bien une surcharge de cette implémentation (voir l'exemple dans le fichier App.xaml.cs)
        /// </summary>
        private void Cancel()
        {
            if (NavigationService.CanGoBack())
            {
                NavigationService.GoBack();
            }
        }

        /// <summary>
        /// Permet de vérifier que l'on peut revenir en arriére
        /// </summary>
        /// <returns></returns>
        private bool CanCancel()
        {
            return NavigationService.CanGoBack();
        }

        #endregion
    }
}
