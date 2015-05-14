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
using BankApp.DB;
using System.Data.SqlClient;
using BankApp.Data;
using Facebook;
using System.Collections.ObjectModel;
using PieControls;

namespace BankApp
{
    /// <summary>
    /// Interaction logic for ShowTransactions.xaml
    /// </summary>
    public partial class ShowTransactions : UserControl
    {
        private List<BankTransaction> list;
        private BankTransaction Selection;

        /// <summary>
        /// Constructor which accepts id to show transactions
        /// </summary>
        /// <param name="id"></param>
        public ShowTransactions(String id)
        {
            InitializeComponent();

            DbConnection dbConn = DbConnection.getInstance();
            SqlConnection conn = dbConn.getConnection();

            using (SqlCommand command = new SqlCommand("select * from [bank_app].[dbo].[bank_transaction] a join [bank_app].[dbo].[bank_account] b on a.bank_account_id = b.id where a.active='Y' and bank_account_id = " + id, conn))
            {
                SqlDataReader reader = command.ExecuteReader();
                list = new List<BankTransaction>();

                while (reader.Read())
                {
                    BankTransaction BankTransaction = new BankTransaction();
                    BankTransaction.id = Convert.ToInt64((int)reader["id"]);
                    BankTransaction.Amount = Convert.ToInt64((Decimal)reader["amount"]);
                    BankTransaction.EndingBalance = Convert.ToInt64((Decimal)reader["ending_balance"]);
                    BankTransaction.TransactionType = (string)reader["transaction_type"];
                    BankTransaction.Description = reader["description"] == DBNull.Value ? "" : (string)reader["description"];
                    BankTransaction.TransactionDate = ((DateTime)reader["transaction_date"]).ToString("MM/dd/yyyy");
                    BankTransaction.BankId = Convert.ToInt64((Decimal)reader["bank_account_id"]).ToString();
                    list.Add(BankTransaction);
                }
            }
            BankDetails.Columns[0].Visibility = System.Windows.Visibility.Collapsed;
            BankDetails.ItemsSource = list;
            BankAccountId.Text = id;

            if (list == null || list.Count == 0)
            {
                CustomNavigate.Switch(new AddTransactionForm());
            }
        }

        /// <summary>
        /// Displays the Add transaction page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddTransactionButton_Click(object sender, RoutedEventArgs e)
        {
            UserHomeAccountData data = new UserHomeAccountData();
            data.id = Convert.ToInt64(this.BankAccountId.Text);
            CustomNavigate.Switch(new AddTransactionForm(data));
        }

        /// <summary>
        /// Displays the edit transaction page to update the transaction
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, RoutedEventArgs e)
        {
            if (Selection == null)
            {
                MessageBox.Show("Please select transaction");
            }
            else
            {
                CustomNavigate.Switch(new AddTransactionForm(Selection));
            }
        }

        /// <summary>
        /// Stores the seleted row value. This gets fired when the row is selected in the data grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BankDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Selection = BankDetails.SelectedItem as BankTransaction;
            Selection.BankId = BankAccountId.Text;
        }

        /// <summary>
        /// This gets fired when the delete buton is pressed
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

                    using (SqlCommand command = new SqlCommand("update [bank_transaction] set active = 'N' where id = @id", conn))
                    {
                        command.Parameters.AddWithValue("@id", Selection.id);
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Record Deleted..");
                    CustomNavigate.Switch(new ShowTransactions(BankAccountId.Text));
                }
                catch (Exception ex)
                {
                    //ErrorText.Text = "Account was not added. Please try again.";
                }
            }
        }

        /// <summary>
        /// Takes the user back to previous page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            CustomNavigate.Switch(new UserHome());
        }

        /// <summary>
        /// Logs out the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Util.Logout();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            CustomNavigate.Switch(new Chart(this.BankAccountId.Text));
        }
    }
}
