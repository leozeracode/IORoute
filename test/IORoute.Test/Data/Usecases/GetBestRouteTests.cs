﻿using Moq;
using IORoute.Domain.Models.DTO;
using IORoute.App.Protocols;
using IORoute.App.Usecases;

namespace IORoute.Test.Data.Usecases
{
    public class GetBestRouteTests
    {
        private readonly Mock<ILoadRoutesRepository> _loadRoutesRepository;
        private readonly GetBestRoute _sut;
        private readonly RouteModelViewModel _model;
        public GetBestRouteTests()
        {
            _loadRoutesRepository = new Mock<ILoadRoutesRepository>();
            _sut = new GetBestRoute(_loadRoutesRepository.Object);
            _model = new RouteModelViewModel
            {
                Origin = "GRU",
                Destination = "CDG"
            };
        }


        [Fact]
        public async void Should_Call_LoadRoutes_When_GetRoute_Called()
        {
            var routes = new List<RouteModel>();

            _loadRoutesRepository.Setup(x => x.LoadRoutes()).Returns(routes);

            await _sut.GetRoute(_model);

            _loadRoutesRepository.Verify(x => x.LoadRoutes(), Times.Once);

        }

        [Fact]
        public async void Should_Return_NoRoutesFound_When_NoRoutes_Returned()
        {
            List<RouteModel> routes = null;

            _loadRoutesRepository.Setup(x => x.LoadRoutes()).Returns(routes);

            var result = await _sut.GetRoute(_model);

            Assert.Null(result);
        }

        [Fact]
        public async void Should_Throw_Exception_When_ExceptionThrown()
        {
            _loadRoutesRepository.Setup(x => x.LoadRoutes()).Throws<Exception>();

            await Assert.ThrowsAsync<Exception>(() => _sut.GetRoute(_model));
        }


        [Fact]
        public async void Should_Return_BestRoute_When_RoutesReturned()
        {
            var routes = new List<RouteModel>
            {
                new RouteModel { Origin = "GRU", Destination = "BRC", Cost = 10 },
                new RouteModel { Origin = "BRC", Destination = "SCL", Cost = 5 },
                new RouteModel { Origin = "GRU", Destination = "CDG", Cost = 75 },
                new RouteModel { Origin = "GRU", Destination = "SCL", Cost = 20 },
                new RouteModel { Origin = "GRU", Destination = "ORL", Cost = 56 },
                new RouteModel { Origin = "ORL", Destination = "CDG", Cost = 5 },
                new RouteModel { Origin = "SCL", Destination = "ORL", Cost = 20 }
            };

            _loadRoutesRepository.Setup(x => x.LoadRoutes()).Returns(routes);

            var result = await _sut.GetRoute(_model);

            Assert.Equal("GRU - BRC - SCL - ORL - CDG ao custo de $40", result);
        }
    }
}
