using System;
using System.Collections.Generic;

namespace MunicipalServicesApp
{
    public class Graph
    {
        private Dictionary<int, List<int>> _adjList;

        public Graph()
        {
            _adjList = new Dictionary<int, List<int>>();
        }

        // Add an edge from one request to another (ensure no duplicates)
        public void AddEdge(int from, int to)
        {
            if (!_adjList.ContainsKey(from))
                _adjList[from] = new List<int>();

            // Add the edge only if it doesn't already exist
            if (!_adjList[from].Contains(to))
            {
                _adjList[from].Add(to);
            }
        }

        // Get all dependencies (edges) for a specific request
        public List<int> GetDependencies(int requestID)
        {
            if (_adjList.ContainsKey(requestID))
            {
                return _adjList[requestID];
            }
            return new List<int>(); // Return empty list if no dependencies
        }

        // Get all edges in the graph
        public List<(int from, int to)> GetAllEdges()
        {
            List<(int from, int to)> edges = new List<(int from, int to)>();

            foreach (var key in _adjList.Keys)
            {
                foreach (var neighbor in _adjList[key])
                {
                    edges.Add((key, neighbor));
                }
            }

            return edges;
        }

        // Check if an edge exists between two requests
        public bool HasEdge(int from, int to)
        {
            if (_adjList.ContainsKey(from))
            {
                return _adjList[from].Contains(to); // Check if 'to' exists in the adjacency list of 'from'
            }
            return false;
        }

        // Breadth-First Search (BFS) traversal starting from a node
        public List<int> BFS(int start)
        {
            Queue<int> queue = new Queue<int>();
            List<int> visited = new List<int>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                int node = queue.Dequeue();
                if (!visited.Contains(node))
                {
                    visited.Add(node);
                    foreach (var neighbor in _adjList[node])
                        queue.Enqueue(neighbor);
                }
            }

            return visited;
        }

        // Depth-First Search (DFS) traversal starting from a node
        public List<int> DFS(int start)
        {
            Stack<int> stack = new Stack<int>();
            List<int> visited = new List<int>();
            stack.Push(start);

            while (stack.Count > 0)
            {
                int node = stack.Pop();
                if (!visited.Contains(node))
                {
                    visited.Add(node);
                    foreach (var neighbor in _adjList[node])
                        stack.Push(neighbor);
                }
            }

            return visited;
        }

        // Optional method for displaying the graph in a simple format (for debugging purposes)
        public void DisplayGraph()
        {
            foreach (var node in _adjList)
            {
                Console.WriteLine($"Request {node.Key}: ");
                foreach (var dependency in node.Value)
                {
                    Console.WriteLine($"  -> Dependent on Request {dependency}");
                }
            }
        }
    }
}
