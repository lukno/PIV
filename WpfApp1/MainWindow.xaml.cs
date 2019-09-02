using com.sun.xml.@internal.bind.v2.model.core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();
            
            //string connectionstring;
            //SqlConnection cnn;

            //connectionstring = @"Data Source=LAPTOP-ALOUF938;Initial Catalog=Kurier; Integrated Security=true";
            //cnn = new SqlConnection(connectionstring);
            //cnn.Open();
            //MessageBox.Show("udało się połączyć z bazą");
        }

        public string adress;
        public string mmiejscowosc;
        public string imieInazwisko;
        public string numerpaczki;
        public string miejscepracy;


        public void Dodawanie()
        {

            string connectionstring;
            SqlConnection cnn;

            connectionstring = @"Data Source=LAPTOP-ALOUF938;Initial Catalog=Kurier; Integrated Security=true";
            cnn = new SqlConnection(connectionstring);
            cnn.Open();
            string sql= "";

            SqlCommand command;

            SqlDataAdapter adapter = new SqlDataAdapter();

            sql = "Insert Into Paczka (IdPaczki, Miejscowosc, Imie_nazwisko, Adres) values('" + numerpaczki + "', '" 
                + mmiejscowosc + "','" + imieInazwisko + "', '" + adress + "')  ";
            command = new SqlCommand(sql, cnn);
            adapter.InsertCommand = new SqlCommand(sql, cnn);
            adapter.InsertCommand.ExecuteNonQuery();
            command.Dispose();
            MessageBox.Show("dodano");
            cnn.Close();
            

        }



        class Paczka
        {
            public string IdPaczki { get; set; }
            public  string Miejscowosc { get; set; }
            public string Imie_nazwisko { get; set; }
            public string Adres { get; set; }

        }

        //public class DataContext : System.Data.Entity.DbContext 


        private void Grid_Selected(object sender, RoutedEventArgs e)
        {

        }

       

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string connectionstring;
            SqlConnection cnn;

            connectionstring = @"Data Source=LAPTOP-ALOUF938;Initial Catalog=Kurier; Integrated Security=true";
            cnn = new SqlConnection(connectionstring);
            cnn.Open();
            SqlCommand command;

            string zapytanie;




            zapytanie = "Select IdPaczki, Miejscowosc, Imie_nazwisko, Adres FROM Paczka Where Miejscowosc=('" + miejscepracy + "') ";
            command = new SqlCommand(zapytanie,cnn);
            command.ExecuteNonQuery();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable("Paczka");
            dataAdapter.Fill(dt);
            data.ItemsSource = dt.DefaultView;
            dataAdapter.Update(dt);
            cnn.Close();
            
            


        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Dodawanie();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Idpaczki_TextChanged(object sender, TextChangedEventArgs e)
        {
            numerpaczki = idpaczki.Text;

        }

        private void Miejscowosc_TextChanged(object sender, TextChangedEventArgs e)
        {
            mmiejscowosc = miejscowosc.Text;
        }

        private void Imie_TextChanged(object sender, TextChangedEventArgs e)
        {
            imieInazwisko = imie.Text;
        }

        private void Adres_TextChanged(object sender, TextChangedEventArgs e)
        {
            adress = adres.Text;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            miejscepracy = miejsce.Text;
        }
    }
}
