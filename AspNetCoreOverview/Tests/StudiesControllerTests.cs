using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Web.Api;
using Web.Api.Controllers;
using Xunit;

namespace Tests
{
    public class StudiesControllerTests
    {
        private readonly TestServer _server;

        public StudiesControllerTests()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
        }

        [Fact]
        public async Task List_ReturnsArrayOfStudies()
        {
            var client = _server.CreateClient();
            var response = await client.GetAsync("/studies");

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var body = await response.Content.ReadAsStringAsync();
            var studies = JsonConvert.DeserializeObject<Study[]>(body);

            studies.Should().BeEquivalentTo(new[]
            {
                new Study {Id = 1, Title = "My Study"},
                new Study {Id = 2, Title = "Another Study"}
            });
        }
    }
}
