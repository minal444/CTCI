using System;
using System.Collections.Generic;
using System.Text;

namespace CTCI.DesignPatterns.Builder
{
    /*
     * Used when we need to build complex object using small small simple object. 
     */
    //Client
    public class BuilderDP
    {
        public void BuildCar()
        {
            Car car;
            CarDirector director = new CarDirector();

            Suv suv = new Suv();
            car = director.MakeCar(suv);
            car.BuidCar();

            Console.WriteLine("--------------------");
            Sedan sedan= new Sedan();
            car = director.MakeCar(sedan);
            car.BuidCar();
        }
    }

    //Step 1: Create Product
    public class Car
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public string SittingCapacity { get; set; }
        public string Power { get; set; }

        public void BuidCar()
        {
            Console.WriteLine("Model : " + Model);
            Console.WriteLine("Colr : " + Color);
            Console.WriteLine("Sitting Capacity : " + SittingCapacity);
            Console.WriteLine("Power : " + Power);

        }
    }

    //Step 2 : Abstract Build Class
    public abstract class CarBuilder
    {
        protected Car carObject;
        public abstract void SetModel ();
        public abstract void SetColor();
        public abstract void SetSittngCapacity();
        public abstract void SetPower();

        public void CreateNewCar()
        {
            carObject = new Car();
        }

        public Car GetCar()
        {
            return carObject;
        }
    }

    //Step 3: Concreate Builder Class
    public class Sedan : CarBuilder
    {
        public override void SetColor()
        {
            carObject.Color = "Red";
        }

        public override void SetModel()
        {
            carObject.Model = "Sedan A1";
        }

        public override void SetPower()
        {
            carObject.Power = "500HP";
        }

        public override void SetSittngCapacity()
        {
            carObject.SittingCapacity = "5";
        }
    }

    public class Suv : CarBuilder
    {
        public override void SetColor()
        {
            carObject.Color = "Black";
        }

        public override void SetModel()
        {
            carObject.Model = "SUV A1";
        }

        public override void SetPower()
        {
            carObject.Power = "700HP";
        }

        public override void SetSittngCapacity()
        {
            carObject.SittingCapacity = "7";
        }
    }

    //Step 4 : Director Class
    public class CarDirector
    {
        public Car MakeCar(CarBuilder carBuilder)
        {
            carBuilder.CreateNewCar();
            carBuilder.SetColor();
            carBuilder.SetModel();
            carBuilder.SetPower();
            carBuilder.SetSittngCapacity();

            return carBuilder.GetCar();
        }
    }
}
