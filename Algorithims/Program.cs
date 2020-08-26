using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using Algorithms.CTCI;
using Algorithms.CTCI.ex_4_7;
using Algorithms.CTCI.OOODesigns.ex_7_2;
using Algorithms.CTCI.SortingAndSearching;
using Algorithms.DailyInterviewPro;
using Algorithms.Search;
using Algorithms.Sort;

namespace Algorithms
{
    class Result
    {

        /*
         * Complete the 'getTotalGoals' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. STRING team
         *  2. INTEGER year
         */
        public enum TeamType
        {
            Team1,
            Team2
        }
        public static int getTotalGoals(string team, int year)
        {
            int count = 0;
            int page = 1;
            int totalPage = 0;
            GetMatchDetailsPerPage(team, year, 1, TeamType.Team1, ref totalPage);
            do
            {
                int c = GetMatchDetailsPerPage(team, year, page++, TeamType.Team1, ref totalPage);
                count += c != -1 ? c : 0;
            } while (page <= totalPage);
            page = 1;
            GetMatchDetailsPerPage(team, year, 1, TeamType.Team2, ref totalPage);
            do
            {
                int c = GetMatchDetailsPerPage(team, year, page++, TeamType.Team2, ref totalPage);
                count += c != -1 ? c : 0;
            } while (page <= totalPage);
            return count;
        }
        private static int ParseMatch(string json)
        {
            Regex competitionReg = new Regex(@"(?<=\[).*?(?=\])", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var compMatches = competitionReg.Matches(json);
            var competition = compMatches[0].Groups[0].Value;
            Regex matchReg = new Regex(@"(?<=\{).*?(?=\})", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var mMatches = matchReg.Matches(competition);
            int count = 0;
            bool counted = false;
            Regex team1goalsReg = new Regex(@"(""team1goals"":"")(\d+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            Regex team2goalsReg = new Regex(@"(""team2goals"":"")(\d+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            foreach (Match match in mMatches)
            {
                var obj = match.Groups[0].Value;
                if (Regex.IsMatch(obj, $"\"team1\":\"Barcelona\""))
                {
                    counted = true;
                    var team1Goals = team1goalsReg.Match(obj);
                    count += int.Parse(team1Goals.Groups[2].Value);
                }
                else if (Regex.IsMatch(obj, $"\"team2\":\"Barcelona\""))
                {
                    counted = true;
                    var team2Goals = team1goalsReg.Match(obj);
                    count += int.Parse(team2Goals.Groups[2].Value);
                }
            }
            return counted ? count : -1;
        }
        private static int GetMatchDetailsPerPage(string team, int year, int page, TeamType tt, ref int totalPages)
        {
            string tm = "";
            switch (tt)
            {
                case TeamType.Team1:
                    tm = "team1=" + team;
                    break;
                case TeamType.Team2:
                    tm = "team2=" + team;
                    break;
            }
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://jsonmock.hackerrank.com/api/football_matches?year={year}&{tm}&page={page}");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                string body = reader.ReadToEnd();
                Regex totalPageReg = new Regex(@"(""total_pages"":)(\d+)");
                totalPages = int.Parse(totalPageReg.Match(body).Groups[2].Value);
                return ParseMatch(body);
            }
            return -1;
        }
    }
    class Program
    {
        static int MySqrt(int x)
        {
            if (x == 0) return 0;
            if (x == 1) return 1;
            for (int i = 0; i <= x / 2; i++)
            {
                ulong ii = (ulong)i * (ulong)i;
                ulong i1 = (ulong)(i + 1) * (ulong)(i + 1);
                if (ii <= (ulong)x && i1 > (ulong)x)
                {
                    return i;
                }
            }
            return -1;
        }
        static void Main(string[] args)
        {
            int[] arr = new int[] { 23, 23,23,23,23,23,23,23,23,23,23,23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23 };
            Console.WriteLine(arr.Length);
            var ex = new FindFirstAndLastOccurencesOfATarget();
            int[] res = ex.Solve(arr, 23);
            Console.WriteLine(res[0]);
            Console.WriteLine(res[1]);
            Console.ReadKey();
        }
        static void ex101()
        {
            var arr1 = new int[] { 1, 2, 3, 4, 5, 10, 11, 0, 0, 0, 0, 0 };
            var arr2 = new int[] { 2, 3, 4, 8, 9 };
            var ex = new ex_10_1();
            var res = ex.MergeInSortedOrder(arr1, arr2);
            foreach (var item in res)
            {
                Console.Write(item + " -> ");
            }
        }
        static void ex72()
        {
            CallCenter cc = new CallCenter();
            cc.AddEmployee("d1", CallCenter.EmployeeType.Director, null);
            cc.AddEmployee("d2", CallCenter.EmployeeType.Director, "d1");
            cc.AddEmployee("m1", CallCenter.EmployeeType.Manager, "d1");
            cc.AddEmployee("m2", CallCenter.EmployeeType.Manager, "d2");
            cc.AddEmployee("r1", CallCenter.EmployeeType.Respondent, "m1");
            cc.AddEmployee("r2", CallCenter.EmployeeType.Respondent, "m2");
            cc.AddEmployee("r3", CallCenter.EmployeeType.Respondent, "m3");
            cc.DispatchCall();
        }
        static void ex57()
        {
            var ex = new ex_5_7();
            int n = 101;
            Console.WriteLine(Ex5Helper.ToBinary(n));
            long n1 = ex.SwapOddAndEvenBits(n);
            Console.WriteLine(Ex5Helper.ToBinary(n1));
            Console.WriteLine();
        }
        static void ex56()
        {
            var ex = new ex_5_6();
            int a = 111;
            int b = 222;
            Console.WriteLine($"{Ex5Helper.ToBinary(a)}");
            Console.WriteLine($"{Ex5Helper.ToBinary(b)}");
            Console.WriteLine($"{ex.GetBitNeedToFlip(a, b)}");
        }
        static void ex52()
        {
            var ex = new ex_5_2();
            double number = 123.125;
            Console.WriteLine($"{ex.ToBinary(number)}");
        }
        static void ex53()
        {
            var ex = new ex_5_3();
            int n = -1;

            Console.WriteLine($"{Ex5Helper.ToBinary(n)}");
            Console.WriteLine($"{ex.FlipBitToWin(n)}");
        }
        static void ex51()
        {
            var ex = new ex_5_1();
            int N = 1234586234;
            int M = 54;
            Console.WriteLine($"N {Ex5Helper.ToBinary(N)}");
            Console.WriteLine($"M {Ex5Helper.ToBinary(M)}");
            Console.WriteLine($"{Ex5Helper.ToBinary(ex.Insert(N, M, 10, 5))}");
        }
        static void ex412()
        {
            BinaryTree<int> tree = new BinaryTree<int>()
            {
                Root = new BinaryTreeNode<int>()
                {
                    Value = 1,
                    Left = new BinaryTreeNode<int>()
                    {
                        Value = 2,
                        Left = new BinaryTreeNode<int>()
                        {
                            Value = 5,
                            Right = new BinaryTreeNode<int>()
                            {
                                Value = -5,
                                Right = new BinaryTreeNode<int>()
                                {
                                    Value = 5
                                }
                            }
                        },
                        Right = new BinaryTreeNode<int>()
                        {
                            Value = 5
                        }
                    },
                    Right = new BinaryTreeNode<int>()
                    {
                        Value = 3,
                        Left = new BinaryTreeNode<int>()
                        {
                            Value = 4,
                        },
                        Right = new BinaryTreeNode<int>()
                        {
                            Value = 7
                        }
                    }
                }
            };
            var ex = new ex_4_12();
            Console.WriteLine($"{ex.CountPaths(tree, 7)}");
        }
        static void ex411()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Insert(1);
            tree.Insert(3);
            tree.Insert(4);
            tree.Insert(2);
            tree.Insert(5);
            tree.Insert(6);
            tree.Insert(7);
            tree.Insert(8);
            tree.Insert(9);
            var ex = new ex_4_11();
            Console.WriteLine($"{ex.GetRandomNode(tree)}");
        }
        static void ex410()
        {
            BinaryTree<int> tree = new BinaryTree<int>()
            {
                Root = new BinaryTreeNode<int>()
                {
                    Value = 1,
                    Left = new BinaryTreeNode<int>() { Value = 2 },
                    Right = new BinaryTreeNode<int>()
                    {
                        Value = 3,
                        Left = new BinaryTreeNode<int>()
                        {
                            Value = 4,
                            Left = new BinaryTreeNode<int>()
                            {
                                Value = 6
                            },
                            Right = new BinaryTreeNode<int>()
                            {
                                Value = 7
                            }
                        },
                        Right = new BinaryTreeNode<int>()
                        {
                            Value = 5
                        }
                    }
                }
            };
            var tree1 = new BinaryTree<int>()
            {
                Root = new BinaryTreeNode<int>()
                {
                    Value = 4,
                    Left = new BinaryTreeNode<int>()
                    {
                        Value = 6
                    },
                    Right = new BinaryTreeNode<int>()
                    {
                        Value = 7
                    }
                },
            };
            var ex = new ex_4_10();
            Console.WriteLine($"{ex.IsSubTree(tree, tree1)}");
        }
        static void ex48()
        {
            BinaryTree<int> tree = new BinaryTree<int>()
            {
                Root = new BinaryTreeNode<int>()
                {
                    Value = 1,
                    Left = new BinaryTreeNode<int>() { Value = 2 },
                    Right = new BinaryTreeNode<int>()
                    {
                        Value = 3,
                        Left = new BinaryTreeNode<int>()
                        {
                            Value = 4,
                            Left = new BinaryTreeNode<int>()
                            {
                                Value = 6
                            },
                            Right = new BinaryTreeNode<int>()
                            {
                                Value = 7
                            }
                        },
                        Right = new BinaryTreeNode<int>()
                        {
                            Value = 5
                        }
                    }
                }
            };
            var n1 = tree.Find(7);
            var n2 = tree.Find(5);
            var ex = new ex_4_8();
            var r = ex.FindFirstCommonAncestor(tree, n1, n2);
            if (r == null) Console.Out.WriteLine($"NULL");
            else
            {
                Console.Out.WriteLine($"{r.Value}");
            }
        }
        static void ex47()
        {
            List<string> prjs = new List<string> { "a", "b", "c", "d", "e", "f", "j", "k" };
            List<Tuple<string, string>> dependencies = new List<Tuple<string, string>>
            {
                new Tuple<string, string>("a", "d"),
                new Tuple<string, string>("f", "b"),
                new Tuple<string, string>("b", "d"),
                new Tuple<string, string>("f", "a"),
                new Tuple<string, string>("d", "c"),
                new Tuple<string, string>("j", "k"),
            };
            var ex = new ex_4_7();
            var res = ex.FindBuildOrders(prjs, dependencies);
            if (res.Count == 0)
            {
                Console.Out.WriteLine($"ERROR");
            }
            else
            {
                Console.Out.WriteLine($"{string.Join("->", res)}");
            }

        }
        static void TestSumMax()
        {
            ex_sum_maximum_non_adjcent_elements ex = new ex_sum_maximum_non_adjcent_elements();
            int[] arr = new[] { 1, 9, 3, 4, 5, 8, 8, 8 };
            Console.Out.WriteLine($"{ex.MaxNonAdjcents(arr)}");
        }
        static void TestBstInsert()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Insert(0);
            tree.Insert(4);
            tree.Insert(11);
            tree.Insert(2);
            tree.Insert(1);
            tree.Insert(50);
            tree.InOrderTraversal();
            tree.Remove(4);
            Console.Out.WriteLine("");
            tree.InOrderTraversal();

        }
        static void ex46()
        {
            BinarySearchTree<int> bt = new BinarySearchTree<int>();
            BSTNode<int> node = new BSTNode<int>()
            {
                Value = 6,
                Left = new BSTNode<int>()
                {
                    Value = 5,
                },
                Right = new BSTNode<int>()
                {
                    Value = 7,
                    Right = new BSTNode<int>()
                    {
                        Value = 8,
                        Right = new BSTNode<int>()
                        {
                            Value = 9,
                            Right = new BSTNode<int>()
                            {
                                Value = 10
                            }
                        }
                    }
                }
            };
            bt.Root = new BSTNode<int>()
            {
                Value = 20,
                Left = node
            };
            bt.InOrderTraversal();
            ex_4_6 ex = new ex_4_6();
            var res = ex.GetInOrderSuccessor(bt, node);
            var val = res == null ? "null" : res.Value.ToString();
            Console.Out.WriteLine($"res is {val}");
        }
        static void ex45()
        {
            BinaryTree<int> bt = new BinaryTree<int>();
            bt.Root = new BinaryTreeNode<int>()
            {
                Value = 20,
                Left = new BinaryTreeNode<int>()
                {
                    Value = 10,
                    Right = new BinaryTreeNode<int>()
                    {
                        Value = 20
                    }
                },
                Right = new BinaryTreeNode<int>()
                {
                    Value = 21,
                }
            };
            ex_4_5 ex = new ex_4_5();
            Console.Out.WriteLine($"{ex.IsBST(bt)}");
        }
        private static void PrintMatrix(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write($"{matrix[i][j]} ");
                }
                Console.WriteLine();
            }
        }
        static void ex44()
        {
            BinaryTree<int> bt = new BinaryTree<int>();
            bt.Root = new BinaryTreeNode<int>()
            {
                Value = 1,
                Left = new BinaryTreeNode<int>()
                {
                    Value = 2,
                    Left = new BinaryTreeNode<int>()
                    {
                        Value = 3
                    },
                    Right = new BinaryTreeNode<int>()
                    {
                        Value = 4,
                        Right = new BinaryTreeNode<int>()
                        {
                            Value = 6
                        }
                    }
                },
                Right = new BinaryTreeNode<int>()
                {
                    Value = 5,

                }
            };
            ex_4_4 ex = new ex_4_4();
            Console.Out.WriteLine($"{ex.IsBalanced(bt)}");
        }
        static void ex43()
        {
            BinaryTree<int> bt = new BinaryTree<int>();
            bt.Insert(1);
            bt.Insert(7);
            bt.Insert(6);
            bt.Insert(5);
            bt.Insert(4);
            bt.Insert(3);
            bt.Insert(2);
            bt.Print();
            ex_4_3 ex = new ex_4_3();
            var linkedLists = ex.CreateLinkedListPerDepth(bt);
            foreach (var singleLinkedList in linkedLists)
            {
                singleLinkedList.Print();
            }
        }
        static void ex42()
        {
            int[] arr = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var ex = new ex_4_2();
            var tree = ex.CreateBinarySearchTree(arr);
            tree.Print();

        }
        static void ex36()
        {
            ex_3_6 ex = new ex_3_6();
            ex.Enqueue(new Animal()
            {
                Type = Animal.Types.Cat
            });
            ex.Enqueue(new Animal()
            {
                Type = Animal.Types.Cat
            });
            ex.Enqueue(new Animal()
            {
                Type = Animal.Types.Dog
            });
            ex.Enqueue(new Animal()
            {
                Type = Animal.Types.Dog
            });
            ex.Enqueue(new Animal()
            {
                Type = Animal.Types.Cat
            });
            ex.Enqueue(new Animal()
            {
                Type = Animal.Types.Cat
            });
            ex.Print();
            ex.DequeueAny();
            ex.Print();
            ex.DequeueDog();
            ex.Print();
            ex.DequeueCat();
            ex.Print();
        }

        static void ex41()
        {
            GraphNode<int> n1 = new GraphNode<int>() { Value = 1 };
            GraphNode<int> n2 = new GraphNode<int>() { Value = 2 };
            n2.Adjacents.Add(n1);
            n1.Adjacents.Add(n2);
            GraphNode<int> n3 = new GraphNode<int>() { Value = 1 };
            GraphNode<int> n4 = new GraphNode<int>() { Value = 1 };
            GraphNode<int> n5 = new GraphNode<int>() { Value = 1 };
            GraphNode<int> n6 = new GraphNode<int>() { Value = 1 };
            GraphNode<int> n7 = new GraphNode<int>() { Value = 1 };
            GraphNode<int> n8 = new GraphNode<int>() { Value = 1 };
            n3.Adjacents.Add(n2);
            n2.Adjacents.Add(n3);
            n4.Adjacents.Add(n2);
            n3.Adjacents.Add(n4);
            n3.Adjacents.Add(n5);
            n4.Adjacents.Add(n3);
            n5.Adjacents.Add(n2);
            n5.Adjacents.Add(n6);
            n6.Adjacents.Add(n4);
            n6.Adjacents.Add(n7);
            n7.Adjacents.Add(n5);
            n7.Adjacents.Add(n8);
            n8.Adjacents.Add(n2);
            n8.Adjacents.Add(n6);
            DirectedGraph<int> graph = new DirectedGraph<int>();
            graph.Nodes.Add(n1);
            graph.Nodes.Add(n2);
            graph.Nodes.Add(n3);
            graph.Nodes.Add(n4);
            graph.Nodes.Add(n5);
            graph.Nodes.Add(n6);
            graph.Nodes.Add(n7);
            graph.Nodes.Add(n8);
            ex_4_1 ex = new ex_4_1();
            Console.Out.WriteLine($"{ex.IsConnected(graph, n1, n8)}");
        }
        static void ex35()
        {
            ex_3_5<int> ex = new ex_3_5<int>();
            ex.Push(1);
            ex.Push(2);
            ex.Push(3);
            ex.Push(4);
            ex.Push(5);
            ex.Push(0);
            var res = ex.Pop();
            res = ex.Pop();
            var res1 = ex.Peek();
            Console.Out.WriteLine($"min {res}");
            Console.Out.WriteLine($"top {res1}");
            Console.Out.WriteLine($"top {ex.Peek()}");
        }
        static void ex34()
        {
            ex_3_4<int> ex = new ex_3_4<int>();
            ex.Enqueue(1);
            ex.Enqueue(3);
            ex.Enqueue(5);
            var res = ex.Dequeue();
            Console.Out.WriteLine($"{res}");
        }
        static void ex33()
        {
            ex_3_3<int> ex = new ex_3_3<int>(3);
            ex.Push(1);
            ex.Push(2);
            ex.Push(3);
            ex.Push(4);
            ex.Push(5);
            ex.Push(6);
            ex.Push(7);
            ex.Push(8);
            ex.Push(9);
            ex.Push(10);
            ex.Push(11);
            ex.Push(12);
            ex.Push(13);
            ex.Push(14);
            var res = ex.Pop();
            var res1 = ex.Pop();
            var res2 = ex.PopAss(7);
            Console.Out.WriteLine($"{res}");
            Console.Out.WriteLine($"{res1}");
            Console.Out.WriteLine($"{res2}");
        }
        void DoCountDistinctPairDiffByK()
        {
            int testCases = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < testCases; i++)
            {
                int arrayLength = int.Parse(Console.ReadLine());
                List<int> array = new List<int>();
                for (int j = 0; j < arrayLength; j++)
                {
                    array.Add(int.Parse(Console.ReadLine()));
                }

                int k = int.Parse(Console.ReadLine());
                int count = CountDistinctPairDiffByK(array, k);
                Console.WriteLine($"Output is {count}");
            }
        }
        private static int CountDistinctPairDiffByK(List<int> array, int k)
        {
            int count = 0;
            ISort<int> sort = new MergeSort<int>(array.ToArray());
            sort.Sort();
            array = sort.Array.ToList();
            ISearch<int> searcher = new BinarySearch<int>();
            for (int i = 0; i < array.Count; i++)
            {
                if (i - 1 >= 0 && array[i] == array[i - 1])
                {
                    continue;
                }

                int idx = searcher.Search(array[i] + k, array.ToArray());
                if (idx >= 0)
                {
                    count++;
                }
            }

            return count;
        }

        static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} ");
            }

            Console.ReadKey();
        }
    }
}
