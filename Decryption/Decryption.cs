using System;
using System.Collections.Generic;
using System.Text;

namespace Vigenere_Cipher.Decryption
{
    class Decryption
    {
        string encryptedText;
        string key;
        private char[] decryptedtext;
        private List<char> newkey = new List<char>();
        List<int> combinedvals = new List<int>();
        alphabets alpha = new alphabets();

        string DecryptedText = "";
        public Decryption(string encrypted_text, string key)
        {
            this.key = key;
            // this.key = key.ToUpper();
            this.encryptedText = encrypted_text;
            // this.encryptedText = encrypted_text.ToUpper();
        }

        public void startDecrypting()
        {
            supplyValues();
            applyDecryption();
        }


        public string returndecryption()
        {
            return DecryptedText;
        }
        public void updateText(string text)
        {
            this.encryptedText = text;
            DecryptedText = "";
        }
        public void updateKey(string key)
        {
            this.key = key;
        }
        public void supplyValues()
        {
            decryptedtext = encryptedText.ToCharArray();
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

        public void applyDecryption()
        {

            for (int i = 0; i < decryptedtext.Length; i++)
            {
                int temp, texttemp;
                temp = alpha.aphabets.FindIndex(0, x => x.Equals(newkey[i]));
                texttemp = alpha.aphabets.FindIndex(0, x => x.Equals(encryptedText[i]));
                int newtemp = texttemp - temp;
                if (newtemp <= -1)
                {
                    newtemp = newtemp + alpha.aphabets.Count;
                }
                DecryptedText += alpha.aphabets[newtemp];
            }
        }
    }
}

