using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Text.RegularExpressions;
using BankApp.DB;
using System.Data.SqlClient;
using Facebook;
using BankApp.Data;

namespace BankApp
{
    /// <summary>
    /// Interaction logic for AddBank.xaml
    /// </summary>
    public partial class AddBank : UserControl
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public AddBank()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Arguement constructor
        /// </summary>
        /// <param name="UserHomeAccountData"></param>
        public AddBank(UserHomeAccountData UserHomeAccountData)
        {
            InitializeComponent();
            BankName.Text = UserHomeAccountData.BankName;
            AccountType.Text = UserHomeAccountData.AccountType;
            Balance.Text = UserHomeAccountData.Balance.ToString();
            id.Text = UserHomeAccountData.id.ToString();
        }

        /// <summary>
        /// Process request to save the bank account related information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddAccountButton_Click(object sender, RoutedEventArgs e)
        {
            var bName = BankName.Text;
            var accountType = AccountType.Text;
            var balance = Balance.Text;

            ErrorText.Text = null;

            if (bName == null || bName.Trim().Length == 0)
            {
                ErrorText.Text = "All are required fields";
            }
            else if (accountType == null || accountType.Trim().Length == 0)
            {
                ErrorText.Text = "All are required fields";
            }
            else if (balance == null || balance.Trim().Length == 0)
            {
                ErrorText.Text = "All are required fields";
            }
            else if (Regex.IsMatch(balance, "[^0-9]"))
            {
                ErrorText.Text = "Balance should contain only numbers.";
            }
            else
            {
                FacebookClient client = (FacebookClient)Application.Current.Properties["FacebookClient"];
                dynamic me = client.Get("/me");

                try
                {
                    DbConnection dbConn = DbConnection.getInstance();
                    SqlConnection conn = dbConn.getConnection();

                    if (id.Text == null || id.Text.Length == 0)
                    {
                        using (SqlCommand command = new SqlCommand("insert into [bank_account] ([bank_name], [account_type], [user_id], [balance]) values (@bankName, @accountType, @userId, @balance)", conn))
                        {
                            command.Parameters.AddWithValue("@bankName", bName);
                            command.Parameters.AddWithValue("@accountType", accountType);
                            command.Parameters.AddWithValue("@balance", Convert.ToInt64(balance));
                            command.Parameters.AddWithValue("@userId", Convert.ToInt64(me.id));
                            command.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        using (SqlCommand command = new SqlCommand("update [bank_account] set bank_name = @bankName, account_type = @accountType, balance = @balance where id = " + id.Text, conn))
                        {
                            command.Parameters.AddWithValue("@bankName", bName);
                            command.Parameters.AddWithValue("@accountType", accountType);
                            command.Parameters.AddWithValue("@balance", Convert.ToInt64(balance));
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErrorText.Text = "Account was not added. Please try again.";
                }
            }

            if(ErrorText.Text == null || ErrorText.Text.Trim().Length == 0)
                CustomNavigate.Switch(new UserHome());
        }

        /// <summary>
        /// Logs out the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Logoutbutton_Click(object sender, RoutedEventArgs e)
        {
            Util.Logout();
        }

        /// <summary>
        /// Naviagtes back to the previous page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Backbutton_Click(object sender, RoutedEventArgs e)
        {
            CustomNavigate.Switch(new UserHome());
        }
    }
}
