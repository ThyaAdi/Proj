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
using System.Windows.Shapes;
using Facebook;
using BankApp.DB;
using System.Data.SqlClient;
using BankApp.Data;
using System.ComponentModel;

namespace BankApp
{
    /// <summary>
    /// Handles the user home logic
    /// </summary>
    public partial class UserHome : UserControl
    {
        private List<UserHomeAccountData> list;
        private UserHomeAccountData Selection;

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserHome()
        {
            InitializeComponent();
            PrepareUserHome();
        }

        /// <summary>
        /// Process request to prepare user home data
        /// </summary>
        private void PrepareUserHome()
        {
            FacebookClient client = (FacebookClient)Application.Current.Properties["FacebookClient"];
            dynamic me = client.Get("/me");

            DbConnection dbConn = DbConnection.getInstance();
            SqlConnection conn = dbConn.getConnection();

            using (SqlCommand command = new SqlCommand("select * from [bank_app].[dbo].[bank_account] where active='Y' and user_id = " + me.id, conn))
            {
                SqlDataReader reader = command.ExecuteReader();
                list = new List<UserHomeAccountData>();

                while (reader.Read())
                {
                    UserHomeAccountData UserHomeData = new UserHomeAccountData();
                    UserHomeData.id = Convert.ToInt64((int)reader["id"]);
                    UserHomeData.BankName = (string)reader["bank_name"];
                    UserHomeData.AccountType = (string)reader["account_type"];
                    UserHomeData.Balance = Convert.ToInt64((Decimal)reader["balance"]);
                    list.Add(UserHomeData);
                }
            }
          
            BankDetails.Columns[0].Visibility = System.Windows.Visibility.Collapsed;
            BankDetails.ItemsSource = list;

            if (list == null || list.Count == 0)
            {
                CustomNavigate.Switch(new AddBank());
            }

            //using (SqlCommand command = new SqlCommand("select * from [bank_app].[dbo].[bank_account] where balance=MAX(Value) and user_id = " + me.id, conn))
            //{
              //  SqlDataReader reader = command.ExecuteReader();
                
               // while (reader.Read())
                //{
                    
                //}
            //}
           
        }
       
        
        /// <summary>
        /// Navigate to the bank account creation page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddAccount_Click(object sender, RoutedEventArgs e)
        {
            CustomNavigate.Switch(new AddBank());
        }

        /// <summary>
        /// An event method gets triggered when the row is selected in the datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bank_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Selection = BankDetails.SelectedItem as UserHomeAccountData;
        }

        /// <summary>
        /// This event gets fired when the delete button pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (Selection == null)
            {
                MessageBox.Show("Cannot delete the blank Entry");
            }
            else
            {
                try
                {
                    DbConnection dbConn = DbConnection.getInstance();
                    SqlConnection conn = dbConn.getConnection();

                    using (SqlCommand command = new SqlCommand("update [bank_account] set active = 'N' where id = @id", conn))
                    {
                        command.Parameters.AddWithValue("@id", Selection.id);
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Record Deleted..");
                    CustomNavigate.Switch(new UserHome());
                }
                catch (Exception ex)
                {
                    //ErrorText.Text = "Account was not added. Please try again.";
                }
            }
        }

        /// <summary>
        /// This is event gets fired when he edit button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, RoutedEventArgs e)
        {
            if (Selection == null)
            {
                MessageBox.Show("Cannot edit the blank Entry");
            }
            else
            {
                try
                {
                    DbConnection dbConn = DbConnection.getInstance();
                    SqlConnection conn = dbConn.getConnection();

                    using (SqlCommand command = new SqlCommand("select * from [bank_account] where id = " + Selection.id, conn))
                    {
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            UserHomeAccountData UserHomeData = new UserHomeAccountData();
                            UserHomeData.id = Convert.ToInt64((int)reader["id"]);
                            UserHomeData.BankName = (string)reader["bank_name"];
                            UserHomeData.AccountType = (string)reader["account_type"];
                            UserHomeData.Balance = Convert.ToInt64((Decimal)reader["balance"]);
                            CustomNavigate.Switch(new AddBank(UserHomeData));
                        }
                    }
                }
                catch (Exception ex)
                {
                    //ErrorText.Text = "Account was not added. Please try again.";
                }
            }
        }

        /// <summary>
        /// This event gets fired when the delete button is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, RoutedEventArgs e)
        {
            if (Selection == null)
            {
                MessageBox.Show("Cannot delete the blank Entry");
            }
            else
            {
                try
                {
                    DbConnection dbConn = DbConnection.getInstance();
                    SqlConnection conn = dbConn.getConnection();

                    using (SqlCommand command = new SqlCommand("update [bank_account] set active = 'N' where id = @id", conn))
                    {
                        command.Parameters.AddWithValue("@id", Selection.id);
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Record Deleted..");
                    CustomNavigate.Switch(new UserHome());
                }
                catch (Exception ex)
                {
                    //ErrorText.Text = "Account was not added. Please try again.";
                }
            }
        }

        /// <summary>
        /// This event gets fired when the view button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            if (Selection == null)
            {
                MessageBox.Show("Please select the account");
            }
            else
            {
                CustomNavigate.Switch(new ShowTransactions(Selection.id.ToString()));
            }
        }

        /// <summary>
        /// This event gets fired when the logout buton is presses
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void logout_Click(object sender, RoutedEventArgs e)
        {
            Util.Logout();
        }
    }
}
