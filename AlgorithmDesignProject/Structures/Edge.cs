namespace AlgorithmDesignProject.Structures
{
    public class Edge
    {
        static int Count = 0;
        public int ID { get; private set; }
        public int Weight { get; private set; }
        public Vertex BeginningVertex { get; private set; }
        public Vertex EndVertex { get; private set; }

        public void EditWeight(int newWeight)
        {
            Weight = newWeight;
        }
        public Edge(Vertex bVertex, Vertex eVertex, int weight)
        {
            Weight = weight;
            BeginningVertex = bVertex;
            EndVertex = eVertex;
            ID = Count;
            Count++;
        }
        //~Edge() { Count--; }

        //TODO: This approach has errors
        public override string ToString()
        {
            return $"{ID}: {BeginningVertex.Name} *--------* {EndVertex.Name},w: {Weight}";
        }

    }
}
