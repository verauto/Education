using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GuruTest.Utils
{
    public static class StringHelper
    {
        private static readonly Random Random = new Random();

        public static string RandomString(int length)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[Random.Next(s.Length)]).ToArray());
        }
    }
}