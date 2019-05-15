using Application.Factories;
using Core.Models;
using NUnit.Framework;
using System;
using System.Text;
using System.Threading.Tasks;

namespace LataNova.IntegrationTests
{
    public static class Utils
    {
        // Generate a random string with a given size  
        public static string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            return builder.ToString();
        }
    }
}
