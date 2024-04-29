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

        if (pathLayer != null)
        {
            foreach (var element in pathLayer.Elements())
            {
                Console.WriteLine($"Element Name: {element.Attribute("id")}");
            }
        }
        else
        {
            Console.WriteLine("Layer with id=path not found.");
        }
        
        if (regalLayer != null)
        {
            foreach (var element in regalLayer.Elements())
            {
                Console.WriteLine($"Element Name: {element.Attribute("id")}");
            }
        }
        else
        {
            Console.WriteLine("Layer with id=regal not found.");
        }
        if (mainLayer != null)
        {
            foreach (var element in mainLayer.Elements())
            {
                Console.WriteLine($"Element Name: {element.Attribute("id")}");
            }
        }
        else
        {
            Console.WriteLine("Layer with id=regal not found.");
        }
    }

    private static void ParseGraph(IEnumerable<XElement> paths, IEnumerable<XElement> regals)
    {
        var pointSet = new HashSet<Point>();

    }
}
