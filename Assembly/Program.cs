using System;
using System.Reflection;
using SOLID;


namespace Assembly
{
    /// <summary>This is the entry point of the <c>OOD_Example</c> Class demo program.
    /// <para>This program demos each SOLID principle of Object Oriented Design (OOD)
    /// SOLID stands for:
    /// S - Single-responsiblity Principle
    /// O - Open-closed Principle
    /// L - Liskov Substitution Principle
    /// I - Interface Segregation Principle
    /// D - Dependency Inversion Principle
    /// </para></summary>
    public class OOD_Example
    {
        public static void Main(string[] args)
        {
            // Shape objects
            Circle circle = new Circle(5);
            Square square = new Square(6);
            Circle circle2 = new Circle(4);
            //Rectangle rect = new Rectangle(2, 5);
            Sphere sph = new Sphere(3);
            Cube cube = new Cube(7);

            // Interfaces that the shapes are associated with
            IShapeInterface[] shapes = { circle, square, circle2 };
            I3DShapeInterface[] i3DShapes = { sph, cube };

            // Operator classes that uses different interfaces to operate on appropriate shape objects
            AreaSumCalculator areaCal = new AreaSumCalculator(shapes);
            VolumeSumCalculator volCal = new VolumeSumCalculator(shapes, i3DShapes);

            // Operation extension without modifying the actual class but using it as a member
            SumOutputFormatter outputFormatterArea = new SumOutputFormatter(areaCal);
            SumOutputFormatter outputFormatterVol = new SumOutputFormatter(volCal);

            Console.WriteLine("***** 2D-Shapes *****");
            Console.WriteLine("Sum of the areas of all shapes: {0}", areaCal.Sum());
            Console.WriteLine("Sum of the areas, JSON format: {0}", outputFormatterArea.JSON());
            Console.WriteLine("Sum of the areas, String format: {0}", outputFormatterArea.Str());

            Console.WriteLine("\n***** 3D-Shapes *****");
            Console.WriteLine("Sum of the volumes of all shapes: {0}", volCal.Sum());
            Console.WriteLine("Sum of the volumes and surface areas, JSON format: {0}", outputFormatterVol.JSON());
            Console.WriteLine("Sum of the surface areas, String format: {0}", outputFormatterVol.Str());

            /*
            // create instance of DateTime, use constructor with parameters (year, month, day)
            //DateTime dateTime = (DateTime)Activator.CreateInstance(typeof(DateTime), new object[] { 2008, 7, 4 });
            //Console.WriteLine(dateTime.Date);

            // dynamically load assembly from file Test.dll
            System.Reflection.Assembly testAssembly = typeof(Calculator).Assembly;

            // get type of class Calculator from just loaded assembly
            Type calcType = testAssembly.GetType("Assembly.Calculator");

            // create instance of class Calculator
            object calcInstance = Activator.CreateInstance(calcType);

            // get info about property: public double Number
            PropertyInfo numberPropertyInfo = calcType.GetProperty("Number");

            // set value of property: public double Number
            numberPropertyInfo.SetValue(calcInstance, 10.0, null);

            // get value of property: public double Number
            double value = (double)numberPropertyInfo.GetValue(calcInstance, null);

            Console.WriteLine("Value: {0}", value);
            */
        }
    }


    /*
    public class Calculator
    {
        public Calculator(double number)
        {
            _number = number;
        }
        public Calculator() { }
        private double _number;
        public double Number { get; set; }
        public void Clear() { }
        private void DoClear() { }
        public double Add(double number)
        {
            return number + _number;
        }
        public static double Pi { get; }
        public static double GetPi() { return Math.PI; }
    }
    */
}
