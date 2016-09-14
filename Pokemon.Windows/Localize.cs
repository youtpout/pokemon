using System;
using System.Globalization;
using Pokemon.Windows;
using Xamarin.Forms;
using Windows.System.UserProfile;

[assembly: Dependency(typeof(Localize))]
namespace Pokemon.Windows
{
    public class Localize : ILocale
    {
        public System.Globalization.CultureInfo GetCurrentCultureInfo()
        {
            return new System.Globalization.CultureInfo(
          GlobalizationPreferences.Languages[0].ToString());
        }

        public void SetLocale(System.Globalization.CultureInfo ci)
        {
            // Do nothing
        }
    }
}