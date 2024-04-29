using ConsoleApp1.Models;

namespace ConsoleApp1;

public class Graph
{
    public ISet<Point> Points { get; private set; }
    public ISet<Edge> Edges { get;  }
    public Point Initial { get; private set; }
    public Point Terminal { get; private set; }

    public Graph(ISet<Point> points, ISet<Edge> edges, Point initial, Point terminal)
    {
        Points = points;
        Edges = edges;
        Initial = initial;
        Terminal = terminal;
    }


    internal List<Edge> GetPath(IEnumerable<Point> targetPoints)
    {
        var points = GetSortedPoints(targetPoints.ToList());
        var path = new List<Edge>();


        for (int i = 0; i < points.Count - 1; i++)
        {
            if (points[i].Edges.Count == 0 || points[i].Edges.Count == 0)
            {
                Console.WriteLine("get path");
            }
            path.AddRange(GetBestPath(points[i], points[i+1]));
        }
        
        return path;
    }

    
    // TODO fix copy + effective By set
    private List<Point> GetSortedPoints(List<Point> points)
    {
        List<Point> sorted = new();
        sorted.Add(Initial);
        
        for (int i = 0; i < points.Count; i++)
        {
            var closestPoint = points.OrderBy(p => sorted.Last().Distance(p)).First();
            sorted.Add(closestPoint);
            points.Remove(closestPoint);
        }
        
        sorted.Add(Terminal);
        return sorted;
    }
    
    private List<Edge> GetBestPath(Point start, Point end)
    {
        var distances = InitSssp(start);
        var previous = new Dictionary<Point, Point>();
        var visited = new HashSet<Point>();
        var queue = new Queue<(double, Point)>();

        queue.Enqueue((0, start));
        while (queue.Count > 0)
        {
            var (_, current) = queue.Dequeue();
            if (visited.Contains(current)) continue;
            visited.Add(current);
            
            foreach (var edge in current.Edges)
            {
                var neighbor = edge.GetOpposite(current);
                if (neighbor.Equals(current))
                {
                    Console.WriteLine("neigbour");
                }
                var alt = distances[current] + current.Distance(neighbor);
                if (alt < distances[neighbor])
                {
                    distances[neighbor] = alt;
                    previous[neighbor] = current;
                    queue.Enqueue((alt, neighbor));
                }
            }
        }

        return CreatePath(previous, start, end);
    }


    private Dictionary<Point, double> InitSssp(Point start)
    {
        var distances = Points.ToDictionary(point => point, point => double.MaxValue);
        distances[start] = 0;
        return distances;
    }

    
    private List<Edge> CreatePath(Dictionary<Point, Point> previous, Point start, Point end)
    {
        var path = new List<Edge>();
        var curr = end;
        
        while (!curr.Equals(start))
        {
            var next = previous[curr];
            var edge = curr.Edges.First(e => e.ContainsPoint(curr) && e.ContainsPoint(next));
            path.Add(edge);
            curr = next;
        }

        path.Reverse();
        return path;
    }
}
