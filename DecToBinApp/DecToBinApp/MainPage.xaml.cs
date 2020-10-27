using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DecToBinApp
{
    public partial class MainPage : ContentPage
    {
        Strings strings = new Strings();

        public MainPage()
        {
            InitializeComponent();
        }

        private void EditDecNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            Convert();
        }

        private void Convert()
        {
            EditBinNumber.Text = String.Empty;
            EditHexNumber.Text = String.Empty;

            string decText = EditDecNumber.Text;

            if (String.IsNullOrEmpty(decText))
            {
                MessageLabel.Text = "Ошибка, Вы не ввели число";
                return;
            }

            if (decText.Length > 0 && decText.Length < 9)
            {
                int decNumber;
                try
                {
                    decNumber = Int32.Parse(decText);
                }
                catch (Exception)
                {
                    MessageLabel.Text = "Ошибка, Ваше число не похоже на число...";
                    return;
                }

                string binText = String.Empty;
                
                EditHexNumber.Text = decNumber.ToString("X");

                while (decNumber > 0)
                {
                    binText = (decNumber & 1).ToString() + binText;
                    decNumber /= 2;
                }

                EditBinNumber.Text = binText;

                MessageLabel.Text = strings.DefaultMessageText;
            }
            else
            {
                MessageLabel.Text = "Ошибка, Ваше число слишком большое";
            }
        }
    }
}
