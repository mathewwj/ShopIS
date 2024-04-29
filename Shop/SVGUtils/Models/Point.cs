namespace SVGUtils.Models;

internal  class Point : IEquatable<Point>
{
    public double X { get; set; }
    public double Y { get; set; }

    // start, end, regal id
    public string SpecialFeature { get; set; } = "";
    public List<Edge> Edges { get; } = new();


    public bool Equals(Point? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return this.Distance(other) < 1;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == this.GetType() && Equals(obj as Point);
    }

    public override string ToString()
    {
        return $"{X} {Y}";
    }
}

internal  static class PointUtils
{
    public static double Distance(this Point p1, Point p2)
    {
        return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
    }
}
