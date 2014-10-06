namespace Point3D
{
    using System;
    using System.Collections.Generic;

    public class Path3D
    {
        public readonly List<Point> PathList = new List<Point>();

        public void AddPoint(Point point)
        {
            this.PathList.Add(point);
        }

        public void Clear()
        {
            this.PathList.Clear();
        }
    }
}
