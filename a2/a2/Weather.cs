using System;
namespace a2
{
    public interface Weather
	{
        void changeP(Plain a);
        void changeL(Lakes a);
        void changeG(Grassland a);
    }

    public class Sunny : Weather
	{
        private Sunny() {}
        private static Sunny? instance = null;
        public static Sunny Instance()
        {
            if (instance == null)
            {
                instance = new Sunny();
            }
            return instance;
        }

        public void changeP(Plain a)
        {
            a.changeWater(-3);
        }
        public void changeL(Lakes a)
        {
            a.changeWater(-6);
        }
        public void changeG(Grassland a)
        {
            a.changeWater(-10);
        }
        public override string ToString()
        {
            return "Sunny";
        }
    }

    public class Cloudy : Weather
    {
        private Cloudy() { }
        private static Cloudy? instance = null;
        public static Cloudy Instance()
        {
            if (instance == null)
            {
                instance = new Cloudy();
            }
            return instance;
        }

        public void changeP(Plain a)
        {
            a.changeWater(-1);
        }
        public void changeL(Lakes a)
        {
            a.changeWater(-2);
        }
        public void changeG(Grassland a)
        {
            a.changeWater(-3);
        }
        public override string ToString()
        {
            return "Cloudy";
        }
    }

    public class Rainy : Weather
    {
        private Rainy() { }
        private static Rainy? instance = null;
        public static Rainy Instance()
        {
            if (instance == null)
            {
                instance = new Rainy();
            }
            return instance;
        }

        public void changeP(Plain a)
        {
            a.changeWater(20);
        }
        public void changeL(Lakes a)
        {
            a.changeWater(15);
        }
        public void changeG(Grassland a)
        {
            a.changeWater(20);
        }
        public override string ToString()
        {
            return "Rainy";
        }
    }
}

