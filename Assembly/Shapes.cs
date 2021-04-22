using System;

namespace SOLID
{
    /*
        Shape interface

        This demonstrates 'Dependency Inversion' principle in OOD
    */
    public interface IShapeInterface
    {
        double Area();
    }

    /*
        Manage Shape interface

        This demonstrates 'Interface Segregation' principle in OOD
    */
    public interface IManageShapeInterface
    {
        double ComputeArea();
    }

    /*
        3D Shape interface
    
        This demonstrates 'Interface Segregation' principle in OOD
    */
    public interface I3DShapeInterface
    {
        double Volume();
    }


    /*
        Circle shape implementation
    */
    public class Circle : IShapeInterface, IManageShapeInterface
    {
        public Circle(double radius)
        {
            _radius = radius;
        }

        public Circle() { }

        private double _radius;

        public double CircRadius { get { return _radius; } private set { _radius = value; } }

        // Implementation of IShapeInterface. Computes area.
        public double Area()
        {
            double area;
            area = Math.PI * Math.Pow(CircRadius, 2);
            return area;
        }

        // Implementation of IManageShapeInterface. Invokes area.
        public double ComputeArea()
        {
            return Area();
        }

    }


    /*
        Square shape implementation
    */
    public class Square : IShapeInterface, IManageShapeInterface
    {
        public Square(double length)
        {
            _length = length;
        }

        public Square() { }

        private double _length;

        public double SqrLength { get { return _length; } private set { _length = value; } }

        // Implementation of IShapeInterface. Computes area.
        public double Area()
        {
            double area;
            area = Math.Pow(SqrLength, 2);
            return area;
        }

        // Implementation of IManageShapeInterface. Invokes area.
        public double ComputeArea()
        {
            return Area();
        }

    }


    /*
    /*
        Rectangle shape implementation
    /    
    public class Rectangle : IShapeInterface, IManageShapeInterface
    {
        public Rectangle(double length, double breadth)
        {
            _length = length;
            _breadth = breadth;
        }

        public Rectangle() { }

        private double _length;
        private double _breadth;

        public double Length { get { return _length; } private set { _length = value; } }
        public double Breadth { get { return _breadth; } private set { _breadth = value; } }

        // Implementation of IShapeInterface. Computes area.
        public double Area()
        {
            double area;
            area = Length * Breadth;
            return area;
        }

        // Implementation of IManageShapeInterface. Invokes area.
        public double ComputeArea()
        {
            return Area();
        }

    }
    */


    /*
        Sphere shape implementation
    */
    public class Sphere : IShapeInterface, IManageShapeInterface, I3DShapeInterface
    {
        public Sphere(double radius)
        {
            _radius = radius;
        }

        public Sphere() { }

        private double _radius;

        public double SphRadius { get { return _radius; } private set { _radius = value; } }

        // Implementation of IShapeInterface. Computes surface area.
        public double Area()
        {
            double surfArea;
            surfArea = 4 * Math.PI * Math.Pow(SphRadius, 2);
            return surfArea;
        }

        // Implementation of IManageShapeInterface. Invokes area.
        public double ComputeArea()
        {
            return Area();
        }

        // Implementation of I3DShapeInterface. Computes volume.
        public double Volume()
        {
            double volume;
            volume = 4.0 / 3 * Math.PI * Math.Pow(SphRadius, 3);
            return volume;
        }

    }


    /*
        Cube shape implementation
    */
    public class Cube : IShapeInterface, IManageShapeInterface, I3DShapeInterface
    {
        public Cube(double length)
        {
            _length = length;
        }

        public Cube() { }

        private double _length;

        public double CubeLength { get { return _length; } private set { _length = value; } }

        // Implementation of IShapeInterface. Computes surface area.
        public double Area()
        {
            double surfArea;
            surfArea = 6 * Math.Pow(CubeLength, 2);
            return surfArea;
        }

        // Implementation of IManageShapeInterface. Invokes area.
        public double ComputeArea()
        {
            return Area();
        }

        // Implementation of I3DShapeInterface. Computes volume.
        public double Volume()
        {
            double volume;
            volume = Math.Pow(CubeLength, 3);
            return volume;
        }

    }

}