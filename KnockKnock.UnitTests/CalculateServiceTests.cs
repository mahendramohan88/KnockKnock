using KnockKnock.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace KnockKnock.UnitTests
{
    [TestClass]
    public class CalculateServiceTests
    {
        private readonly ICalculateService _calculateService;

        public CalculateServiceTests()
        {
            _calculateService = new CalculateService();
        }

        [TestMethod]
        public async Task GetToken_ReturnsCorrectToken()
        {
            var expected = "1a39b7a7-92d3-4d06-84ad-782131fad8f1";
            var actual = await _calculateService.GetToken();

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(0, 0)]
        [DataRow(1, 1)]
        [DataRow(-1, 1)]
        [DataRow(6, 8)]
        [DataRow(7, 13)]
        [DataRow(8, 21)]
        [DataRow(9, 34)]
        [DataRow(10, 55)]
        [DataRow(-6, -8)]
        [DataRow(-7, -13)]
        [DataRow(-8, -21)]
        [DataRow(-9, -34)]
        [DataRow(-10, -55)]
        public async Task GetFibonacci_ReturnsCorrectValue(int n, int expected)
        {
            var actual = await _calculateService.GetFibonacci(n);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task GetReversedWords_ReturnsCorrectValue()
        {
            var expected = "kciuq nworb xof";
            var actual = await _calculateService.GetReversedWords("quick brown fox");

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(5, 5, 5, "Equilateral")]
        [DataRow(5, 5, 4, "Isosceles")]
        [DataRow(5, 4, 3, "Scalene")]
        [DataRow(5, 3, 1, "Error")]
        public async Task GetTriangleType_ReturnsCorrectValue(int sideA, int sideB, int sideC, string expected)
        {
            var actual = await _calculateService.GetTriangleType(sideA, sideB, sideC);

            Assert.AreEqual(expected, actual);
        }
    }
}
