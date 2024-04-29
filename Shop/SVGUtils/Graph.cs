using ConsoleApp1.Models;

namespace ConsoleApp1;

public class Graph
{
    public ISet<Point> Points { get; private set; }
    public ISet<Edge> Edges { get; private set; }
    public Point Initial { get; private set; }
    public ISet<Point> Terminals { get; private set; }

    public Graph(ISet<Point> points, ISet<Edge> edges, Point initial, ISet<Point> terminals)
    {
        Points = points;
        Edges = edges;
        Initial = initial;
        Terminals = terminals;
    }

    
}