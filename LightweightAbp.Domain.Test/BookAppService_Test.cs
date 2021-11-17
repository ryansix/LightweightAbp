using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Extensions.DependencyInjection;

namespace LightweightAbp.Domain.Test
{
    public class BookAppService_Test : TestBase
    {
        private   IBookAppService _bookAppService;
        public BookAppService_Test()
        {
            _bookAppService = GetRequiredService<IBookAppService>();
        }
        [Fact]
        public async Task CreateAsync()
        { 
            string name = "ryanx";
            var book = await _bookAppService.CreateAsync(name);

        }
        [Fact]
        public async Task GetAllAsync()
        {
            var res = await _bookAppService.GetAllAsync();
            Assert.Equal(res.Length, 1);
        }
    }
}
