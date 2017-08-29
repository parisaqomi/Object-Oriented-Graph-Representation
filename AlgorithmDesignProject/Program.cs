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
                    case "deg":
                        GetDegreeOfVertex(g);
                        WaitForUser();
                        break;
                    case "ngls":
                        ShowListOfVertexNeighbors(g);
                        WaitForUser();
                        break;
                    case "cost":
                        ShowListOfVertexNeighborsOrderedByCost(g);
                        WaitForUser();
                        break;
                    case "clear":
                        //EmptyGraph(g);
                        if (Confirm("empty the graph?"))
                            g = new Graph();
                        else
                            Console.WriteLine("canceled");
                        WaitForUser();
                        break;
                    case "kruskal":
                        Console.WriteLine("nothing happens");
                        WaitForUser();
                        break;
                    case "mantrav":
                        Console.WriteLine("nothing happens");
                        WaitForUser();
                        break;
                    default:
                        Console.WriteLine("The entered command doesn't exist:( ");
                        WaitForUser();
                        break;
                }

                
               
            }
            
        }

        
        #region Helpers
        static void Menu()
        {
            Console.WriteLine("Please enter your desired command!");
            //Vertex Actions
            Console.WriteLine("Vertex actions:");
            Console.WriteLine("\tadv: Adds a new vertex");
            Console.WriteLine("\tedv: Edits an existing vertex");
            Console.WriteLine("\tremv: Remove an existing vertex");
            Console.WriteLine("\tlsv: Lists all vertices");
            Console.WriteLine("\tdeg: Gets degree of the input vertex");
            Console.WriteLine("\tngls: Lists all neighbors of a specific vertex");
            Console.WriteLine("\tcost: Lists all neighbors of a specific vertex ordered by transport cost");//TODO: Implement Wrapper
            //Edge Actions
            Console.WriteLine("Edge actions:");
            Console.WriteLine("\tade: Adds a new edges");
            Console.WriteLine("\tede: Edits an existing edges");
            Console.WriteLine("\treme: Remove an existing vertex");
            Console.WriteLine("\tlse: Lists all edges");
            //Graph Actions
            Console.WriteLine("Graph actions:");
            Console.WriteLine("\tclear: Clears all vertices and edges up!");




            //Algorithms
            Console.WriteLine("Algorithms:");
            Console.WriteLine("\tkruskal: Runs Kruskal!");//TODO: Implement Wrapper& Everything!
            Console.WriteLine("\tmantrav: Runs manual traversal!");//TODO: Implement Wrapper& Everything!



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
        static bool Confirm(string question)
        {
            Console.WriteLine(question);
            while (true)
            {
                Console.WriteLine("Please Confirm! (y/n)");
                var x = Console.ReadKey();
                if (x.KeyChar == 'y' || x.KeyChar == 'Y')
                    return true;
                else if (x.KeyChar == 'n' || x.KeyChar == 'N')
                    return false;
                Console.WriteLine("Bad input.");
            }
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
           
            ShowListOfVertices(myG);
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
            

            ShowListOfVertices(myG);
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
            foreach (var item in myG.Vertices)
            {
                
                    Console.WriteLine(item.ToString());
                
            }
        }
        private static void ShowListOfVertexNeighbors(Graph myG)
        {
            Console.WriteLine("please enter the name of the vertex:");
            string vName = Console.ReadLine();
            try
            {
               var v= myG.FindVertex(vName);
                foreach (var item in v.GetNeighbors())
                {
                    Console.WriteLine(item.ToString());
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine("Not found.try again!");
            }
        }
        private static void ShowListOfVertexNeighborsOrderedByCost(Graph myG)
        {
            Console.WriteLine("please enter the name of the vertex:");
            string vName = Console.ReadLine();
            try
            {
                
                
                    Console.WriteLine(myG.GetSummaryOfPossibleMoves(vName));
                
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine("Not found.try again!");
            }
        }
        private static void GetDegreeOfVertex(Graph myG)
        {
            Console.WriteLine("please enter the name of the vertex:");
            string vName = Console.ReadLine();
            try
            {
                var v = myG.FindVertex(vName);
                Console.WriteLine(v.GetTotalDegree());
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine("Not found.try again!");
            }
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
        
    


#endregion

#region Graph
private static void EmptyGraph(Graph g)
{
    if (Confirm("Are you sure you want to empty graph?"))
    {
        g.ClearGraphData(); Console.WriteLine("done");
    }
    else
        Console.WriteLine("Canceled");
}

        #endregion

        #region Algorithms

        #endregion
        #endregion
    }
}