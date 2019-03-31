using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KnockKnock.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KnockKnock.Web.Controllers
{
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly ICalculateService _calculateService;

        public MainController(ICalculateService calculateService)
        {
            _calculateService = calculateService;
        }

        [Route("api/Fibonacci")]
        public async Task<IActionResult> Fibonacci(long n)
        {
            if(n <= -94 || n >= 94)
            {
                return BadRequest();
            }

            return Ok(await _calculateService.GetFibonacci(n));
        }

        [Route("api/ReverseWords"), Produces("application/json")]
        public async Task<IActionResult> ReverseWords(string sentence)
        {
            return Ok(await _calculateService.GetReversedWords(sentence));
        }

        [Route("api/Token"), Produces("application/json")]
        public async Task<IActionResult> Token()
        {
            return Ok(await _calculateService.GetToken());
        }

        [Route("api/TriangleType"), Produces("application/json")]
        public async Task<IActionResult> TriangleType(int a, int b, int c)
        {
            return Ok(await _calculateService.GetTriangleType(a, b, c));
        }
    }
}