using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.CTCI
{
    public class GraphNode<T>
    {
        public T Value
        {
            get; set;
        }

        public List<GraphNode<T>> Adjacents { get; set; } = new List<GraphNode<T>>();
    }
    public class DirectedGraph<T>
    {
        public List<GraphNode<T>> Nodes { get; set; } = new List<GraphNode<T>>();
    }
}
