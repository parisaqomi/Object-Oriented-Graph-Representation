using AlgorithmDesignProject.Structures;

namespace AlgorithmDesignProject.Algorithms
{
    public static class Kruskal
    {
        //public static string Run(Graph originalGraph)
        //{
        //static string pathAddress = "";
        //    Graph mst = new Graph();
        //    //mst.Vertices = g.Vertices;
        //    CopyVertices(originalGraph, mst);
        //    var sortedEdges = originalGraph.Edges.OrderBy(x => x.Weight).ToList();
        //    foreach (var item in sortedEdges)
        //    {
        //        mst.Edges.Add(item);

        //    }

        //    return pathAddress;
        //}


        static void CopyVertices(Graph sourceGraph, Graph destinationGraph)
        {
            foreach (var item in sourceGraph.Vertices)
            {
                destinationGraph.Vertices.Add(item);
            }
        }
    }
}
