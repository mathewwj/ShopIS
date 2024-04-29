using System;
using System.Linq;
using System.Xml.Linq;
using SVGUtils;
using SVGUtils.Models;

class Program
{
    static void Main()
    {
        var svgMapManager = new SvgMapManager();
        
        svgMapManager.LoadMap("./../../../Data/floor_plan.svg");
        svgMapManager.CreatePath("aa", new List<int>{1, 6});
    }
}
