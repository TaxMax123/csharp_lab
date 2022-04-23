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

namespace Lab3_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// DE75512108001245126199 
    public partial class MainWindow : Window
    {
        private static PersonDetails Sender = new();
        private static PersonDetails Receiver = new();
        private static DataValidityChecks DataValidityChecks = new(new Button());
        private bool? Hitno = false;
        private float Amount = 0;
        private string Currency = String.Empty;

        private Action<Grid> MyAction = (Grid g) => { return; };
        private Action MyBindingAction = () => { return; };
        public MainWindow()
        { 
            InitializeComponent();
            MyBindingAction = SenderEventBind;
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
            Trace.WriteLine("Frame load complete triggered");
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
        }
        private void TransactionDataEventBind()
        {
            var MyPage = FramePage.Content as Page;
            var MyGrid = MyPage.Content as Grid;
            GetObject<ComboBox>(MyGrid, "ValutaInput").LostFocus += TransactionDataCurrency_LostFocus;
            GetObject<TextBox>(MyGrid, "IznosInput").LostFocus += TransactionDataAmount_LostFocus;
        }

        // ------------------------------
        // Action<Grid> functions
        // ------------------------------
        private void SenderMyAction(Grid grid)
        {
            Sender.Name = GetObject<TextBox>(grid, "SenderNameInput").Text;
            Sender.Surname = GetObject<TextBox>(grid, "SenderSurnameInput").Text;
            Sender.Address = GetObject<TextBox>(grid, "SenderAddressInput").Text;
            Sender.IBAN = GetObject<TextBox>(grid, "SenderIBANInput").Text;
            Sender.Call = GetObject<TextBox>(grid, "SenderCallInput").Text;
            Sender.Model = GetObject<ComboBox>(grid, "SenderModelInput").Text;
            PosiljateljLabel.Foreground = Brushes.Green;
            PrimateljLabel.Visibility=Visibility.Visible;
            MyAction = ReceiverMyAction;
            MyBindingAction = ReceiverEventBind;
            FramePage.NavigationService.Source = new Uri("Pages/Receiver.xaml", UriKind.Relative);
            DataValidityChecks.ResetStatus();
        }
        private void ReceiverMyAction(Grid grid)
        {
            Receiver.Name = GetObject<TextBox>(grid, "ReceiverNameInput").Text;
            Receiver.Surname = GetObject<TextBox>(grid, "ReceiverSurnameInput").Text;
            Receiver.Address = GetObject<TextBox>(grid, "ReceiverAddressInput").Text;
            Receiver.IBAN = GetObject<TextBox>(grid, "ReceiverIBANInput").Text;
            Receiver.Call = GetObject<TextBox>(grid, "ReceiverCallInput").Text;
            Receiver.Model = GetObject<ComboBox>(grid, "ReceiverModelInput").Text;
            PrimateljLabel.Foreground = Brushes.Green;
            DataLabel.Visibility=Visibility.Visible;
            MyAction = TransactionDataMyAction;
            MyBindingAction = TransactionDataEventBind;
            FramePage.NavigationService.Source = new Uri("Pages/TransactionData.xaml", UriKind.Relative);
            DataValidityChecks.ResetStatus();
        }
        private void TransactionDataMyAction(Grid grid)
        {
            Currency = GetObject<ComboBox>(grid, "ValutaInput").Text;
            Amount = float.Parse(GetObject<TextBox>(grid, "IznosInput").Text);
            Hitno = GetObject<CheckBox>(grid, "HitnoInput").IsChecked;
            DataLabel.Foreground = Brushes.Green;
            DataValidityChecks.ResetStatus();
            // do some shit to save to db
        }
    }

}
