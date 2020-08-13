using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.CTCI.ex_4_7
{
    public class ProjectBuildNode
    {
        public string Name { get; set; }
        public int Dependencies { get; set; }
        public List<ProjectBuildNode> Children { get; set; } = new List<ProjectBuildNode>();
    }
    public class ProjectBuildGraph
    {
        public Hashtable Nodes { get; set; } = new Hashtable();
    }
    public class ex_4_7
    {
        public List<string> FindBuildOrders(List<string> projects, List<Tuple<string, string>> dependencies)
        {
            var graph = this.CreateGraph(projects, dependencies);
            var res = this.OrderProjects(graph);
            return res;
        }

        List<string> OrderProjects(ProjectBuildGraph graph)
        {
            List<string> order = new List<string>();
            Queue<ProjectBuildNode> noDpNodes = new Queue<ProjectBuildNode>();
            var projectNodes = graph.Nodes;
            // TOPOLOGICAL SORT
            // find nodes with no dependencies

            foreach (DictionaryEntry e in projectNodes)
            {
                var projectBuildNode = (ProjectBuildNode)e.Value;
                if (projectBuildNode.Dependencies == 0)
                {
                    noDpNodes.Enqueue(projectBuildNode);
                }
            }
            while (noDpNodes.Count > 0)
            {
                var node = noDpNodes.Dequeue();
                order.Add(node.Name);
                foreach (var pbn in node.Children)
                {
                    pbn.Dependencies--;
                    if (pbn.Dependencies == 0)
                    {
                        noDpNodes.Enqueue(pbn);
                    }
                }
            }

            foreach (DictionaryEntry e in projectNodes)
            {
                var projectBuildNode = (ProjectBuildNode)e.Value;
                if (projectBuildNode.Dependencies > 0)
                {
                    return new List<string>();
                }
            }

            return order;
        }

        ProjectBuildGraph CreateGraph(List<string> allProjects, List<Tuple<string, string>> dependencies)
        {
            ProjectBuildGraph graph = new ProjectBuildGraph();
            foreach (var p in allProjects)
            {
                if (!graph.Nodes.ContainsKey(p))
                {
                    graph.Nodes.Add(p, new ProjectBuildNode() { Name = p });
                }
            }

            foreach (var d in dependencies)
            {
                var node1 = (ProjectBuildNode)graph.Nodes[d.Item1];
                var node2 = (ProjectBuildNode)graph.Nodes[d.Item2];
                node1.Children.Add(node2);
                node2.Dependencies++;
            }
            return graph;
        }
    }
}
