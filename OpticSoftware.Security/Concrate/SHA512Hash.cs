using OpticSoftware.Security.Abstract;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace OpticSoftware.Security.Concrate
{
    public class SHA512Hash : IHash
    {
        public string Hash(string text)
        {
            using (SHA512 sha512Hash = SHA512.Create())
            {
                //From String to byte array
                byte[] sourceBytes = Encoding.UTF8.GetBytes(text);
                byte[] hashBytes = sha512Hash.ComputeHash(sourceBytes);
                return BitConverter.ToString(hashBytes).Replace("-", String.Empty);
            }
        }
    }
}
