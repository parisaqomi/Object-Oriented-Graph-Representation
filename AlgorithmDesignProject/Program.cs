using AlgorithmDesignProject.Structures;
using System;

namespace AlgorithmDesignProject
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Greetings!");

            Graph g = new Graph();
            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Header();
                Menu();
                string input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "adv":
                        AddVertex(g);
                        WaitForUser();
                        break;
                    case "edv":
                        EditVertex(g);
                        WaitForUser();
                        break;
                    case "lsv":
                        ShowListOfVertices(g);
                        WaitForUser();
                        break;
                    case "remv":
                        RemoveVertex(g);
                        WaitForUser();
                        break;
                    case "ade":
                        AddEdge(g);
                        WaitForUser();
                        break;
                    case "ede":
                        EditEdge(g);
                        WaitForUser();
                        break;
                    case "reme":
                        RemoveEdge(g);
                        WaitForUser();
                        break;
                    case "lse":
                        ShowListOfEdges(g);
                        WaitForUser();
                        break;
                    default:
                        Console.WriteLine("The entered command doesn't exist:( ");
                        WaitForUser();
                        break;
                }

                
                //Console.ReadKey();

            }
            
        }
#region Helpers
        static void Menu()
        {
            Console.WriteLine("Please enter your desired command...");
            Console.WriteLine("Vertex actions:");
            //vertex actions
            Console.WriteLine("\tadv: adds a new vertex");
            Console.WriteLine("\tedv: edits an existing vertex");
            Console.WriteLine("\tremv: remove an existing vertex");
            Console.WriteLine("\tlsv: lists all vertices");

            Console.WriteLine("edges actions:");
            //edges actions
            Console.WriteLine("\tade: adds a new edges");
            Console.WriteLine("\tede: edits an existing edges");
            Console.WriteLine("\treme: remove an existing vertex");
            Console.WriteLine("\tlse: lists all edges");

        }
        static void Header()
        {
            Console.Clear();
            Console.WriteLine("******* Algotithm Design Project: Graphs *******");
            Console.WriteLine("************************************************");
        }
        static void WaitForUser()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        #endregion
#region Wrappers
#region vertices

        static void AddVertex(Graph myG)
        {
            
            Console.WriteLine("please enter a name for the new vertex :");
            string vertexName = Console.ReadLine();
            try
            {
                myG.AddVertex(vertexName);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine("No adds was made... try again!");
            }
           
            myG.ShowListOfVertices();
        }
        static void EditVertex(Graph myG)
        {

            Console.WriteLine("please enter current name of the vertex :");
            string currentertexName = Console.ReadLine();
            Console.WriteLine("please enter new name of the vertex :");
            string newVertexName = Console.ReadLine();

            try
            {
                myG.EditVertex(currentertexName, newVertexName);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine("No edits was made... try again!");
            }
            

            myG.ShowListOfVertices();
        }
        static void RemoveVertex(Graph myG)
        {
            Console.WriteLine("please enter the name of vertex you want to remove :");
            string removabaleVertex = Console.ReadLine();
            try
            {
                myG.RemoveVertex(removabaleVertex);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine("No removes was made... try again!");
            }

        }
        static void ShowListOfVertices(Graph myG)
        {
            myG.ShowListOfVertices();
        }
        #endregion
#region edges
        static void AddEdge(Graph myG)
        {
            Console.WriteLine("Please enter the name of the beginning vertex:"); //////??????????
            string beginningVertex = Console.ReadLine();
            Console.WriteLine("Please enter the name of the ending vertex:");
            string endingVertex = Console.ReadLine();
            Console.WriteLine("Please enter the weight of the edge :");
            int weightOfNewEdge = int.Parse(Console.ReadLine());
            try
            {
                myG.AddEdge(beginningVertex, endingVertex, weightOfNewEdge);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine("No edge was added... try again!");
            }

        }
        static void EditEdge(Graph myG)
        {
            Console.WriteLine("please enter the current edge weight  :"); //////??????????
            int currentWeight = Console.Read();
            Console.WriteLine("please enter the new weight of edge :"); ////////???????????
            int newWeight = int.Parse(Console.ReadLine());
            try
            {
                myG.EditEdgeWeight(currentWeight, newWeight);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine("No edits was made... try again!");
            }
        }
        static void RemoveEdge(Graph myG)
        {
            Console.WriteLine("Please specify id of the edge :"); 
            int EdgeId = int.Parse(Console.ReadLine());
            try
            {
                myG.RemoveEdge(EdgeId);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine("No remove was made... try again!");
            }
        }
        static void ShowListOfEdges(Graph myG)
        {
                myG.ShowListOfEdges();
        }
        
    }

}
#endregion
#endregion