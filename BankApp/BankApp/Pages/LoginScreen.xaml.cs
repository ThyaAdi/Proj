using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace BankApp
{
    /// <summary>
    /// Intial login screen
    /// </summary>
	public partial class LoginScreen : UserControl
    {
        private Window window;

        /// <summary>
        /// Default constructor
        /// </summary>
		public LoginScreen()
		{            
			InitializeComponent();
		}

        /// <summary>
        /// This gets fired when login button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void newButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            window = new Window();
            window.Title = "";
            window.Content = new Login(window);
            window.Width = 440;
            window.Height = 350;
            window.ShowDialog();
		}		
	}
}