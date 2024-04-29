namespace ConsoleApp1.Models;

public class Edge : IEquatable<Edge>
{
    public string Id { get; set; }
    public Point Start { get; set; }
    public Point End { get; set; }

    public bool Equals(Edge? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id == other.Id;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Edge)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Start, End);
    }
}

public static class EdgeUtils
{
    public static Point GetOpposite(this Edge edge, Point point)
    {
        return point.Equals(edge.Start) ? edge.End : edge.Start;
    }

    public static bool ContainsPoint(this Edge edge, Point point)
    {
        return point.Equals(edge.Start) || point.Equals(edge.End);
    }
}