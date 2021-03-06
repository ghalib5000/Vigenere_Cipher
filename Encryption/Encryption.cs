﻿using System;
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

        string encryptedText = "";

        alphabets alpha = new alphabets();

        public Encryption(string encrypted_text, string key)
        {
            this.key = key;
            //this.key = key.ToUpper();
            this.decrypted_text = encrypted_text;
            //this.decrypted_text = encrypted_text.ToUpper();
        }
        public void startEncrypting()
        {
            supplyValues();
            applyEncryption();
        }
        public void updateText(string text)
        {
            this.decrypted_text = text;
            encryptedText = "";
        }
        public void updateKey(string key)
        {
            this.key = key;
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

            for (int i = 0; i < decryptedtext.Length; i++)
            {
                int temp, texttemp;
                temp = alpha.aphabets.FindIndex(0, x => x.Equals(newkey[i]));
                texttemp = alpha.aphabets.FindIndex(0, x => x.Equals(decrypted_text[i]));
                int newtemp = temp + texttemp;
                if (newtemp >= alpha.aphabets.Count)
                {
                    newtemp = newtemp - alpha.aphabets.Count;
                }
                encryptedText += alpha.aphabets[newtemp];
            }

        }

        public string returnencryption()
        {
            return encryptedText;
        }
    }
}
