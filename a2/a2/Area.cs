using System;
namespace a2
{
	public abstract class Area
	{
		public string type;
		protected string name;
        protected int water;
        protected double humidityPercentage;

		public Area(string type, string name, int water)
		{
			this.type = type;
			this.name = name;
			this.water = water;
        }

        public override string ToString()
        {
			return "[" + this.type + "]: " + this.water + "km3 (owned by " + this.name + ")"; 
        }

        public void changeWater(int water)
        {
            this.water += water;
        }

        public abstract Area changeType();
		public abstract Area affect(Weather w, ref int humidity);
    }

    public class Plain : Area
	{
		public Plain(string name, int water) : base("Plain", name, water) { this.humidityPercentage = 1.05; }

        public override Area changeType()
        {
            if (this.water > 15)
            {
                return new Grassland(this.name, this.water);
            }
            return this;
        }

        public override Area affect(Weather w, ref int humidity)
        {
            w.changeP(this);
            humidity = (int)(humidity * this.humidityPercentage);
            return this.changeType();
        }
    }

	public class Grassland : Area
	{
        public Grassland(string name, int water) : base("Grassland", name, water) { this.humidityPercentage = 1.10; }

        public override Area changeType()
        {
            if (this.water < 16)
            {
                return new Plain(this.name, this.water);
            }
            else if (this.water > 50)
            {
                return new Lakes(this.name, this.water);
            }
            return this;
        }

        public override Area affect(Weather w, ref int humidity)
        {
            humidity = (int)(humidity * this.humidityPercentage);
            return this.changeType();
        }
    }
    public class Lakes : Area
	{
        public Lakes(string name, int water) : base("Lakes", name, water) { this.humidityPercentage = 1.15; }

        public override Area changeType()
        {
            if (this.water > 51)
            {
                return new Grassland(this.name, this.water);
            }
            return this;
        }

        public override Area affect(Weather w, ref int humidity)
        {
            humidity = (int)(humidity * this.humidityPercentage);
            return this.changeType();
        }
    }
}

