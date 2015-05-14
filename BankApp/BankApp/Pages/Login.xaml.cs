using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Facebook;
using BankApp;
using BankApp.DB;
using System.Data.SqlClient;
using Util;

namespace BankApp
{
	/// <summary>
	/// Interaction logic for Login.xaml
	/// </summary>
	public partial class Login : UserControl
    {
        public Window window { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="window"></param>
        public Login(Window window)
		{
			this.InitializeComponent();
            BankBrowser.Navigate(new Uri("https://graph.facebook.com/oauth/authorize?client_id=" + AppSettings.ClientId + "&redirect_uri=http://www.facebook.com/connect/login_success.html&type=user_agent&display=popup", UriKind.Absolute));
            this.window = window;
		}

        /// <summary>
        /// Process request and based on the history of accounts forwards the request to corresponding page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BankBrowser_Navigated(object sender, NavigationEventArgs e)
        {
            FacebookClient FacebookClient = new FacebookClient();
            FacebookOAuthResult oauthResult;
            
            if (FacebookClient.TryParseOAuthCallbackUrl(e.Uri, out oauthResult))
            {
                Application.Current.Properties["AccessToken"] = oauthResult.AccessToken;
                FacebookClient = new FacebookClient(oauthResult.AccessToken);

                Application.Current.Properties["FacebookClient"] = FacebookClient;

                dynamic me = FacebookClient.Get("/me");

                DbConnection dbConn = DbConnection.getInstance();
                SqlConnection conn = dbConn.getConnection();

                using (SqlCommand command = new SqlCommand("select * from [bank_account] where user_id = " + me.id, conn))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        CustomNavigate.Switch(new UserHome());
                    }
                    else
                    {
                        CustomNavigate.Switch(new AddBank());
                    }
                }                      
            }

            if (oauthResult != null)
            {
                window.Close();
            }
        }
    }
}