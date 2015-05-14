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
using System.Text.RegularExpressions;
using BankApp.Data;

namespace BankApp
{
    /// <summary>
    /// Interaction logic for AddTransaction.xaml
    /// </summary>
    public partial class AddTransactionForm : UserControl
    {
        private Data.UserHomeAccountData Selection;

        /// <summary>
        /// Default constructor
        /// </summary>
        public AddTransactionForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Argument constructor
        /// </summary>
        /// <param name="Selection"></param>
        public AddTransactionForm(Data.UserHomeAccountData Selection)
        {
            InitializeComponent();
            this.Selection = Selection;
            BankId.Text = Selection.id.ToString();
        }

        /// <summary>
        /// Argument constructor
        /// </summary>
        /// <param name="Selection_2"></param>
        public AddTransactionForm(Data.BankTransaction Selection_2)
        {
            InitializeComponent();
            this.Amount.Text = Selection_2.Amount.ToString();
            this.TransactionDate.Text = DateTime.Parse(Selection_2.TransactionDate).ToString("M/d/yyyy");
            this.Description.Text = Selection_2.Description;
            this.id.Text = Selection_2.id.ToString();
            this.BankId.Text = Selection_2.BankId.ToString();
            this.button3.Content = "Edit Transaction";
            this.TransactionType.SelectedValue = Selection_2.TransactionType;
            this.TransactionType.Text = Selection_2.TransactionType;
        }

        /// <summary>
        /// Process the request to save entered information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            var amount = Amount.Text;
            var transactionType = TransactionType.Text;
            var transactionDate = TransactionDate.Text;
            var description = Description.Text;
            var bankId = BankId.Text;

            if (amount == null || amount.Trim().Length == 0)
            {
                ErrorText.Text = "Amount is required field";
            }
            else if (transactionType == null || transactionType.Trim().Length == 0)
            {
                ErrorText.Text = "Transaction Type is required fields";
            }
            else if (transactionDate == null || transactionDate.Trim().Length == 0)
            {
                ErrorText.Text = "Transaction Date is required fields";
            }
            else if (Regex.IsMatch(amount, "[^0-9]"))
            {
                ErrorText.Text = "Amount should contain only numbers.";
            }
            else
            {
                try
                {
                    DbConnection dbConn = DbConnection.getInstance();
                    SqlConnection conn = dbConn.getConnection();

                    Int64 remainingBalance = 0;
                    using (SqlCommand command = new SqlCommand("select * from [bank_app].[dbo].[bank_account] where id = " + bankId, conn))
                    {
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            remainingBalance = Convert.ToInt64((Decimal)reader["balance"]);
                        }
                        reader.Close();
                    }

                    if (remainingBalance > Convert.ToInt64(amount))
                    {
                        string query;
                        if (id.Text == null || id.Text.Length == 0)
                        {
                            query = "insert into [bank_transaction] ([amount], [transaction_type], [description], [transaction_date], [bank_account_id], [ending_balance]) values (@amount, @transaction_type, @description, @transaction_date, @bank_account_id, @ending_balance)";
                        }
                        else
                        {
                            query = "update [bank_transaction] set amount = @amount, transaction_type = @transaction_type, description = @description, transaction_date = @transaction_date, bank_account_id = @bank_account_id, ending_balance = @ending_balance where id = " + id.Text;
                        }

                        using (SqlCommand command = new SqlCommand(query, conn))
                        {
                            command.Parameters.AddWithValue("@amount", Convert.ToInt64(amount));
                            command.Parameters.AddWithValue("@transaction_type", transactionType);
                            command.Parameters.AddWithValue("@description", description == null ? DBNull.Value.ToString() : description);
                            command.Parameters.AddWithValue("@transaction_date", Convert.ToDateTime(transactionDate));
                            command.Parameters.AddWithValue("@bank_account_id", Convert.ToInt64(bankId));
                            command.Parameters.AddWithValue("@ending_balance", remainingBalance - Convert.ToInt64(amount));
                            command.ExecuteNonQuery();
                        }

                        using (SqlCommand command = new SqlCommand("update [bank_account] set balance = @balance where id = @id", conn))
                        {
                            command.Parameters.AddWithValue("@id", bankId);
                            command.Parameters.AddWithValue("@balance", remainingBalance - Convert.ToInt64(amount));
                            command.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Trasaction could not be done. Please check the minimum balance");
                    }
                    CustomNavigate.Switch(new ShowTransactions(bankId));
                }
                catch (Exception ex)
                {
                    ErrorText.Text = "Transaction was not added. Please try again.";
                }
            }
        }

        /// <summary>
        /// Navigates back to previous page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Backbutton_Click(object sender, RoutedEventArgs e)
        {
            CustomNavigate.Switch(new ShowTransactions(this.BankId.Text));
        }

        /// <summary>
        /// Logsout the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Logoutbutton_Click(object sender, RoutedEventArgs e)
        {
            Util.Logout();
        }
    }
}
