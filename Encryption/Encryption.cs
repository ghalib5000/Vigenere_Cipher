using System;
using System.Collections.Generic;
using System.Text;

namespace Vigenere_Cipher.Encryption
{
    class Encryption
    {
        private string key;
        private string decrypted_text;
        private char[] decryptedtext;
        private List<char> newkey = new List<char>();
        List<int> combinedvals = new List<int>();
        //these store the ascii numbers of characters

        private List<int> keyvals = new List<int>();
        private List<int> textvals = new List<int>();

        string encryptedText ="";

        alphabets alpha = new alphabets();
        
        public Encryption(string encrypted_text, string key)
        {
            //this.key = key;
            this.key = key.ToUpper();
            //this.decrypted_text = encrypted_text;
            this.decrypted_text =encrypted_text.ToUpper();
        }
        public void startEncrypting()
        {
            supplyValues();
            getkeyvals(newkey);
            gettextvals(decryptedtext);
            applyEncryption();
            convertBackToString(combinedvals);     
        }



        public void getkeyvals(List<char> keys)
        {
            foreach (char c in keys)
            {
                keyvals.Add(Convert.ToInt32(c));
            }
        }
        public void gettextvals(char[] text)
        {
            foreach (char c in text)
            {
                textvals.Add(Convert.ToInt32(c));
            }
        }
        public void supplyValues()
        {
            decryptedtext = decrypted_text.ToCharArray();
            int j = 0;
            for (int i = 0; i < decryptedtext.Length; i++)
            {
                if (j == key.Length)
                {
                    j = 0;
                }
                newkey.Add(key[j]);
                j++;
            }

        }

        public void applyEncryption()
        {

            for (int i = 0; i < decryptedtext.Length; i++) {
                int temp,texttemp;
                temp = alpha.aphabets.FindIndex(0, x => x.Equals(newkey[i]));
                texttemp = alpha.aphabets.FindIndex(0, x => x.Equals(decrypted_text[i]));
                int newtemp = temp + texttemp;
                if(newtemp>=26)
                {
                  newtemp=newtemp - 26;
                }
                encryptedText += alpha.aphabets[newtemp];
            }

        }
        public string returnencryption()
        {
            return encryptedText;
        }
        public void convertBackToString(List<int> list)
        {
            foreach(int i in list)
            {
                char c = Convert.ToChar(i);
                encryptedText += c;
            }
        }
    }
}
