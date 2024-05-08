using System.Xml.Linq;
using SVGUtils.Models;

namespace SVGUtils;

// TODO refactor
public class SvgMapManager: ISvgMapManager
{
    private Graph _graph;
    private string _pathFile;
    
    public void LoadMap(string pathFile)
    {
        _pathFile = pathFile;
        var xDocument = XDocument.Load(_pathFile);

        var pathLayer = xDocument.Descendants()
            .FirstOrDefault(e => e.Name.LocalName == "g" && 
                                 (string) e.Attribute("id")! == "Paths");
        var regalLayer = xDocument.Descendants()
            .FirstOrDefault(e => e.Name.LocalName == "g" && 
                                 (string) e.Attribute("id")! == "Regals");
        _graph = ParseGraph(pathLayer!.Elements(), regalLayer!.Elements());
    }

    public void CreatePath(string outputPath, IEnumerable<int> shelfIds)
    {
        var path = _graph.GetPath(shelfIds);
        
        var xDocument = XDocument.Load(_pathFile); 
        var pathLayer = xDocument.Descendants()
            .FirstOrDefault(e => e.Name.LocalName == "g" && 
                                 (string) e.Attribute("id")! == "Paths");
        
        foreach (var element in pathLayer!.Elements())
        {
            if (path.FirstOrDefault(x => x.Id.Equals((string)element.Attribute("id")!)) == null)
            {
                element.SetAttributeValue("style", ChangeStrokeColor(element.Attribute("style")!.Value, "none"));
            }
        }
        xDocument.Save(outputPath);
        
        var content = File.ReadAllText(outputPath);
        var modifiedContent = content.Replace("<svg:", "<").Replace("</svg:", "</");
        File.WriteAllText(outputPath, modifiedContent);
    }
    static string ChangeStrokeColor(string styleAttr, string newColor)
    {
        var startIndex = styleAttr.IndexOf("stroke:", StringComparison.Ordinal);
        if (startIndex == -1)
            return styleAttr;

        startIndex += 7;
        var endIndex = styleAttr.IndexOf(';', startIndex);
        if (endIndex == -1)
            endIndex = styleAttr.Length;
        
        var oldColor = styleAttr.Substring(startIndex, endIndex - startIndex);
        return styleAttr.Replace(oldColor, newColor);
    }    
    
    private static Graph ParseGraph(IEnumerable<XElement> paths, IEnumerable<XElement> regals)
    {
        ParsePathPoints(paths, out var points, out var edges);
        ParseShelfPaths(regals, points, out var initial, out var terminal);

        return new Graph(points, edges, initial, terminal);
    }

    private static void ParseShelfPaths(IEnumerable<XElement> regals, HashSet<Point> points, out Point initial, out Point terminal)
    {
        var endPoints = points.Where(p => p.Edges.Count == 1).ToList();
        foreach (var regal in regals)
        {
            var x0 = Double.Parse((string)regal.Attribute("x")!);
            var y0 = Double.Parse((string)regal.Attribute("y")!);
            var x1 = x0 + Double.Parse((string)regal.Attribute("width")!);
            var y1 = y0 + Double.Parse((string)regal.Attribute("height")!);
            var regalId = (string)regal.Attribute("id")!;
            var tolerance = 1.0d;

            var inside = (Point p) => p.X >= x0 - tolerance && p.X <= x1 + tolerance &&
                                      p.Y >= y0 - tolerance && p.Y <= y1 + tolerance;

            foreach (var regalPoint in endPoints.Where(p => inside(p)))
            {
                regalPoint.SpecialFeature = regalId;
            }
        }

        initial = points.First(p => p.Edges.Count == 1 && p.SpecialFeature.Equals(""));
        initial.SpecialFeature = "in";
        terminal = endPoints.First(p => p.SpecialFeature.Equals("cash"));
    }

    private static void ParsePathPoints(IEnumerable<XElement> paths, out HashSet<Point> points, out HashSet<Edge> edges)
    {
        points = new HashSet<Point>();
        edges = new HashSet<Edge>();
        
        foreach (var path in paths)
        {
            var movement = (string)path.Attribute("d")!;
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
                Id = (string)path.Attribute("id")!,
                Start = start,
                End = end,
            };
            edges.Add(edge);
            start.Edges.Add(edge);
            end.Edges.Add(edge);
        }
    }

    private static void ParseMovement(string movement, out Point start, out Point end)
    {
        var parts = movement.Split(' ');
        
        var coordinates = parts[1].Split(',');
        var startX = double.Parse(coordinates[0]);
        var startY = double.Parse(coordinates[1]);

        var endX = 0d;
        var endY = 0d;

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