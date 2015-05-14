using System.Windows.Controls;

namespace BankApp
{
    /// <summary>
    /// CustomNavigate helper class to take the user to requested page
    /// </summary>
  	public static class CustomNavigate
  	{
    	public static CustomNavigator pageSwitcher;

        /// <summary>
        /// Switch between pages
        /// </summary>
        /// <param name="newPage"></param>
    	public static void Switch(UserControl newPage)
    	{
      		pageSwitcher.Navigate(newPage);
    	}
  	}
}
