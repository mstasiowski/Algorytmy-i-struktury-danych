//Michał Stasiowski
using System.Collections.Generic;
using System;
namespace lab10
{

    public static class Program
    {

        public static void Main(string[] args)
        {
            IGraph<int, double> graph = new NMatrixGraph(10);
            graph.AddDirectedEdge(1, 2, 2);
            graph.AddDirectedEdge(1, 3, 0.5);
            graph.AddDirectedEdge(2, 3, 2.5);
            graph.AddDirectedEdge(2, 4, 3);
            graph.AddDirectedEdge(3, 5, 2);
            graph.AddUndirectedEdge(4, 5, 0.5);
            graph.AddDirectedEdge(5, 6, 2);


            try
            {
                // Test 1
                if (graph.IsPath(1, 5) && !graph.IsPath(3, 1))
                {
                    Console.WriteLine("T1 passed");
                }
                else
                {
                    Console.WriteLine("T1 failed");
                }

                // Test 2
                if (graph.CanReturn(5) && !graph.CanReturn(1))
                {
                    Console.WriteLine("T2 passed");
                }
                else
                {
                    Console.WriteLine("T2 failed");
                }

                // Test 3
                List<int> list = graph.Neighbours(2);

                if (list.Count == 2 && list.Contains(3) && list.Contains(4))
                {
                    Console.WriteLine("T3 passed");
                }
                else
                {
                    Console.WriteLine("T3 failed");
                }

                // Test 4
                List<Edge<int, double>> path = graph.GetShortestPath(2, 5);
                if (path.Count == 2 & path[0].Node == 4 && path[1].Node == 5 && path[0].Weight == 3 && path[1].Weight == 0.5)
                {
                    Console.WriteLine("T4 passed");
                }
                else
                {
                    Console.WriteLine("T4 failed");
                }
            }
            catch
            {
                Console.WriteLine("Methods not implemented");
            }
        }
    }

    // t wierzcholek, w waga
    public class Edge<T, W> : IComparable<Edge<T, W>> where W : IComparable<W>
    {
        public T Node { get; set; }
        // poniĹĽej sam utworzyĹ‚em zmiennÄ…, bo nie pamiÄ™tam jak bez niej zaznaczyÄ‡ dokÄ…d prowadzi dana krawÄ™dĹş
        public T Destination { get; set; }
        public W Weight { get; set; }

        public int CompareTo(Edge<T, W>? other)
        {
            return Weight.CompareTo(other.Weight);
        }
    }

    public interface IGraph<T, W> where W : IComparable<W>
    {
        public List<Edge<int, double>> Graph { get; set; }
        // dodaja krawedzie
        public void AddDirectedEdge(T source, T target, W weight);
        // undirected robi od razu 2 krawedzie tak jakby, bo takze w druga strone
        public void AddUndirectedEdge(T node1, T node2, W weight);
        // zwraca true jesli mozna przejsc z wezla start do wezla end
        public bool IsPath(T start, T end);
        // sprawdznie cyklu (czy po wyjsciu z wezla mozna wrocic do niego)
        public bool CanReturn(T start);
        // zwraca liste sasiadow
        public List<T> Neighbours(T node);
        // chcemy odwiedzic kazdy wezel i wywolujemy na nim start (action.Invoke);
        // ma odwiedzac kazdy wezel tylko raz (rozpoznawac cykle?)
        public void Traversal(T start, Action<T> action);
        // zwraca najkrĂłtszÄ… Ĺ›cieĹĽkÄ™ miÄ™dzy wÄ™zĹ‚ami 
        public List<Edge<T, W>> GetShortestPath(T start, T end);

    }

    // nmatrix to macierz sasiedztw
    public class NMatrixGraph : IGraph<int, double>
    {
        public List<Edge<int, double>> Graph { get; set; }
        public NMatrixGraph(int max)
        {
            // max to liczba wezlow
            // wierzcholki moga miec numery od 0 do max-1
            this.Graph = new List<Edge<int, double>>();
        }

        public void AddDirectedEdge(int source, int target, double weight)
        {
            Edge<int, double> edge = new Edge<int, double> { Node = source, Destination = target, Weight = weight };
            this.Graph.Add(edge);
        }

        public void AddUndirectedEdge(int node1, int node2, double weight)
        {
            Edge<int, double> edge = new Edge<int, double> { Node = node1, Destination = node2, Weight = weight };
            Edge<int, double> reverseEdge = new Edge<int, double> { Node = node2, Destination = node1, Weight = weight };
            this.Graph.Add(edge);
            this.Graph.Add(reverseEdge);
        }

        public bool CanReturn(int start)
        {

            foreach (Edge<int, double> edge in this.Graph)
            {
                if (edge.Node == start)
                {
                    List<int> checkedNodes = new List<int>();

                    bool result = CanReturnRecursive(edge, edge.Node, checkedNodes);
                    if (result == true)
                    {
                        return result;
                    }
                }
            }

            return false;
        }

        public bool CanReturnRecursive(Edge<int, double> edge, int target, List<int> checkedNodes)
        {
            if (edge.Destination == target)
            {
                return true;
            }
            else
            {
                foreach (Edge<int, double> furtherEdge in this.Graph)
                {
                    if (furtherEdge.Node == edge.Destination && !checkedNodes.Contains(edge.Destination))
                    {
                        checkedNodes.Add(furtherEdge.Node);
                        return IsPathRecursive(furtherEdge, target, checkedNodes);
                    }
                }
            }
            return false;

        }

        public List<Edge<int, double>> GetShortestPath(int start, int end)
        {
            throw new NotImplementedException();
        }

        public bool IsPath(int start, int end)
        {

            foreach (Edge<int, double> edge in this.Graph)
            {
                if (edge.Node == start)
                {
                    if (edge.Destination == end)
                    {
                        return true;
                    }
                    List<int> checkedNodes = new List<int>();
                    checkedNodes.Add(edge.Node);
                    bool result = IsPathRecursive(edge, end, checkedNodes);
                    if (result == true)
                    {
                        return result;
                    }
                }
            }

            return false;
        }

        public bool IsPathRecursive(Edge<int, double> edge, int target, List<int> checkedNodes)
        {
            if (edge.Destination == target)
            {
                return true;
            }
            else
            {
                foreach (Edge<int, double> furtherEdge in this.Graph)
                {
                    if (furtherEdge.Node == edge.Destination && !checkedNodes.Contains(edge.Destination))
                    {
                        checkedNodes.Add(furtherEdge.Node);
                        return IsPathRecursive(furtherEdge, target, checkedNodes);
                    }
                }
            }
            return false;

        }

        public List<int> Neighbours(int node)
        {
            List<int> neighbours = new List<int>();
            foreach (Edge<int, double> edge in this.Graph)
            {
                if (edge.Node == node)
                {
                    neighbours.Add(edge.Destination);
                }
            }
            return neighbours;
        }

        public void Traversal(int start, Action<int> action)
        {
            throw new NotImplementedException();
        }
    }




}
