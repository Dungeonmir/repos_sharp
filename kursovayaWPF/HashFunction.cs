using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace kursovayaWPF
{
    internal class HashFunction
    {
        public string makeHash(string data)
        {
            

            using (var myHash = SHA256.Create())
            {
                var byteArrayResultOfRawData = Encoding.UTF8.GetBytes(data);
                var byteArrayResult = myHash.ComputeHash(byteArrayResultOfRawData);  
                return string.Concat(Array.ConvertAll(byteArrayResult,
                                       h => h.ToString("X2")));
            }
        }
    }
}
