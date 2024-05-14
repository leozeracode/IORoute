using IORoute.Domain.Models.DTO;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using IORoute.API;
using System.Net;

namespace IORoute.Test.API.Controllers
{
    public class RouteControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public RouteControllerIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetBestRoute_ShouldReturn_BestRoute_1()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("/api/v1/route?origin=GRU&destination=CDG");

            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Equal("GRU - BRC - SCL - ORL - CDG ao custo de $40,00", responseString);
        }

        [Fact]
        public async Task GetBestRoute_ShouldReturn_BestRoute_2()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("/api/v1/route?origin=BRC&destination=SCL");

            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Equal("BRC - SCL ao custo de $5,00", responseString);
        }

        [Fact]
        public async Task GetBestRoute_ShouldReturn_BestRoute_3()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("/api/v1/route?origin=GRU&destination=ORL");

            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Equal("GRU - BRC - SCL - ORL ao custo de $35,00", responseString);
        }

        [Fact]
        public async Task GetBestRoute_ShouldNotReturn_BestRoute()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("/api/v1/route?origin=GRU&destination=XYZ");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task GetBestRoute_ShouldReturn_BadRequest()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("/api/v1/route?origin=GRU");

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }


        [Fact]
        public async Task GetBestRoute_ShouldReturn_NotFound_When_Route_Not_Found()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("/api/v1/myawesome/route?origin=GRU&destination=XYZ");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
