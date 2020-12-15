namespace BreakCycles
{
    public class Edge
    {
        public Edge(string first, string second)
        {
            First = first;
            Second = second;
        }

        public string First { get; set; }

        public string Second { get; set; }

        public override string ToString()
        {
            return $"{this.First} - {this.Second}";
        }

        public string Reversed()
        {
            return $"{this.Second} - {this.First}";
        }
    }
}