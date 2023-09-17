using System;

namespace TringleLibrary
{
    public interface IShape
    {
        double GetArea();
    }

    public abstract class ShapeFactory
    {
        public abstract IShape CreateShape();
    }

    public class Circle : IShape
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public double GetArea()
        {
            return Math.PI * radius * radius;
        }
    }

    public class CircleFactory : ShapeFactory
    {
        private double radius;

        public CircleFactory(double radius)
        {
            this.radius = radius;
        }

        public override IShape CreateShape()
        {
            return new Circle(radius);
        }
    }

    public class Triangle : IShape
    {
        private double sideA;
        private double sideB;
        private double sideC;

        public Triangle(double sideA, double sideB, double sideC)
        {
            this.sideA = sideA;
            this.sideB = sideB;
            this.sideC = sideC;
        }

        public double GetArea()
        {
            double semiperimeter = (sideA + sideB + sideC) / 2;
            return Math.Sqrt(semiperimeter * (semiperimeter - sideA) * (semiperimeter - sideB) * (semiperimeter - sideC));
        }

        public bool IsRightTriangle()
        {
            return (sideA * sideA + sideB * sideB == sideC * sideC) ||
                    (sideA * sideA + sideC * sideC == sideB * sideB) ||
                    (sideB * sideB + sideC * sideC == sideA * sideA);
        }
    }

    public class TriangleFactory : ShapeFactory
    {
        private double sideA;
        private double sideB;
        private double sideC;

        public TriangleFactory(double sideA, double sideB, double sideC)
        {
            this.sideA = sideA;
            this.sideB = sideB;
            this.sideC = sideC;
        }

        public override IShape CreateShape()
        {
            return new Triangle(sideA, sideB, sideC);
        }
    }
}