using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Adapters
{
    public class VectorObject : Collection<Line>
    {
        
    }
    public class VectorRectangle : VectorObject
    {
      public VectorRectangle(int x, int y, int width, int height)
      {
        Add(new Line(new Point(x, y), new Point(x + width, y)));
        Add(new Line(new Point(x + width, y), new Point(x + width, y + height)));
        Add(new Line(new Point(x, y), new Point(x, y + height)));
        Add(new Line(new Point(x, y + height), new Point(x + width, y + height)));
      }
    }
    public class Rectangle : VectorObject
    {
        public Rectangle(int x, int y, int width, int height)
        {
            Add(new Line(new Point(x , y), new Point(x + width, y)));
            Add(new Line(new Point(x + width, y), new Point(x + width, y + height)));
            Add(new Line(new Point(x , y), new Point(x + width, y)));
            Add(new Line(new Point(x , y + height), new Point(x + width, y + height)));
        }
    }
    public class LineToPointAdapter : Collection<Point>
    {
        private static int count = 0;
        static Dictionary<int, List<Point>> cache = new Dictionary<int, List<Point>>();
        private int hash;

      public LineToPointAdapter(Line line)
      {
          hash = line.GetHashCode();
          if (cache.ContainsKey(hash)) return; // we already have it

          Console.WriteLine($"{++count}: Generating points for line [{line.Start.x},{line.Start.y}]-[{line.End.x},{line.End.y}] (with caching)");
          

          List<Point> points = new List<Point>();

          int left = Math.Min(line.Start.x, line.End.x);
          int right = Math.Max(line.Start.x, line.End.x);
          int top = Math.Min(line.Start.y, line.End.y);
          int bottom = Math.Max(line.Start.y, line.End.y);
          int dx = right - left;
          int dy = line.End.y - line.Start.y;

          if (dx == 0)
          {
            for (int y = top; y <= bottom; ++y)
            {
              points.Add(new Point(left, y));
            }
          }
          else if (dy == 0)
          {
            for (int x = left; x <= right; ++x)
            {
              points.Add(new Point(x, top));
            }
          }

          cache.Add(hash, points);
        }

        public IEnumerator<Point> GetEnumerator()
        {
          return cache[hash].GetEnumerator();
        }

      }
}