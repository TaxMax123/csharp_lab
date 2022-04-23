using System;
using System.Collections.Generic;
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
using System.Diagnostics;
using System.Dynamic;
using System.Net.Http;
using System.Text.Json;

namespace Lab3_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// DE75512108001245126199 
    public partial class MainWindow : Window
    {
        private static UniverzalniNalog nalog = new();
        private static DataValidityChecks DataValidityChecks = new(new Button());

        private List<String> Models = null;
        private List<String> Currencies = null;

        private Action<Grid> MyAction = (Grid g) => { return; };
        private Action MyBindingAction = () => { return; };
        public MainWindow()
        { 
            InitializeComponent();
            MyBindingAction = SenderEventBind;
            var ModelsUrl = "https://localhost:7242/api/enum/models";
            var CurrenciesUrl = "https://localhost:7242/api/enum/currencies";

            var client = new HttpClient();
            var resp = client.GetAsync(ModelsUrl).Result;
            var data = resp.Content.ReadAsStringAsync().Result;
            var result = JsonSerializer.Deserialize<List<string>>(data);
            Models = result;
            resp = client.GetAsync(CurrenciesUrl).Result;
            data = resp.Content.ReadAsStringAsync().Result;
            result = JsonSerializer.Deserialize<List<string>>(data);
            Currencies = result;
        }
        private static T GetObject<T>(Grid grid, String objName)
        {
            return (T)grid.FindName(objName);
        }
        // ------------------------------
        // Auto binded events
        // ------------------------------
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataValidityChecks = new(NextPage);
        }
        private void FramePage_Loaded(object sender, RoutedEventArgs e)
        {
            MyAction = SenderMyAction;
        }
        private void FramePage_LoadCompleted(object sender, NavigationEventArgs e)
        {
            MyBindingAction();
        }
        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            NextPage.Background = Brushes.Green;
            var data = FramePage.Content as Page;
            var dataGrid = data.Content as Grid;
            MyAction(dataGrid);
            NextPage.IsEnabled = false;
        }
        // ------------------------------
        // Reveiver Lost Focus Functions
        // ------------------------------
        private void ReceiverName_LostFocus(object sender, RoutedEventArgs e)
        {
            var data = FramePage.Content as Page;
            var dataGrid = data.Content as Grid;
            var Name = GetObject<TextBox>(dataGrid, "ReceiverNameInput");
            var LName = GetObject<Label>(dataGrid, "ReceiverNameLabel");
            DataValidityChecks.CheckName(Name.Text, LName, Name);
        }
        private void ReceiverSurname_LostFocus(object sender, RoutedEventArgs e)
        {
            var data = FramePage.Content as Page;
            var dataGrid = data.Content as Grid;
            var Surname = GetObject<TextBox>(dataGrid, "ReceiverSurnameInput");
            var LSurname = GetObject<Label>(dataGrid, "ReceiverSurnameLabel");
            DataValidityChecks.CheckSurname(Surname.Text, LSurname, Surname);
        }
        private void ReceiverAddress_LostFocus(object sender, RoutedEventArgs e)
        {
            var data = FramePage.Content as Page;
            var dataGrid = data.Content as Grid;
            var Address = GetObject<TextBox>(dataGrid, "ReceiverAddressInput");
            var LAddress = GetObject<Label>(dataGrid, "ReceiverAddressLabel");
            DataValidityChecks.CheckAddress(Address.Text, LAddress, Address);
        }
        private void ReceiverIBAN_LostFocus(object sender, RoutedEventArgs e)
        {
            var data = FramePage.Content as Page;
            var dataGrid = data.Content as Grid;
            var IBAN = GetObject<TextBox>(dataGrid, "ReceiverIBANInput");
            var LIBAN = GetObject<Label>(dataGrid, "ReceiverIBANLabel");
            DataValidityChecks.CheckIBAN(IBAN.Text, LIBAN, IBAN);
        }
        private void ReceiverModel_LostFocus(object sender, RoutedEventArgs e)
        {
            var data = FramePage.Content as Page;
            var dataGrid = data.Content as Grid;
            var Model = GetObject<ComboBox>(dataGrid, "ReceiverModelInput");
            var LModel = GetObject<Label>(dataGrid, "ReceiverModelLabel");
            DataValidityChecks.CheckModel(Model.Text, LModel,Model);
        }
        // ------------------------------
        // Sender Lost Focus Functions
        // ------------------------------
        private void SenderName_LostFocus(object sender, RoutedEventArgs e)
        {
            var data = FramePage.Content as Page;
            var dataGrid = data.Content as Grid;
            var Name = GetObject<TextBox>(dataGrid, "SenderNameInput");
            var LName = GetObject<Label>(dataGrid, "SenderNameLabel");
            DataValidityChecks.CheckName(Name.Text, LName, Name);
        }
        private void SenderSurname_LostFocus(object sender, RoutedEventArgs e)
        {
            var data = FramePage.Content as Page;
            var dataGrid = data.Content as Grid;
            var Surname = GetObject<TextBox>(dataGrid, "SenderSurnameInput");
            var LSurname = GetObject<Label>(dataGrid, "SenderSurnameLabel");
            DataValidityChecks.CheckSurname(Surname.Text, LSurname, Surname);
        }
        private void SenderAddress_LostFocus(object sender, RoutedEventArgs e)
        {
            var data = FramePage.Content as Page;
            var dataGrid = data.Content as Grid;
            var Address = GetObject<TextBox>(dataGrid, "SenderAddressInput");
            var LAddress = GetObject<Label>(dataGrid, "SenderAddressLabel");
            DataValidityChecks.CheckAddress(Address.Text, LAddress, Address);
        }
        private void SenderIBAN_LostFocus(object sender, RoutedEventArgs e)
        {
            var data = FramePage.Content as Page;
            var dataGrid = data.Content as Grid;
            var IBAN = GetObject<TextBox>(dataGrid, "SenderIBANInput");
            var LIBAN = GetObject<Label>(dataGrid, "SenderIBANLabel");
            DataValidityChecks.CheckIBAN(IBAN.Text, LIBAN, IBAN);
        }
        private void SenderModel_LostFocus(object sender, RoutedEventArgs e)
        {
            var data = FramePage.Content as Page;
            var dataGrid = data.Content as Grid;
            var Model = GetObject<ComboBox>(dataGrid, "SenderModelInput");
            var LModel = GetObject<Label>(dataGrid, "SenderModelLabel");
            DataValidityChecks.CheckModel(Model.Text, LModel, Model);
        }
        // ------------------------------
        // Transaction Data Lost Focus Functions
        private void TransactionDataCurrency_LostFocus(object sender, RoutedEventArgs e)
        {
            var data = FramePage.Content as Page;
            var dataGrid = data.Content as Grid;
            var Currency = GetObject<ComboBox>(dataGrid, "ValutaInput");
            var LCurrency = GetObject<Label>(dataGrid, "ValutaLabel");
            DataValidityChecks.CheckCurrency(Currency.Text, LCurrency, Currency);
        }
        private void TransactionDataAmount_LostFocus(object sender, RoutedEventArgs e)
        {
            var data = FramePage.Content as Page;
            var dataGrid = data.Content as Grid;
            var Amount = GetObject<TextBox>(dataGrid, "IznosInput");
            var LAmount = GetObject<Label>(dataGrid, "IznosLabel");
            DataValidityChecks.CheckAmount(Amount.Text, LAmount, Amount);
        }
        // ------------------------------
        // ------------------------------
        // Event bindings for pages
        // ------------------------------
        private void ReceiverEventBind()
        {
            var MyPage = FramePage.Content as Page;
            var MyGrid = MyPage.Content as Grid;
            GetObject<TextBox>(MyGrid, "ReceiverNameInput").LostFocus += ReceiverName_LostFocus;
            GetObject<TextBox>(MyGrid, "ReceiverSurnameInput").LostFocus += ReceiverSurname_LostFocus;
            GetObject<TextBox>(MyGrid, "ReceiverAddressInput").LostFocus += ReceiverAddress_LostFocus;
            GetObject<TextBox>(MyGrid, "ReceiverIBANInput").LostFocus += ReceiverIBAN_LostFocus;
            GetObject<ComboBox>(MyGrid, "ReceiverModelInput").LostFocus += ReceiverModel_LostFocus;
            GetObject<ComboBox>(MyGrid, "ReceiverModelInput").ItemsSource = Models;

        }
        private void SenderEventBind()
        {
            var MyPage = FramePage.Content as Page;
            var MyGrid = MyPage.Content as Grid;
            GetObject<TextBox>(MyGrid, "SenderNameInput").LostFocus += SenderName_LostFocus;
            GetObject<TextBox>(MyGrid, "SenderSurnameInput").LostFocus += SenderSurname_LostFocus;
            GetObject<TextBox>(MyGrid, "SenderAddressInput").LostFocus += SenderAddress_LostFocus;
            GetObject<TextBox>(MyGrid, "SenderIBANInput").LostFocus += SenderIBAN_LostFocus;
            GetObject<ComboBox>(MyGrid, "SenderModelInput").LostFocus += SenderModel_LostFocus;
            GetObject<ComboBox>(MyGrid, "SenderModelInput").ItemsSource = Models;
        }
        private void TransactionDataEventBind()
        {
            var MyPage = FramePage.Content as Page;
            var MyGrid = MyPage.Content as Grid;
            GetObject<ComboBox>(MyGrid, "ValutaInput").LostFocus += TransactionDataCurrency_LostFocus;
            GetObject<TextBox>(MyGrid, "IznosInput").LostFocus += TransactionDataAmount_LostFocus;
            GetObject<ComboBox>(MyGrid, "ValutaInput").ItemsSource = Currencies;
        }

        // ------------------------------
        // Action<Grid> functions
        // ------------------------------
        private void SenderMyAction(Grid grid)
        {
            nalog.Platitelj.Ime = GetObject<TextBox>(grid, "SenderNameInput").Text;
            nalog.Platitelj.Prezime = GetObject<TextBox>(grid, "SenderSurnameInput").Text;
            nalog.Platitelj.Adresa = GetObject<TextBox>(grid, "SenderAddressInput").Text;
            nalog.Platitelj.BrojRacunaIliIban = GetObject<TextBox>(grid, "SenderIBANInput").Text;
            nalog.Platitelj.PozivNaBroj = GetObject<TextBox>(grid, "SenderCallInput").Text;
            nalog.Platitelj.Model = GetObject<ComboBox>(grid, "SenderModelInput").Text;
            PosiljateljLabel.Foreground = Brushes.Green;
            PrimateljLabel.Visibility=Visibility.Visible;
            MyAction = ReceiverMyAction;
            MyBindingAction = ReceiverEventBind;
            FramePage.NavigationService.Source = new Uri("Pages/Receiver.xaml", UriKind.Relative);
            DataValidityChecks.ResetStatus();
        }
        private void ReceiverMyAction(Grid grid)
        {
            nalog.Primatelj.Ime = GetObject<TextBox>(grid, "ReceiverNameInput").Text;
            nalog.Primatelj.Prezime = GetObject<TextBox>(grid, "ReceiverSurnameInput").Text;
            nalog.Primatelj.Adresa = GetObject<TextBox>(grid, "ReceiverAddressInput").Text;
            nalog.Primatelj.BrojRacunaIliIban = GetObject<TextBox>(grid, "ReceiverIBANInput").Text;
            nalog.Primatelj.PozivNaBroj = GetObject<TextBox>(grid, "ReceiverCallInput").Text;
            nalog.Primatelj.Model = GetObject<ComboBox>(grid, "ReceiverModelInput").Text;
            PrimateljLabel.Foreground = Brushes.Green;
            DataLabel.Visibility=Visibility.Visible;
            MyAction = TransactionDataMyAction;
            MyBindingAction = TransactionDataEventBind;
            FramePage.NavigationService.Source = new Uri("Pages/TransactionData.xaml", UriKind.Relative);
            DataValidityChecks.ResetStatus();
        }
        private void TransactionDataMyAction(Grid grid)
        {
            var ConvertCurrency = GetConverter();
            var key = GetObject<ComboBox>(grid, "ValutaInput").Text;
            nalog.ValutaPlacanja = ConvertCurrency[key];
            nalog.Iznos = float.Parse(GetObject<TextBox>(grid, "IznosInput").Text);
            nalog.Hitno = GetObject<CheckBox>(grid, "HitnoInput").IsChecked;
            nalog.DatumIzvrsenja = DateTime.Now;
            DataLabel.Foreground = Brushes.Green;

            var client = new HttpClient();
            var ser = JsonSerializer.Serialize(nalog);
            Trace.WriteLine(ser);
            var content = new StringContent(ser, Encoding.UTF8, "application/json");
            Trace.WriteLine(content);
            var result = client.PostAsync("https://localhost:7242/api/new", content).Result;
            Trace.Write(result.Content.ReadAsStringAsync().Result);

            DataValidityChecks.ResetStatus();
            nalog = new UniverzalniNalog();

        }

        private Dictionary<string, int> GetConverter()
        {
            Dictionary<String, int> Currency = new();
                Currency.Add("Eur", 0);
                Currency.Add("Hrk", 1);
                Currency.Add("Aud", 2);
                Currency.Add("Cad", 3);
                Currency.Add("Dkk", 4);
                Currency.Add("Huf", 5);
                Currency.Add("Jpy", 6);
                Currency.Add("Nok", 7);
                Currency.Add("Sek", 8);
                Currency.Add("Chf", 9);
                Currency.Add("Gbp", 10);
                Currency.Add("Usd", 11);
                Currency.Add("Bam", 12);
                Currency.Add("Pln", 13);
            return Currency;
        }
    }
}
