using System;
using System.Linq;
using System.Xml.Linq;
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
        ParseGraph(pathLayer.Elements(), regalLayer.Elements());
    }

    private static void ParseGraph(IEnumerable<XElement> paths, IEnumerable<XElement> regals)
    {
        var pointSet = new HashSet<Point>();

        foreach (var path in paths)
        {
            var movement = (string) path.Attribute("d");
            ParseMovement(movement, out var a, out var b);

            pointSet.Add(a);
            pointSet.Add(b);
        }

        foreach (var point in pointSet)
        {
            Console.WriteLine($"x: {point.X}, y: {point.Y}");
        }

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
