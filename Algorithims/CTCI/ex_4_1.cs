using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.CTCI
{

    public class ex_4_1
    {
        public bool IsConnected<T>(DirectedGraph<T> graph, GraphNode<T> node1, GraphNode<T> node2)
        {
            Queue<GraphNode<T>> q1 = new Queue<GraphNode<T>>();
            Queue<GraphNode<T>> q2 = new Queue<GraphNode<T>>();
            q1.Enqueue(node1);
            q2.Enqueue(node2);
            List<GraphNode<T>> visited = new List<GraphNode<T>>();
            while (q1.Count > 0)
            {
                var n1 = q1.Dequeue();
                if (n1 == node2)
                {
                    return true;
                }

                visited.Add(n1);
                // visited.Add(n2);

                foreach (var graphNode in n1.Adjacents)
                {
                    if (!visited.Contains(graphNode))
                        q1.Enqueue(graphNode);
                }
                //foreach (var graphNode in n2.Adjacents)
                //{
                //    if (!visited.Contains(graphNode))
                //        q2.Enqueue(graphNode);
                //}
            }

            return false;
        }
    }
}
