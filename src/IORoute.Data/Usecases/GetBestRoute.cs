using System;
using System.Collections.Generic;
using System.Linq;
using IORoute.Data.Protocols;
using IORoute.Domain.Models.DTO;
using IORoute.Domain.Usecases;

namespace IORoute.Data.Usecases
{
    public class GetBestRoute : IGetBestRoute
    {
        private readonly ILoadRoutesRepository _loadRoutesRepository;

        public GetBestRoute(ILoadRoutesRepository loadRoutesRepository)
        {
            _loadRoutesRepository = loadRoutesRepository;
        }

        public Task<string> GetRoute(string origin, string destination)
        {
            var routes = _loadRoutesRepository.LoadRoutes();
            if (routes == null)
            {
                return Task.FromResult<string>(null);
            }

            var graph = CreateGraph(routes);

            if (!graph.ContainsKey(origin) || !graph.ContainsKey(destination))
            {
                return Task.FromResult<string>(null);
            }

            var minimumCost = new Dictionary<string, decimal>();
            var previous = new Dictionary<string, string>();
            var notVisited = new HashSet<string>();

            foreach (var vertex in graph.Keys)
            {
                minimumCost[vertex] = int.MaxValue;
                previous[vertex] = null;
                notVisited.Add(vertex);
            }

            minimumCost[origin] = 0;

            while (notVisited.Count > 0)
            {
                var currentVertex = notVisited.OrderBy(vertex => minimumCost[vertex]).First();
                notVisited.Remove(currentVertex);

                if (currentVertex == destination)
                {
                    var path = new List<string>();
                    while (previous[currentVertex] != null)
                    {
                        path.Add(currentVertex);
                        currentVertex = previous[currentVertex];
                    }

                    path.Add(origin);
                    path.Reverse();
                    return Task.FromResult(string.Join(" - ", path) + " ao custo de $" + minimumCost[destination]);
                }

                if (!graph.ContainsKey(currentVertex)) continue;

                foreach (var neighbor in graph[currentVertex])
                {
                    var alternativeCost = minimumCost[currentVertex] + neighbor.Value;
                    if (alternativeCost < minimumCost[neighbor.Key])
                    {
                        minimumCost[neighbor.Key] = alternativeCost;
                        previous[neighbor.Key] = currentVertex;
                    }
                }
            }

            return Task.FromResult<string>(null);
        }


        private Dictionary<string, Dictionary<string, decimal>> CreateGraph(IEnumerable<RouteModel> routes)
        {
            var graph = new Dictionary<string, Dictionary<string, decimal>>();

            foreach (var route in routes)
            {
                if (!graph.ContainsKey(route.Origin))
                {
                    graph[route.Origin] = new Dictionary<string, decimal>();
                }

                if (!graph.ContainsKey(route.Destination))
                {
                    graph[route.Destination] = new Dictionary<string, decimal>();
                }

                graph[route.Origin][route.Destination] = route.Cost;

                graph[route.Destination][route.Origin] = route.Cost;
            }

            return graph;
        }
    }
}
