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
using System.Collections.ObjectModel;
using PieControls;
using BankApp.Data;

namespace BankApp
{
    /// <summary>
    /// Interaction logic for Chart.xaml
    /// </summary>
    public partial class Chart : UserControl
    {
        public Chart(string id)
        {
            InitializeComponent();
            this.BankAccountId.Text = id;
            DbConnection dbConn = DbConnection.getInstance();
            SqlConnection conn = dbConn.getConnection();

            using (SqlCommand command = new SqlCommand("select transaction_type, count(*) categories from [bank_app].[dbo].[bank_transaction] where active='Y' and bank_account_id = " + id + " group by transaction_type", conn))
            {
                SqlDataReader reader = command.ExecuteReader();

                ObservableCollection<PieSegment> pieCollection = new ObservableCollection<PieSegment>();
                while (reader.Read())
                {
                    string type = (string)reader["transaction_type"];
                    pieCollection.Add(new PieSegment { Color = GetColor(type), Value = (int)reader["categories"], Name = type });
                }
                TransactionChart.Data = pieCollection;
            }
        }

        private Color GetColor(string type)
        {
            if (type.ToUpper().Equals("FOOD"))
            {
                return Colors.Green;
            }
            if (type.ToUpper().Equals("TRAVELLING"))
            {
                return Colors.Red;
            }
            if (type.ToUpper().Equals("EDUCATION"))
            {
                return Colors.Blue;
            }
            if (type.ToUpper().Equals("ENTERTAINMENT"))
            {
                return Colors.Black;
            }
            if (type.ToUpper().Equals("GROCERY"))
            {
                return Colors.DeepPink;
            }
            return Colors.White;
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
            CustomNavigate.Switch(new ShowTransactions(this.BankAccountId.Text));
        }
    }
}
