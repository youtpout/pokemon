using System;
using System.Globalization;
using Pokemon.UWP;
using Xamarin.Forms;

[assembly: Dependency(typeof(Localize))]
namespace Pokemon.UWP
{
    public class Localize : ILocale
    {
        public System.Globalization.CultureInfo GetCurrentCultureInfo()
        {
            return new System.Globalization.CultureInfo(
				Windows.System.UserProfile.GlobalizationPreferences.Languages[0].ToString());
        }

        public void SetLocale(System.Globalization.CultureInfo ci)
        {
            // Do nothing
        }
    }
}