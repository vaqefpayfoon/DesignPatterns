using System;
using System.Collections.Generic;

namespace open_close_principle
{
    public enum Color
  {
    Red, Green, Blue
  }

  public enum Size
  {
    Small, Medium, Large, Yuge
  }

  public class Product
  {
    public string Name;
    public Color Color;
    public Size Size;

    public Product(string name, Color color, Size size)
    {
      Name = name ?? throw new ArgumentNullException(paramName: nameof(name));
      Color = color;
      Size = size;
    }
  }

  public class ProductFilter {
            // let's suppose we don't want ad-hoc queries on products
            public IEnumerable<Product> FilterByColor (IEnumerable<Product> products, Color color) {
                foreach (var p in products)
                    if (p.Color == color)
                        yield return p;
            }

            public static IEnumerable<Product> FilterBySize (IEnumerable<Product> products, Size size) {
                foreach (var p in products)
                    if (p.Size == size)
                        yield return p;
            }

            public static IEnumerable<Product> FilterBySizeAndColor (IEnumerable<Product> products, Size size, Color color) {
                foreach (var p in products)
                    if (p.Size == size && p.Color == color)
                        yield return p;
            }
        }

  public interface ISpecifiction<T>
  {
     bool isSatisfied(T t);
  }
  public interface IFilter<T>
  {
    IEnumerable<T> Filter(IEnumerable<T> items, ISpecifiction<T> spect);
  }

  public class ColorSpecifiction: ISpecifiction<Product>
  {
    private Color color;
    public ColorSpecifiction(Color color)
    {
       this.color = color;
    }
    public bool isSatisfied(Product t)
    {
       return t.Color == this.color;
    }
  }

  public class SizeSpecifiction: ISpecifiction<Product>
  {
    private Size size;
    public SizeSpecifiction(Size size)
    {
       this.size = size;
    }
    public bool isSatisfied(Product t)
    {
       return t.Size == this.size;
    }
  }

  public class AndSpecifiction<T>: ISpecifiction<T>
  {
    private ISpecifiction<T> first, secend;
    public AndSpecifiction(ISpecifiction<T> first, ISpecifiction<T> secend)
    {
        this.first = first ?? throw new ArgumentNullException(nameof(first));
        this.secend = secend ?? throw new ArgumentNullException(nameof(secend));
    }
    public bool isSatisfied(T t)
    {
       return first.isSatisfied(t) && secend.isSatisfied(t);
    }
  } 

  public class BetterFilter: IFilter<Product>
  {
      public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecifiction<Product> spect)
      {
          foreach (var item in items)
          {
              if(spect.isSatisfied(item))
                yield return item;
          }
      }
  }
}