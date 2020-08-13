using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.CTCI
{
    public class ProjectBuildNode
    {
        public string Name { get; set; }
        public int Dependencies { get; set; }
        public List<ProjectBuildNode> Children { get; set; } = new List<ProjectBuildNode>();
    }
    public class ProjectBuildTree
    {
        public ProjectBuildNode Root { get; set; }
    }
    public class ex_4_7_incomplete
    {
        public List<string> GetBuildOrder(List<string> projects, List<Tuple<string, string>> dependencies)
        {
            var buildTree = this.ConstructBuildTree(dependencies);
            if (buildTree == null)
            {
                return new List<string> { "ERROR" };
            }
            // post order traversal
            List<string> res = new List<string>();
            PostOrder(res, buildTree.Root);
            if (res == null)
            {
                return new List<string> { "ERROR" };
            }
            var standaloneProjects = this.GetStandAloneProjects(res, projects);
            res.AddRange(standaloneProjects);
            return res;
        }

        private List<string> GetStandAloneProjects(List<string> builtProjects, List<string> inputProjects)
        {
            Hashtable projects = new Hashtable();
            foreach (var bp in inputProjects)
            {
                if (projects.ContainsKey(bp))
                {
                    projects[bp] = (int)projects[bp] + 1;
                }
                else
                {
                    projects[bp] = 0;
                }
            }
            foreach (var bp in builtProjects)
            {
                if (projects.ContainsKey(bp))
                {
                    projects[bp] = (int)projects[bp] + 1;
                }
                else
                {
                    projects[bp] = 0;
                }
            }

            List<string> res = new List<string>();
            foreach (var key in projects.Keys)
            {
                if ((int)projects[key] == 0)
                {
                    res.Add(key.ToString());
                }
            }
            return res;
        }
        private void PostOrder(List<string> res, ProjectBuildNode root)
        {
            if (res == null)
            {
                return;
            }
            if (root == null)
            {
                return;
            }

            for (int i = 0; i < root.Children.Count; i++)
            {
                PostOrder(res, root.Children[i]);
            }

            if (!res.Contains(root.Name))
            {
                res.Add(root.Name);
            }
            else
            {
                res = null;
                return;

            }
        }
        private ProjectBuildTree ConstructBuildTree(List<Tuple<string, string>> dependencies)
        {
            if (dependencies.Count == 0)
            {
                return null;
            }

            Tuple<string, string> it = dependencies[0];
            ProjectBuildNode root = null;
            Queue<Tuple<string, string, int>> queue = new Queue<Tuple<string, string, int>>();
            for (int i = 0; i < dependencies.Count; i++)
            {
                queue.Enqueue(new Tuple<string, string, int>(dependencies[i].Item1, dependencies[i].Item2, 0));
            }
            while (queue.Count > 0)
            {
                var dependency = queue.Dequeue();
                if (dependency.Item3 > 1)
                {
                    return null; // ERROR
                }
                if (root == null)
                {
                    root = new ProjectBuildNode()
                    {
                        Name = dependency.Item2
                    };
                    root.Children.Add(new ProjectBuildNode()
                    {
                        Name = dependency.Item1
                    });
                }
                else
                {
                    // find node with item 2
                    var item2Node = FindNode(root, dependency.Item2, new List<ProjectBuildNode>());
                    if (item2Node != null && item2Node.Name != dependency.Item2)
                    {
                        return null;
                    }

                    var item1Node = FindNode(root, dependency.Item1, new List<ProjectBuildNode>());
                    if (item1Node != null && item1Node.Name != dependency.Item1)
                    {
                        return null;
                    }
                    if (item2Node != null)
                    {
                        if (item1Node != null)
                        {
                            item2Node.Children.Add(item1Node);
                        }
                        else
                        {
                            item2Node.Children.Add(new ProjectBuildNode()
                            {
                                Name = dependency.Item1
                            });
                        }

                    }
                    else
                    {
                        // find node with item1
                        if (item1Node != null)
                        {
                            var parent = new ProjectBuildNode()
                            {
                                Name = dependency.Item2
                            };
                            parent.Children.Add(item1Node);
                            root = parent;
                        }
                        else
                        {
                            queue.Enqueue(new Tuple<string, string, int>(dependency.Item1, dependency.Item2, dependency.Item3 + 1));
                        }
                    }
                }
            }
            return new ProjectBuildTree()
            {
                Root = root
            };
        }

        private ProjectBuildNode FindNode(ProjectBuildNode root, string name, List<ProjectBuildNode> tmp)
        {
            if (root == null)
            {
                return null;
            }
            if (root.Name == name)
            {
                return root;
            }

            ProjectBuildNode res = null;
            for (int i = 0; i < root.Children.Count; i++)
            {
                if (tmp.Contains(root.Children[i]))
                {
                    return new ProjectBuildNode()
                    {
                        Name = "ERROR"
                    };
                }
                tmp.Add(root.Children[i]);
                res = FindNode(root.Children[i], name, tmp);
                if (res != null)
                {
                    break;
                }
            }
            return res;
        }
    }
}
