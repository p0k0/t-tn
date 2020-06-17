using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trees.Enumerator
{
    public class PathAccumulator
    {
        private int pathIndex = 0;
        private List<StringBuilder> paths;
        private StringBuilder rootPath;

        public PathAccumulator()
        {
            paths = new List<StringBuilder> { new StringBuilder() };
        }

        public IList<string> Paths => paths.Select(x => x.ToString()).ToArray();

        public void UpdateCurrentPath(Node node)
        {
            paths[pathIndex].Append(node.Data);
        }

        public void RememberRoot()
        {
            rootPath = paths[pathIndex];
            paths.Remove(rootPath);
        }

        public void RepeatRoot(int repeatCount)
        {
            for (int i = 0; i < repeatCount; i++)
                paths.Add(new StringBuilder(rootPath.ToString()));
        }

        public void NextPath()
        {
            pathIndex++;
        }
    }
}
