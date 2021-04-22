using System;
using Newtonsoft.Json;


namespace SOLID
{
    /* 
        Calculates the sum of the areas of provided shapes.

        AreaSumCalculator demonstrates principles,
            - Single Responsibility
            - Open Closed
        and,
            supports 'Dependency Inversion' principle
    */
    public class AreaSumCalculator
    {
        public AreaSumCalculator(IShapeInterface[] shapes)
        {
            _shapes = shapes;
        }

        public AreaSumCalculator() { }

        private IShapeInterface[] _shapes;

        public IShapeInterface[] Shapes { get { return _shapes; } private set { _shapes = value; } }

        public double areaSum;

        // Sum of the shapes' area
        public virtual double Sum()
        {
            foreach (IManageShapeInterface shp in Shapes) {
                areaSum += shp.ComputeArea();
            }

            return areaSum;
        }
    }


    /* 
        Calculates the sum of the volumes of provided 3D (solid) shapes.

        VolumeSumCalculator demonstrates 'Single Responsibility' principle
        and supports principles,
            - Liskov Substitution
            - Dependency Inversion 
    */
    public class VolumeSumCalculator : AreaSumCalculator
    {
        public VolumeSumCalculator(IShapeInterface[] ishapes, I3DShapeInterface[] i3DShapes) : base(ishapes)
        {
            _i3DShapes = i3DShapes;
        }

        public VolumeSumCalculator() { }

        private I3DShapeInterface[] _i3DShapes;

        public I3DShapeInterface[] Shapes3D { get { return _i3DShapes; } private set { _i3DShapes = value; } }

        public double volSum;

        // Sum of the 3D shapes' volume and surface areas
        public override double Sum()
        {
            foreach (I3DShapeInterface shp3D in Shapes3D)
            {
                volSum += shp3D.Volume();
            }

            foreach (IManageShapeInterface shp in Shapes3D)
            {
                areaSum += shp.ComputeArea();
            }

            return volSum;
        }
    }


    /* 
        Outputs the sum in different formats.

        SumOutputFormatter demonstrates principles,
            - Single Responsibility
            - Liskov Substitution
    */
    public class SumOutputFormatter
    {
        public SumOutputFormatter(AreaSumCalculator areaCalc)
        {
            _areaCalc = areaCalc;
        }

        public SumOutputFormatter() { }

        private AreaSumCalculator _areaCalc;

        // JSON format of the class AreaCalculator and its children
        public string JSON()
        {
            var jsonString = JsonConvert.SerializeObject(_areaCalc);
            return jsonString;
        }

        // String format of area sum
        public string Str()
        {
            return _areaCalc.areaSum.ToString();
        }

    }
}