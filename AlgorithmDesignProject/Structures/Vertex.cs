using System;
using System.Collections.Generic;

namespace AlgorithmDesignProject.Structures
{
    public class Vertex
    {
        static int Count = 0;
        int ID;
        List<Edge> InputEdges = new List<Edge>();
        List<Edge> OutputEdges = new List<Edge>();
        List<Edge> ConnectedEdges = new List<Edge>();
        public string Name { get; set; }


        public Vertex(string vertexName)
        {
            ID = Count;
            Name = vertexName;
            Count++;
        }
        
        #region Degree Logic
        public int GetOutputDegree()
        {

            return OutputEdges.Count;
        }
        public int GetInputDegree()
        {
            return InputEdges.Count;
        }
        
        public int GetTotalDegree()
        {
            return GetInputDegree() + GetOutputDegree();
        }
        #endregion
        

        #region Edge Logic
        public void AddInputEdge(Edge edge)
        {
            if (!InputEdges.Contains(edge))
            {
                InputEdges.Add(edge);
            }
            else
                throw new Exception("Edge already exists");//TODO:Remember to handle

        }

        public void AddOutputEdge(Edge edge)
        {
            if (!OutputEdges.Contains(edge))
            {
                OutputEdges.Add(edge);
            }
            else
                throw new Exception("Edge not found. Nothing removed");//TODO:Remember to handle
        }

        public void RemoveInputEdge(Edge edge)
        {
            if (InputEdges.Contains(edge))
            {
                OutputEdges.Remove(edge);
            }
            else
                throw new Exception("Edge already exists. Nothing removed");//TODO:Remember to handle
        }

        public void RemoveOutputEdge(Edge edge)
        {
            if (OutputEdges.Contains(edge))
            {
                OutputEdges.Remove(edge);
            }
            else
                throw new Exception("Edge already exists");//TODO:Remember to handle
        }
        #endregion

        #region Path Finding Logic

        public List<Tuple<Vertex,int>> GetNeighborsWithCosts()
        {
            
            List<Tuple<Vertex, int>> neighborsWithCosts = new List<Tuple<Vertex, int>>();
            foreach (var item in ConnectedEdges)
            {
                Vertex neighbor;
                if (item.BeginningVertex == this)
                {
                    neighbor = item.EndVertex;
                }
                else
                    neighbor = item.BeginningVertex;//TODO: not sure if this is ok. should test
                Tuple<Vertex, int> neighborWithCost=new Tuple<Vertex, int>(neighbor,item.Weight);
                neighborsWithCosts.Add(neighborWithCost);
            }
            return neighborsWithCosts;
        }
        public List<Vertex> GetNeighbors()
        {
            var neighbors = new List<Vertex>();
            foreach (var item in ConnectedEdges)
            {
                
                Vertex neighbor;
                if (item.BeginningVertex == this)
                {
                    neighbor = item.EndVertex;
                    
                }
                else
                    neighbor = item.BeginningVertex;//TODO: not sure if this is ok. should test
                if (!neighbors.Contains(neighbor))
                    neighbors.Add(neighbor);

            }
            return neighbors;
        }
        #endregion
        public override string ToString()
        {
            return $"{ID}    :    {Name}";
        }
    }
}
