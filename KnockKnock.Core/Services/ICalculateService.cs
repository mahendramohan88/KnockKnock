using System;
using System.Threading.Tasks;

namespace KnockKnock.Core
{
    public interface ICalculateService
    {
        Task<long> GetFibonacci(long n);
        Task<string> GetReversedWords(string sentence);
        Task<string> GetToken();
        Task<string> GetTriangleType(int sideA, int sideB, int sideC);
        
    }
}