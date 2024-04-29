namespace ConsoleApp1.Models;

public class Point
{
    public float X { get; set; }
    public float Y { get; set; }
    // start, end, regal id
    public string SpecialFeature { get; set; } = "";
    public List<Edge> Edges { get; }  = new();
    
    
}

