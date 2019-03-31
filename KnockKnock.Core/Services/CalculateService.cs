using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnockKnock.Core
{
    public class CalculateService : ICalculateService
    {
        // The token should be moved to appsettings.json but I've left it here for simplicity.
        private const string TOKEN = "1a39b7a7-92d3-4d06-84ad-782131fad8f1";


        public async Task<Int64> GetFibonacci(long n)
        {
            // If 0, 1, or -1, don't bother calculating
            if (n == 0) return 0;
            if (n == 1 || n == -1) return 1;

            // Keep track of whether n is negative and convert to positive  for calculation
            var negative = false;
            if (n < 0)
            {
                negative = true;
                n = n * -1;
            }

            // Declare first two f(n) values
            int n_1 = 1;
            int n_2 = 1;

            for(int i = 2; i < n; i++)
            {
                int n_new = n_1 + n_2;
                n_1 = n_2;
                n_2 = n_new;
            }

            // If n value we started with was negative, convert result back to negative
            if (negative)
            {
                return n_2 * -1;
            }

            return n_2;
        }

        public async Task<string> GetReversedWords(string sentence)
        {
            var result = string.Empty;
            var words = sentence.Split(' ');
            foreach(string word in words)
            {
                var letters = word.ToCharArray();
                Array.Reverse(letters);
                result += new string(letters);
                result += " ";
            }
            return result.TrimEnd();
        }

        public async Task<string> GetToken()
        {
            return TOKEN;
        }

        public async Task<string> GetTriangleType(int sideA, int sideB, int sideC)
        {
            // If lengths are not valid for a triangle
            if (sideA + sideB <= sideC || sideA + sideC <= sideB || sideB + sideC <= sideA)
            {
                return "Error";
            }

            // If any values are not positive
            if (sideA < 0 || sideB < 0 || sideC < 0)
            {
                return "Error";
            }

            // If all lengths are equal
            if (sideA == sideB && sideB == sideC)
            {
                return "Equilateral";
            }

            // If two lengths are equal
            if (sideA == sideB || sideB == sideC || sideA == sideC)
            {
                return "Isosceles";
            }

            // If no lengths are equal
            return "Scalene";
        } 
    }
}
