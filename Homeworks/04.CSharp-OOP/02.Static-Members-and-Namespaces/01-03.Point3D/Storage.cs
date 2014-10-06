namespace Point3D
{
    using System;
    using System.IO;

    public static class Storage
    {
        private const string SavedPaths = "../../SavedPaths.txt";

        public static void SavePoint(Path3D path)
        {
            try
            {
                var savePath = new StreamWriter(SavedPaths);

                using (savePath)
                {
                    foreach (var point in path.PathList)
                    {
                        savePath.WriteLine(point);
                    }
                }
            }
            catch (IOException io)
            {
                Console.WriteLine(io.Message);
            }
        }

        public static void LoadPoint()
        {
            var loadPath = new StreamReader(SavedPaths);
            var loadedPath = new Path3D();

            using (loadPath)
            {
                string line = loadPath.ReadLine();

                while (line != null)
                {
                    var currentLine = line.Split(new char[] { ' ', ',', '=' },
                                                 StringSplitOptions.RemoveEmptyEntries);

                    var currnetPath = new Point(double.Parse(currentLine[1]),
                                                double.Parse(currentLine[3]),
                                                double.Parse(currentLine[5]));

                    loadedPath.AddPoint(currnetPath);
                    line = loadPath.ReadLine();
                }
            }

            foreach (var path in loadedPath.PathList)
            {
                Console.WriteLine(path);
            }
        }
    }
}