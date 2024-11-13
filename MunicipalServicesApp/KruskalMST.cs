using System.Collections.Generic;

namespace MunicipalServicesApp
{
    public class KruskalMST
    {
        public class Edge
        {
            public int Start { get; set; }
            public int End { get; set; }
            public int Weight { get; set; }

            public Edge(int start, int end, int weight)
            {
                Start = start;
                End = end;
                Weight = weight;
            }
        }

        private List<Edge> _edges;

        public KruskalMST()
        {
            _edges = new List<Edge>();
        }

        public void AddEdge(int start, int end, int weight)
        {
            _edges.Add(new Edge(start, end, weight));
        }

        public List<Edge> Run()
        {
            _edges.Sort((x, y) => x.Weight.CompareTo(y.Weight));

            List<Edge> result = new List<Edge>();
            DisjointSet ds = new DisjointSet();

            foreach (var edge in _edges)
            {
                if (ds.Find(edge.Start) != ds.Find(edge.End))
                {
                    result.Add(edge);
                    ds.Union(edge.Start, edge.End);
                }
            }

            return result;
        }
    }

    public class DisjointSet
    {
        private Dictionary<int, int> _parent;

        public DisjointSet()
        {
            _parent = new Dictionary<int, int>();
        }

        public int Find(int x)
        {
            if (_parent[x] != x)
                _parent[x] = Find(_parent[x]);
            return _parent[x];
        }

        public void Union(int x, int y)
        {
            int rootX = Find(x);
            int rootY = Find(y);

            if (rootX != rootY)
                _parent[rootX] = rootY;
        }
    }
}

