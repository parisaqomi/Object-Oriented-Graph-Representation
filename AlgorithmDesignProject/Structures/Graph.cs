using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmDesignProject.Structures
{
    public class Graph
    {
        public List<Vertex> Vertices;
        public List<Edge> Edges;
        //Dictionary<Vertex, bool> IsVisited;

        public Graph()
        {
            Vertices = new List<Vertex>();
            Edges = new List<Edge>();
            //IsVisited = new Dictionary<Vertex, bool>();
        }

        #region Edge Logic

        //AddEdge
        public void AddEdge(string beginningVertexName, string endVertexName, int weight)
        {
            var beginningVertex = FindVertex(beginningVertexName);
            var endVertex = FindVertex(endVertexName);
            if (endVertex == null || beginningVertex == null)
            {
                throw new Exception("One or both of the specified vertices wasn't found!");
            }
            else
            {
                Edge myEdge = new Edge(beginningVertex, endVertex, weight);
                try
                {
                    if (beginningVertex==endVertex)
                    {
                        //adding reference for beginning vertex
                        beginningVertex.AddOutputEdge(myEdge);
                        
                        //adding reference for ending vertex 
                        endVertex.AddInputEdge(myEdge);

                        endVertex.AddConnectedEdge(myEdge);


                    }
                    else
                    {
                        //adding reference for beginning vertex
                        beginningVertex.AddOutputEdge(myEdge);
                        beginningVertex.AddConnectedEdge(myEdge);
                        //adding reference for ending vertex 
                        endVertex.AddInputEdge(myEdge);
                        endVertex.AddConnectedEdge(myEdge);
                    }
                    

                    Edges.Add(myEdge);
                }
                catch (Exception)
                {

                    throw;
                }
               
            }

        }
        //edgeExists
        public bool EdgeExists(string beginningVertexName, string endVertexName, int weight)
        {
            var bv = FindVertex(beginningVertexName);//TODO: check if vertex is found
            var ev = FindVertex(endVertexName);//TODO: check if vertex is found

            foreach (var x in Edges)
            {
                if (x.BeginningVertex == bv && x.EndVertex == ev && x.Weight == weight)
                {
                    return true;
                }

            }
            return false;
        }
        //editEdgeWeight
        public void EditEdgeWeight(int edgeId, int newWeight)
        {
            var edge = FindEdge(edgeId);
            if (edge != null) {

                edge.EditWeight(newWeight); }
            else
                throw new Exception("Specified edge was not found!");
        }
        //RemoveEdge
        public void RemoveEdge(int id)
        {
            var edge = FindEdge(id);
            if (edge != null)
            {
                //first remove edge reference from related vertices
                var beginningVertex = edge.BeginningVertex;
                var endVertex = edge.EndVertex;
                beginningVertex.DisconnectEdge(edge);
                endVertex.DisconnectEdge(edge);

                Edges.Remove(edge);
            }
            else
                throw new Exception("Specified edge was not found!");

        }
        //FindEdge
        public Edge FindEdge(int id)
        {
            var x = (from edge in Edges
                     where edge.ID == id
                     select edge).FirstOrDefault();
            return x;
        }
        //show all edges
        public void ShowListOfEdges()
        {
            foreach (var x in Edges)
            {
                Console.WriteLine(x.ToString());
            }
        }
        #endregion

        #region Vertex Logic
        public Vertex FindVertex(string name)
        {
            //var queryVertex = Vertices.Find(x => (x.Name == name));
            var queryVertex = (from x in Vertices
                               where x.Name == name
                               select x).FirstOrDefault();
            //Vertex queryVertex3 = null;
            //foreach (var x in Vertices)
            //{
            //    if (x.Name == name)
            //    {
            //        queryVertex3 = x;
            //    }
            //}

            return queryVertex;
        }
        bool VertexExists(string vName)
        {
            foreach (var x in Vertices)
            {
                if (x.Name == vName)
                    return true;
            }
            return false;
        }
        //edit vertex
        public void EditVertex(string currentName, string newName)
        {
            var x = FindVertex(currentName);
            if (!VertexExists(newName))
            {
                x.Name = newName;
            }
            else
                throw new Exception($"A vertex with the name {newName} already exists!");

        }
      
        public string GetSummaryOfVertexNeighbors(string vertexName)
        {
            try
            {
                var v = FindVertex(vertexName);
                var neighbors = v.GetNeighbors();
                string vnl = $"Neighbors of vertex {vertexName} are:{Environment.NewLine}";
                foreach (var item in neighbors)
                {
                    vnl += $"{Environment.NewLine}{item.ToString()}";
                }

                return vnl;
            }
            catch (Exception)
            {

                throw;
            }
            
            
        }
        public string GetSummaryOfPossibleMoves(string vertexName)
        {
            try
            {
                var v = FindVertex(vertexName);
                var neighbors = v.GetNeighborsWithCosts();
                neighbors.OrderBy(x => x.Item2);
                string vnl = $"Neighbors of vertex {vertexName} are:{Environment.NewLine}";
                foreach (var item in neighbors)
                {
                    vnl += $"{Environment.NewLine}{item.Item1.ToString()} with cost of {item.Item2.ToString()}";
                }

                return vnl;
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public void AddVertex(string vertexName)
        {

            if (!VertexExists(vertexName))
            {
                Vertices.Add(new Vertex(vertexName));
            }
            else
                throw new Exception($"A vertex with the name {vertexName} already exists!");
        }

        public void RemoveVertex(string vertexName)
        {
            var vertex = FindVertex(vertexName);
            if (vertex == null)
            {
                throw new Exception("Vertex not found!");
            }
            //TODO: Also remove connected edges first. It's better to prompt first...
            else
            {
                //Let's have a copy of references to all connected edges
                List<Edge> removableEdges = new List<Edge>();
                //foreach (var edge in vertex.ConnectedEdges)
                //{
                //    removableEdges.Add(edge);
                //}
                //foreach (var item in removableEdges)
                //{
                //    vertex.DisconnectEdge(item);
                //}
                //foreach (var item in removableEdges)
                //{
                //    Edges.Remove(item);
                //}
                foreach (var item in removableEdges)
                {
                    RemoveEdge(item.ID);
                }

                Vertices.Remove(vertex);
            }
        }

        #region Degree Logic
        public int GetMinDegree()
        {
            Vertex v = GetVertexWithMinDegree();
            return v.GetTotalDegree();
        }

        private Vertex GetVertexWithMinDegree()//TODO: use yield to get all once at a time
        {
            //REMINDER: this method will work but it's not a good practice
            //because we might have several vertices with min degree
            //something like FindNext is needed
            Vertex v = Vertices.First();
            foreach (var item in Vertices)
            {
                if (item.GetTotalDegree() < v.GetTotalDegree())
                {
                    v = item;
                }
            }
            return v;
        }
        public int GetMaxDegree()
        {
            Vertex v = GetVertexWithMaxDegree();
            return v.GetTotalDegree();
        }

        private Vertex GetVertexWithMaxDegree()//TODO: use yield to get all once at a time
        {
            //REMINDER: this method will work but it's not a good practice
            //because we might have several vertices with max degree
            //something like FindNext is needed
            Vertex v = Vertices.First();
            foreach (var item in Vertices)
            {
                if (item.GetTotalDegree() > v.GetTotalDegree())
                {
                    v = item;
                }
            }
            return v;
        }
        #endregion


        #endregion

        #region Graph Logic
        //public bool HasCycle()
        //{
        //    return false;
        //}


        public void ClearGraphData()
        {
            foreach (var item in Edges)
            {
                Edges.Remove(item);
            }
            foreach (var item in Vertices)
            {
                Vertices.Remove(item);
            }
        }
        #endregion

    }

}
