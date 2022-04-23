using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Lab3_4
{
    internal class DataValidityChecks
    {

        public DataValidityChecks(Button button) { 
            NextPage = button;
        }
        public Button NextPage { get; set; }

        bool ValidName = false;
        bool ValidSurname = false;
        bool ValidAddress = false;
        bool ValidIBAN = false;
        bool ValidModel = false;
        bool ValidCurrency = false;
        bool ValidAmount = false;

        public void ResetStatus()
        {
            ValidName = false;
            ValidSurname = false;
            ValidAddress = false;
            ValidIBAN = false;
            ValidModel = false;
            ValidCurrency = false;
            ValidAmount = false;
        }

        public void CheckIBAN(string IBAN, Label IBANLabel, TextBox IBANInput)
        {
            var FGColor = Brushes.Black;
            ValidIBAN = true;
            try
            {
                if (!IsValidIban(IBAN))
                {
                    ValidIBAN = false;
                    FGColor = Brushes.Red;
                }
                IBANLabel.Foreground = FGColor;
                IBANInput.Foreground = FGColor;
                EnableNextPage();
            }
            catch (Exception)
            {
                ValidIBAN = false;
                FGColor = Brushes.Red;
                IBANLabel.Foreground = FGColor;
                IBANInput.Foreground = FGColor;
            }
            
        }

        public void CheckModel(string Model, Label ModelLabel, ComboBox ModelInput)
        {
            var FGColor = Brushes.Black;
            ValidModel = true;
            if (!IsValidModel(Model))
            {
                ValidModel = false;
            }
            ModelLabel.Foreground = FGColor;
            ModelInput.Foreground = FGColor;
            EnableNextPage();
        }

        public void CheckName(string Name, Label NameLabel, TextBox NameInput)
        {
            var FGColor = Brushes.Black;
            ValidName = true;
            if (Name.Length < 3)
            {
                ValidName = false;
                FGColor = Brushes.Red;
            }
            NameLabel.Foreground = FGColor;
            NameInput.Foreground = FGColor;
            EnableNextPage();
        }

        public void CheckSurname(string Surname, Label SurnameLabel, TextBox SurnameInput)
        {
            var FGColor = Brushes.Black;
            ValidSurname = true;
            if (Surname.Length < 3)
            {
                ValidSurname = false;
                FGColor = Brushes.Red;
            }
            SurnameLabel.Foreground = FGColor;
            SurnameInput.Foreground = FGColor;
            EnableNextPage();
        }
        
        public void CheckAddress(string Address, Label AddressLabel, TextBox AddressInput)
        {
            var FGColor = Brushes.Black;
            ValidAddress = true;
            if (Address.Length < 7)
            {
                ValidAddress = false;
                FGColor = Brushes.Red;
            }
            AddressLabel.Foreground = FGColor;
            AddressInput.Foreground = FGColor;
            EnableNextPage();
        }

        public void CheckCurrency(string Currency, Label CurrencyLabel, ComboBox CurrenyInput)
        {
            var FGColor = Brushes.Black;
            ValidCurrency = true;
            if (Currency.Length != 3)
            {
                ValidAddress = false;
                FGColor = Brushes.Red;
            }
            CurrencyLabel.Foreground = FGColor;
            EnableNextPage();
        }
        
        public void CheckAmount(string Amount, Label AmountLAbel, TextBox AmoutInput)
        {
            var FGColor = Brushes.Red;
            ValidAmount = false;
            if (Amount.Length > 3)
            {
                try
                {
                    var p = float.Parse(Amount);
                    if (p > 0)
                    {
                        ValidAmount = true;
                        FGColor = Brushes.Black;
                    }
                }
                catch (Exception)
                {
                    ;
                }
            }
            AmountLAbel.Foreground = FGColor;
            AmoutInput.Foreground = FGColor;
            EnableNextPage();
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

        private void EnableNextPage()
        {
            if (ValidName && ValidSurname && ValidAddress && ValidIBAN && ValidModel)
            {
                NextPage.IsEnabled = true;
            }
            if (ValidAmount && ValidCurrency)
            {
                NextPage.IsEnabled = true;
            }
        }

    }
}
