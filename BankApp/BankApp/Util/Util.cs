using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facebook;
using System.Windows;
using System.Windows.Controls;

namespace BankApp
{
    /// <summary>
    /// Utility class to keep the untility methods.
    /// </summary>
    class Util
    {
        /// <summary>
        /// Logsout the users session
        /// </summary>
        public static void Logout()
        {
            FacebookClient client = (FacebookClient)Application.Current.Properties["FacebookClient"];

            Uri logoutUrl = client.GetLogoutUrl(new
            {
                next = "https://www.facebook.com/connect/login_success.html",
                access_token = Application.Current.Properties["AccessToken"]
            });

            WebBrowser webBrowser = new WebBrowser();
            webBrowser.Navigate(logoutUrl);
            webBrowser.Navigated += (o, args) =>
            {
                if (args.Uri.AbsoluteUri == "https://www.facebook.com/connect/login_success.html")
                    CustomNavigate.Switch(new LoginScreen());
            };
        }
    }
}
