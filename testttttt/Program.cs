﻿//Michał Stasiowski
using System.Collections.Generic;
using System;


namespace lab10
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                IGraph<int, double> graph = new NMatrixGraph(10);
                graph.AddDirectedEdge(1, 2, 2);
                graph.AddDirectedEdge(1, 3, 0.5);
                graph.AddDirectedEdge(2, 3, 2.5);
                graph.AddDirectedEdge(2, 4, 3);
                graph.AddDirectedEdge(3, 5, 2);
                graph.AddUnDirectedEdge(4, 5, 0.5);
                graph.AddDirectedEdge(5, 6, 2);

                if (graph.IsPath(1, 5) && !graph.IsPath(3, 1))
                {
                    Console.WriteLine("Test 1 passed");
                }
                else
                {
                    Console.WriteLine("Test 1 failed");
                }

                if (graph.CanReturn(5) && !graph.CanReturn(1))
                {
                    Console.WriteLine("Test 2 passed");
                }
                else
                {
                    Console.WriteLine("Test 2 failed");
                }

                List<int> list = graph.Neigbours(2);
                if (list.Count == 2 && list.Contains(3) && list.Contains(4))
                {
                    Console.WriteLine("Test 3 passed");
                }
                else
                {
                    Console.WriteLine("Test 3 failed");
                }

                List<Edge<int, double>> path = graph.GetShortestPath(2, 5);
                if (path.Count == 2 && path[0].Node == 4 && path[1].Node == 5 && path[0].Weight == 3 && path[1].Weight == 0.5)
                {
                    Console.WriteLine("Test 4 passed");
                }
                else
                {
                    Console.WriteLine("Test 4 failed");
                }

            }
            catch
            {
                Console.WriteLine("Method not implemented");
            }
        }
    }

    public class Edge<T, W> : IComparable<Edge<T, W>> where W : IComparable<W>
    {
        public T Node { get; set; }
        public W Weight { get; set; }

        public int CompareTo(Edge<T, W>? other)
        {
            return Weight.CompareTo(other.Weight);
        }
    }

    public interface IGraph<T, W> where W : IComparable<W>
    {
        public void AddDirectedEdge(T source, T target, W weight);
        public void AddUnDirectedEdge(T node1, T node2, W weight);

        public bool IsPath(T start, T end);
        public bool CanReturn(T start);
        public List<T> Neigbours(T node);

        public void Traversal(T start, Action<T> action);

        public List<Edge<T, W>> GetShortestPath(T start, T end);


    }

    /* implementacja z użyciem macierzy sąsiedztw   */
    public class NMatrixGraph : IGraph<int, double>
    {
        private List<List<Edge<int, double>>> newlist;

        public NMatrixGraph(int max)
        {
            // max jest liczbą wezłów
            // wierzcholki moga miec numery od 0 do max-1

            newlist = new List<List<Edge<int, double>>>();
            for (int i = 0; i < max; i++)
            {
                newlist.Add(new List<Edge<int, double>>());
            }

        }

        public void AddDirectedEdge(int source, int target, double weight)
        {
            newlist[source].Add(new Edge<int, double> { Node = target, Weight = weight });
        }

        public void AddUnDirectedEdge(int node1, int node2, double weight)
        {

            newlist[node1].Add(new Edge<int, double> { Node = node2, Weight = weight });
            newlist[node2].Add(new Edge<int, double> { Node = node1, Weight = weight });

        }

        public bool CanReturn(int start)
        {

            /* sprawdza czy istnieje droga powrotna dla danego wierzchołka */


            bool[] visitedPath = new bool[newlist.Count];

            Queue<int> queue = new Queue<int>();

            queue.Enqueue(start);
            visitedPath[start] = true;

            while (queue.Count != 0)
            {

                int node = queue.Dequeue();
                foreach (var neighbor in newlist[node])
                {


                    if (!visitedPath[neighbor.Node])
                    {
                        visitedPath[neighbor.Node] = true;
                        queue.Enqueue(neighbor.Node);
                    }


                    if (neighbor.Node == start)
                    {

                        return true;
                    }


                }


            }
            return false;
        }

        public List<Edge<int, double>> GetShortestPath(int start, int end)
        {

            /* szuka i zwraca najkrótszą drogę między dwoma wierzchołkami */



            var shortestpath = new List<Edge<int, double>>();

            double[] distance = new double[newlist.Count];

            int[] parent = new int[newlist.Count];



            for (int i = 0; i < newlist.Count; i++)
            {
                distance[i] = double.PositiveInfinity;
            }

            distance[start] = 0;

            for (int i = 0; i < newlist.Count - 1; i++)
            {

                for (int j = 0; j < newlist.Count; j++)
                {

                    for (int k = 0; k < newlist[j].Count; k++)
                    {
                        int neighbor = newlist[j][k].Node;
                        double weight = newlist[j][k].Weight;
                        if (distance[neighbor] > distance[j] + weight)
                        {
                            distance[neighbor] = distance[j] + weight;
                            parent[neighbor] = j;
                        }


                    }

                }

            }


            if (distance[end] == double.PositiveInfinity)
            {
                return shortestpath;
            }

            int currentP = end;

            while (currentP != start)
            {
                var edge = new Edge<int, double> { Node = currentP, Weight = distance[currentP] - distance[parent[currentP]] };
                shortestpath.Insert(0, edge);
                currentP = parent[currentP];
            }

            return shortestpath;
        }

        public bool IsPath(int start, int end)
        {

            /*  sprawdza czy istnieje droga między dwoma wierzchołkami */


            var queue = new Queue<int>();
            var visitedPath = new HashSet<int>();


            queue.Enqueue(start);
            visitedPath.Add(start);

            while (queue.Count > 0)
            {
                var currentP = queue.Dequeue();
                if (currentP == end)
                {
                    return true;
                }

                foreach (var edge in newlist[currentP])
                {
                    if (!visitedPath.Contains(edge.Node))
                    {
                        queue.Enqueue(edge.Node);
                        visitedPath.Add(edge.Node);
                    }
                }
            }

            return false;

        }

        public List<int> Neigbours(int node)
        {

            /*  zwracaja listę sąsiadów dla danego wierzchołka */

            var neighbours = new List<int>();


            foreach (var edge in newlist[node])
            {
                neighbours.Add(edge.Node);
            }


            return neighbours;
        }

        public void Traversal(int start, Action<int> action)
        {

            /* przechodzi przez graf */


            var queue = new Queue<int>();
            var visited = new HashSet<int>();

            queue.Enqueue(start);
            visited.Add(start);

            while (queue.Count > 0)
            {
                var currentP = queue.Dequeue();
                action(currentP);

                foreach (var edge in newlist[currentP])
                {
                    if (!visited.Contains(edge.Node))
                    {
                        queue.Enqueue(edge.Node);
                        visited.Add(edge.Node);
                    }
                }


            }


        }




    }
}
