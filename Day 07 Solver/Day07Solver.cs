using System.Collections.Generic;
using System.Linq;

namespace Day_07_Solver
{
    public static class Day07Solver
    {
        public static int Part1Solution(string[] lines)
        {
            string bagToSearch = "shiny gold";
            int nBags = 0;

            Graph graph = new Graph();
            graph.Build(lines);

            var bag = graph.GetNode(bagToSearch);
            List<Node> visitedNodes = new List<Node>();
            var firstParents = graph.Nodes.Where(x => x.Links.Any(y => y.Child.Name.Equals(bagToSearch))).ToList();

            Queue<Node> nodesToVisit = new Queue<Node>();
            foreach (var node in firstParents)
            {
                nodesToVisit.Enqueue(node);
            }

            while (nodesToVisit.Count > 0)
            {
                var nodeToVisit = nodesToVisit.Dequeue();
                if (visitedNodes.Any(x => x.Name == nodeToVisit.Name))
                {
                    continue;
                }
                visitedNodes.Add(nodeToVisit);
                nBags++;

                var parents = graph.Nodes.Where(x => x.Links.Any(y => y.Child.Name.Equals(nodeToVisit.Name)));
                foreach (var node in parents)
                {
                    nodesToVisit.Enqueue(node);
                }
            }

            return nBags;


        }

        public static int Part2Solution(string[] lines)
        {
            string bagToSearch = "shiny gold";
            int nBags = 0;

            Graph graph = new Graph();
            graph.Build(lines);

            var bag = graph.GetNode(bagToSearch);
            Queue<KeyValuePair<Node, int>> nodesToCheck = new Queue<KeyValuePair<Node, int>>();
            foreach (var link in bag.Links)
            {
                nodesToCheck.Enqueue(new KeyValuePair<Node, int>(link.Child, link.Weight));
            }

            while (nodesToCheck.Count > 0)
            {
                var currentNode = nodesToCheck.Dequeue();
                var currentWeight = currentNode.Value;

                nBags += currentNode.Value;

                // Has children?
                if (currentNode.Key.Links.Count == 0)
                {
                    continue;
                }

                foreach (var link in currentNode.Key.Links)
                {
                    nodesToCheck.Enqueue(new KeyValuePair<Node, int>(link.Child, link.Weight * currentWeight));
                }
            }

            return nBags;
        }
    }

    public class Graph
    {
        public List<Node> Nodes = new List<Node>();

        public void Build(string[] lines)
        {
            foreach (var line in lines)
            {
                var splitted = line.Split("contain");
                // Left side
                var rootNodeName = splitted[0].Split(" ")[0] + " " + splitted[0].Split(" ")[1];
                var node = CreateNode(rootNodeName);

                // Right side
                var childrenSplitted = splitted[1].Split(", ");
                foreach (var childString in childrenSplitted)
                {
                    var tempChildString = childString;
                    if (tempChildString[0] == ' ')
                    {
                        tempChildString = childString.Remove(0, 1);
                    }
                    var childStringSplitted = tempChildString.Split(" ");
                    if (childStringSplitted[0] == "no")
                    {
                        continue;
                    }
                    int weight = int.Parse(childStringSplitted[0]);
                    string childName = childStringSplitted[1] + " " + childStringSplitted[2];
                    var childNode = CreateNode(childName);
                    node.AddLink(childNode, weight);
                }
            }
        }

        public Node CreateNode(string name)
        {
            var node = GetNode(name);
            if (node != null)
            {
                return node;
            }
            node = new Node(name);
            Nodes.Add(node);
            return node;
        }

        public Node GetNode(string name)
        {
            return Nodes.SingleOrDefault(n => n.Name.Equals(name));
        }

        public void PrintGraph()
        {
            PrintNodes();
            PrintLinks();
        }

        public void PrintNodes()
        {
            System.Console.WriteLine("================ NODES ===================");
            foreach (var node in Nodes)
            {
                System.Console.WriteLine($"{node.Name}");
            }
            System.Console.WriteLine("================ NODES ===================");
        }

        public void PrintLinks()
        {
            System.Console.WriteLine("================ LINKS ===================");
            foreach (var node in Nodes)
            {
                foreach (var link in node.Links)
                {
                    System.Console.WriteLine($"{link.Parent.Name} contain {link.Weight} {link.Child.Name}");
                }
            }
            System.Console.WriteLine("================ LINKS ===================");
        }
    }

    public class Node
    {
        public Node(string name)
        {
            Name = name;
        }

        public Node AddLink(Node child, int weight)
        {
            Links.Add(new Link
            {
                Parent = this,
                Child = child,
                Weight = weight
            });

            return this;
        }

        public string Name { get; set; }

        public List<Link> Links = new List<Link>();
    }

    public class Link
    {
        public int Weight { get; set; }

        public Node Parent { get; set; }

        public Node Child { get; set; }
    }

}
