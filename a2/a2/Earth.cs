using System;
using TextFile;

namespace a2
{
    public class FileError : Exception { }
    public class FormatError : Exception { }
    public class AreaError : Exception { }


    public class Earth
	{
		private Weather? weather = null;
		private List<Area> areas;
		private int humidity;

		public int getHumidity () { return humidity; }
		public List<Area> getAreas () { return areas; }
		public Weather? getWeather() { return weather; }


		public Earth(string filename)
		{
			this.areas = new();
			TextFileReader reader;

            try { reader = new(filename); }
			catch (Exception) { throw new FileError(); }

			reader.ReadInt(out int n);
            string[] tokens; string line, owner; int water;
            char[] separators = new char[] { ' ', '\t' };
            for (int i = 0; i < n; i++)
			{
				reader.ReadLine(out line);
                tokens = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length != 4)
				{
					throw new FormatError();
                }

				owner = tokens[0] + " " + tokens[1];
				water = int.Parse(tokens[3]);

				switch (tokens[2])
				{
					case "L":
						this.areas.Add(new Lakes(owner, water));
						break;
					case "G":
                        this.areas.Add(new Grassland(owner, water));
                        break;
                    case "P":
                        this.areas.Add(new Plain(owner, water));
                        break;
                    default: throw new AreaError();
                }
            }

			reader.ReadInt(out this.humidity);
        }

		private void calculateWeather()
		{
			if (this.humidity < 40)
			{
				this.weather = Sunny.Instance();
			}
			else if (this.humidity >= 40 && this.humidity <= 70)
			{
				int random = new Random().Next(0,100);
				this.weather = random <= ((this.humidity - 30) * 0.33) ? Rainy.Instance() : Cloudy.Instance();
            }
            else if (this.humidity > 70)
			{
				this.humidity = 30;
				this.weather = Rainy.Instance();
			}
		}

		private bool sameType()
		{
			Area? prev = null;
			foreach(Area a in this.areas) {
				if (prev == null)
				{
					prev = a;
					continue;
				}

				if (prev.type != a.type)
				{
					return false;
				}
			}
			return true;
		}

		public void Run()
		{
			Console.WriteLine("Initial data. Weather: " + this.weather);
			for (int i = 0; i < this.areas.Count; i++)
			{
				Console.WriteLine(this.areas[i]);
			}
			Console.WriteLine();

            calculateWeather();

            int j = 0;
			while(!sameType())
			{
				j += 1;
				Console.WriteLine(j + ". Weather: " + this.weather);
				for (int k = 0; k < this.areas.Count; k++)
				{
					Area a = this.areas[k];
					Area another = a.affect(this.weather!, ref this.humidity);

					this.areas[k] = another;
					Console.WriteLine(another);
				}
				Console.WriteLine();
			}
        }
    }
}

