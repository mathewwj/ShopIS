namespace ConsoleApp1;

public interface ISvgMapManager
{
    void LoadMap(string pathFile);
    void CreatePath(string outputPath, List<int> shelfIds);
}