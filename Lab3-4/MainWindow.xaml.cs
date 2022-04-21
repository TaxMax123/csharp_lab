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
namespace Lab3_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// DE75512108001245126199 
    public partial class MainWindow : Window
    {
        private static PersonDetails Posiljatelj = new();
        private static PersonDetails Primatelj = new();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Input_TextChanged(object sender, TextChangedEventArgs e)
        {
            NextPage.IsEnabled = false;
            NextPage.Background = Brushes.Gray;
        }
        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            NextPage.Background = Brushes.Green;
        }
        private T getObject<T>(Grid grid, String objName)
        {
            return (T)grid.FindName(objName);
        }
        //getObject<TextBox>
        //getObject<Label>
        private void PersonVerify_Click(object sender, RoutedEventArgs e)
        {
            NextPage.IsEnabled = false;
            NextPage.Background = Brushes.Gray;

            PersonVerify.Background = Brushes.Pink;
            var data = FramePage.Content as Page;
            var dataGrid = data.Content as Grid;
            var Name = getObject<TextBox>(dataGrid,"ImeInput").Text;
            var Surname = getObject<TextBox>(dataGrid, "PrezimeInput").Text;
            var Address = getObject<TextBox>(dataGrid, "AdresaInput").Text;
            var IBAN = getObject<TextBox>(dataGrid, "IBANInput").Text;
            var Call = getObject<TextBox>(dataGrid, "PozivInput").Text;
            var Model = getObject<TextBox>(dataGrid, "ModelInput").Text;

            if (!IsValidIban(IBAN))
            {
                getObject<Label>(dataGrid,"IBANLabel").Foreground = Brushes.Red;
                getObject<TextBox>(dataGrid, "IBANInput").Foreground = Brushes.Red;
                return;
            }
            else
            {
                getObject<Label>(dataGrid,"IBANLabel").Foreground = Brushes.Black;
                getObject<TextBox>(dataGrid,"IBANInput").Foreground = Brushes.Black;
            }

            if (!IsValidModel(Model))
            {
                getObject<Label>(dataGrid,"ModelLabel").Foreground = Brushes.Red;
                getObject<TextBox>(dataGrid,"ModelInput").Foreground = Brushes.Red;
                return;
            }
            else
            {
                getObject<Label>(dataGrid,"ModelLabel").Foreground = Brushes.Black;
                getObject<TextBox>(dataGrid,"ModelInput").Foreground = Brushes.Black;
            }

            if (Name.Length < 3)
            {
                getObject<Label>(dataGrid, "ImeLabel").Foreground = Brushes.Red;
                getObject<TextBox>(dataGrid, "ImeInput").Foreground = Brushes.Red;
                return;
            }
            else
            {
                getObject<Label>(dataGrid, "ImeLabel").Foreground = Brushes.Black;
                getObject<TextBox>(dataGrid, "ImeInput").Foreground = Brushes.Black;
            }

            if (Surname.Length < 3)
            {
                getObject<Label>(dataGrid, "PrezimeLabel").Foreground = Brushes.Red;
                getObject<TextBox>(dataGrid, "PrezimeInput").Foreground = Brushes.Red;
                return;
            }
            else
            {
                getObject<Label>(dataGrid, "PrezimeLabel").Foreground = Brushes.Black;
                getObject<TextBox>(dataGrid, "PrezimeInput").Foreground = Brushes.Black;
            }

            if (Address.Length < 7)
            {
                getObject<Label>(dataGrid, "AdresaLabel").Foreground = Brushes.Red;
                getObject<TextBox>(dataGrid, "AdresaInput").Foreground = Brushes.Red;
                return;
            }
            else
            {
                getObject<Label>(dataGrid, "AdresaLabel").Foreground = Brushes.Black;
                getObject<TextBox>(dataGrid, "AdresaInput").Foreground = Brushes.Black;
            }


            NextPage.IsEnabled = true;
            PersonVerify.Background = Brushes.Green;
        }

        private static bool IsValidIban(string bankAccount)
        {
            bankAccount = bankAccount.ToUpper(); //IN ORDER TO COPE WITH THE REGEX BELOW
            if (String.IsNullOrEmpty(bankAccount))
                return false;
            if (bankAccount.Length < 4) return false;
            if (System.Text.RegularExpressions.Regex.IsMatch(bankAccount, "^[A-Z0-9]"))
            {
                bankAccount = bankAccount.Replace(" ", String.Empty);
                string bank =
                    bankAccount.Substring(4, bankAccount.Length - 4) + bankAccount.Substring(0, 4);
                int asciiShift = 55;
                StringBuilder sb = new StringBuilder();
                foreach (char c in bank)
                {
                    int v;
                    if (Char.IsLetter(c)) v = c - asciiShift;
                    else v = int.Parse(c.ToString());
                    sb.Append(v);
                }

                string checkSumString = sb.ToString();
                int checksum = int.Parse(checkSumString.Substring(0, 1));
                for (int i = 1; i < checkSumString.Length; i++)
                {
                    int v = int.Parse(checkSumString.Substring(i, 1));
                    checksum *= 10;
                    checksum += v;
                    checksum %= 97;
                }

                return checksum == 1;
            }
            return false;
        }


        private static bool IsValidModel(String Model)
        {
            if (Model == "00")
                return true;
            if (Model == "99")
                return true;
            Console.WriteLine("Invalid Model ");
            return false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var data = FramePage.Content as Page;
            var dataGrid = data.Content as Grid;
            ObjGetters.getObject<TextBox>(dataGrid, "ImeInput").TextChanged += Input_TextChanged;
            ObjGetters.getObject<TextBox>(dataGrid, "PrezimeInput").TextChanged += Input_TextChanged;
            ObjGetters.getObject<TextBox>(dataGrid, "AdresaInput").TextChanged += Input_TextChanged;
            ObjGetters.getObject<TextBox>(dataGrid, "IBANInput").TextChanged += Input_TextChanged;
            ObjGetters.getObject<TextBox>(dataGrid, "PozivInput").TextChanged += Input_TextChanged;
            ObjGetters.getObject<TextBox>(dataGrid, "ModelInput").TextChanged += Input_TextChanged;
        }
    }

}
