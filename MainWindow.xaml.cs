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

namespace Vigenere_Cipher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int noofround= 1;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (noOfROunds.Text.Length != 0)
                {
                    noofround = Convert.ToInt32(noOfROunds.Text);

                }
                if (encrypt.IsChecked.Value)
                {
                    Encryption.Encryption encrypter = new Encryption.Encryption(decryptText.Text, Key.Text);
                    for (int i = 0; i < noofround; i++)
                    {
                        encrypter.updateText(decryptText.Text);
                        encrypter.startEncrypting();
                        decryptText.Text = encrypter.returnencryption();
                    }
                    decryptText.Text = "";
                    encryptText.Text = encrypter.returnencryption();
                }
                else if (decrypt.IsChecked.Value)
                {
                    Decryption.Decryption decrypter = new Decryption.Decryption(encryptText.Text, Key.Text);
                    for (int i = 0; i < noofround; i++)
                    {
                        decrypter.updateText(encryptText.Text);
                        decrypter.startDecrypting();
                        encryptText.Text = decrypter.returndecryption();
                    }
                    encryptText.Text = "";
                    decryptText.Text = decrypter.returndecryption();
                }
                else
                {
                    logout.Text += "Please select atleast one option" + Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                logout.Text += ex.Message + Environment.NewLine;
            }
        }
    }
}
