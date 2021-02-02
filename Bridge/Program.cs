﻿using System;
using System.Linq;
using Autofac;

namespace Bridge
{
    public interface IRenderer
    {
        void RenderCircle(float radius);
    }
    public class VectorRenderer : IRenderer
    {
        public void RenderCircle(float radius)
        {
            Console.WriteLine($"Drawing Circle Of Radius = {radius}");
        }
    }
    public class RasterRenderer : IRenderer
    {
        public void RenderCircle(float radius)
        {
            Console.WriteLine($"Drawing pixcel for Circle = {radius}");
        }
    }
    public abstract class Shape
    {
        protected IRenderer renderer;
        protected Shape(IRenderer renderer)
        {
            this.renderer = renderer;
        }
        public abstract void Draw();
        public abstract void Resize(float factor);
    }
    public class Circle : Shape
    {
        private float radius;
        public Circle(IRenderer renderer, float radius) : base(renderer)
        {
            this.radius = radius;
        }
        public override void Draw()
        {
            renderer.RenderCircle(radius);
        }

        public override void Resize(float factor)
        {
            radius *= factor;
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            // IRenderer renderer = new RasterRenderer();    
            // Circle circle = new Circle(renderer, 5);

            // circle.Draw();
            // circle.Resize(2);
            // circle.Draw();

            var cb = new ContainerBuilder();
            cb.RegisterType<VectorRenderer>().As<IRenderer>().SingleInstance();;
            cb.Register((c, p) => new Circle(c.Resolve<IRenderer>(), p.Positional<float>(0)));
            using(var c1 = cb.Build())
            {
                var circle = c1.Resolve<Circle>(new PositionalParameter(5, 5.0f));
                circle.Draw();
                circle.Resize(2.0f);
                circle.Draw();
            }
        }
    }
}
