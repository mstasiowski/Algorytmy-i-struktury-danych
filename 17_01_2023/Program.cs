//Michał Stasiowski
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

                if(graph.IsPath(1, 5) && !graph.IsPath(3,1))
                {
                    Console.WriteLine("Test 1 passed");
                }else
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
                if (list.Count ==2 && list.Contains(3) && list.Contains(4))
                {
                    Console.WriteLine("Test 3 passed");
                }
                else
                {
                    Console.WriteLine("Test 3 failed");
                }

                List<Edge<int, double>> path = graph.GetShortestPath(2, 5);
                if (path.Count ==2 && path[0].Node ==4 &&path[1].Node ==5 && path[0].Weight ==3 && path[1].Weight == 0.5)
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

    public class  Edge<T,W>:IComparable<Edge<T,W>> where W: IComparable<W>
    {
        public T Node { get; set; }
        public W Weight { get; set; }

        public int CompareTo(Edge<T, W>? other)
        {
           return Weight.CompareTo(other.Weight);
        }
    }

    public interface IGraph<T, W> where  W:IComparable<W>
    {
        public void AddDirectedEdge(T source, T target, W weight);
        public void AddUnDirectedEdge(T node1, T node2, W weight);

        public bool IsPath(T start, T end);
        public bool CanReturn(T start);
        public List<T> Neigbours(T node);

        public void Traversal(T start, Action<T> action);

        public List<Edge<T, W>> GetShortestPath(T start, T end);


    }

    /* implementacja z użyciem macierzy sąsiedztw  
     */
    public class NMatrixGraph : IGraph<int, double>
    {
        public NMatrixGraph(int max)
        {
        }

        public void AddDirectedEdge(int source, int target, double weight)
        {
            throw new NotImplementedException();
        }

        public void AddUnDirectedEdge(int node1, int node2, double weight)
        {
            throw new NotImplementedException();
        }

        public bool CanReturn(int start)
        {
            throw new NotImplementedException();
        }

        public List<Edge<int, double>> GetShortestPath(int start, int end)
        {
            throw new NotImplementedException();
        }

        public bool IsPath(int start, int end)
        {
            throw new NotImplementedException();
        }

        public List<int> Neigbours(int node)
        {
            throw new NotImplementedException();
        }

        public void Traversal(int start, Action<int> action)
        {
            throw new NotImplementedException();
        }
    }
}
