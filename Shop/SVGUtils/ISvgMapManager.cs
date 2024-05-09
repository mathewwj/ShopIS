namespace SVGUtils;

public interface ISvgMapManager
{
    void LoadMap(string pathFile);
    void CreatePath(string outputPath, IEnumerable<int> shelfIds);
    void CreatePath(out string fileContent, IEnumerable<int> shelfIds);
}