using System.Collections.Generic;
using System.Text;

namespace BuilderPattern
{
    /// <summary>
    /// Product
    /// </summary>
    public class Car
    {
        private readonly List<string> _parts = new List<string>();
        private readonly string _carType;

        public Car(string carType)
        {
            _carType = carType;
        }
        public void AddPart(string part)
        {
            _parts.Add(part);
        }


        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (string part in _parts)
            {
                sb.Append($"Car of type {_carType} has part {part}");
            }
            return sb.ToString();
        }

    }

    public abstract class CarBuilder
    {
        public Car Car
        {
            get;
            private set;
        }
        public CarBuilder(string carType)
        {
            Car = new Car(carType);
        }

        public abstract void BuildEngine();
        public abstract void BuildFrame();

    }

    public class MiniBuilder : CarBuilder
    {
        public MiniBuilder() : base("Mini") { }

        public override void BuildEngine()
        {
            Car.AddPart("not a V8");
        }

        public override void BuildFrame()
        {
            Car.AddPart("3-doors with stripes");
        }
    }

    public class BMWBuilder : CarBuilder
    {
        public BMWBuilder() : base("B<W") { }

        public override void BuildEngine()
        {
            Car.AddPart("is a V8");
        }

        public override void BuildFrame()
        {
            Car.AddPart("4-doors with metallic finish");
        }
    }

    public class  Garage
    {
        private CarBuilder? _builder;
        public Garage() { }

        public void Construct(CarBuilder carBuilder)
        {
            _builder = carBuilder;
            _builder.BuildEngine();
            _builder.BuildFrame();
        }
    }
}

