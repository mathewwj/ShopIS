using System;
using System.Linq;
using System.Xml.Linq;
using ConsoleApp1;
using ConsoleApp1.Models;

class Program
{
    static void Main()
    {
        var doc = XDocument.Load("./../../../Data/floor_plan.svg");

        var pathLayer = doc.Descendants()
            .FirstOrDefault(e => e.Name.LocalName == "g" && 
                                 (string) e.Attribute("id") == "Paths");
        var regalLayer = doc.Descendants()
            .FirstOrDefault(e => e.Name.LocalName == "g" && 
                                 (string) e.Attribute("id") == "Regals");
        var mainLayer = doc.Descendants()
            .FirstOrDefault(e => e.Name.LocalName == "g" && 
                                 (string) e.Attribute("id") == "Main");
        ParseGraph(pathLayer.Elements(), regalLayer.Elements(), mainLayer.Elements());
    }

    private static Graph ParseGraph(IEnumerable<XElement> paths, IEnumerable<XElement> regals, IEnumerable<XElement> main)
    {
        var points = new HashSet<Point>();
        var edges = new HashSet<Edge>();

        // parse path
        foreach (var path in paths)
        {
            var movement = (string) path.Attribute("d");
            ParseMovement(movement, out var start, out var end);

            if (points.TryGetValue(start, out var insideStart))
                start = insideStart;
            else
                points.Add(start);
            if (points.TryGetValue(end, out var insideEnd))
                end = insideEnd;
            else
                points.Add(end);

            var edge = new Edge
            {
                Id = (string)path.Attribute("id"),
                Start = start,
                End = end,
            };
            edges.Add(edge);
            start.Edges.Add(edge);
            end.Edges.Add(edge);
        }
        
        // parse regals
        var endPoints = points.Where(p => p.Edges.Count == 1);
        foreach (var regal in regals)
        {
            var x0 = Double.Parse((string) regal.Attribute("x"));
            var y0 = Double.Parse((string) regal.Attribute("y"));
            var x1 = x0 + Double.Parse((string) regal.Attribute("width"));
            var y1 = y0 + Double.Parse((string) regal.Attribute("height"));
            var regalId = (string)regal.Attribute("id");
            var tolerance = 1.0d;
            
            var inside = (Point p) => p.X >= x0 - tolerance && p.X <= x1 + tolerance && 
                                      p.Y >= y0 - tolerance && p.Y <= y1 + tolerance;

            foreach (var regalPoint in endPoints.Where(p => inside(p)))
            {
                regalPoint.SpecialFeature = regalId;   
            }
        }
        
        var special = points.First(p => p.Edges.Count == 1 && p.SpecialFeature.Equals(""));
        special.SpecialFeature = "in";

        return new Graph(points, edges, special, new HashSet<Point>(endPoints.Where(p => p.SpecialFeature.Equals("out"))));
    }


    private static void ParseMovement(string movement, out Point start, out Point end)
    {
        string[] parts = movement.Split(' ');
        
        string[] coordinates = parts[1].Split(',');
        var startX = double.Parse(coordinates[0]);
        var startY = double.Parse(coordinates[1]);

        var endX = 0d;
        var endY = 0d;
        
        /*Console.WriteLine("X Coordinate: " + startX);
        Console.WriteLine("Y Coordinate: " + startY);*/

        var commandType = parts[2];
        var num = double.Parse(parts[3]);
        switch (commandType)
        {
            case "V":
                endX = startX;
                endY = num;
                break;
            case "v":
                endX = startX;
                endY = startY + num;
                break;
            case "H":
                endX = num;
                endY = startY;
                break;
            case "h":
                endX = startX + num;
                endY = startY;
                break;
        }

        start = new Point { X = startX, Y = startY };
        end = new Point { X = endX, Y = endY };
        
    }
}
