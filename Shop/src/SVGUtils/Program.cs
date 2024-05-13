namespace SVGUtils;

class Program
{
    static void Main()
    {
        var svgMapManager = new SvgMapManager();
        
        svgMapManager.LoadMap("./../../../Data/floor_plan.svg");
        svgMapManager.CreatePath("./../../../Data/floor_plan_edited.svg", new List<int>{1, 2, 14, 15, 6, 19});
    }
}