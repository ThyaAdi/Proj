using System;
using System.Windows;
using System.Windows.Controls;

namespace BankApp
{
    /// <summary>
    /// Custom navigator to navigate between pages
    /// </summary>
    public partial class CustomNavigator : Window
    {
        /// <summary>
        /// Defaul consturctor. This will redirect to display the correct landing page.
        /// </summary>
        public CustomNavigator()
        {
            InitializeComponent();
            CustomNavigate.pageSwitcher = this;
            CustomNavigate.Switch(new LoginScreen());            
        }

        /// <summary>
        /// Navigate method to switch between pages
        /// </summary>
        /// <param name="nextPage"></param>
        public void Navigate(UserControl nextPage)
        {
            this.Content = nextPage;
        }
    }
}
