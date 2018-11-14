using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimaAPI
{
    struct Coord
    {
        public float lon;
        public float lat;
    };
	struct Weather 
	{
		public int id;
		public string main;
		public string description;
		public string icon;
	};
	struct Main 
	{
		public float temp;
		public int pressure;
		public int humidity;
		public float temp_min;
		public float temp_max;
	}
	struct Wind 
	{
		public float speed;
		public int deg;
	}
	struct Clouds 
	{
		public int all;
	}
	struct Sys
	{
		public int type;
		public float id;
		public float message;
		public string country;
		public int sunrise;
		public int sunset;
	}
    class Clima
    {
        public Coord coord;
		public List<Weather> weathers;
		public string @base;
		public Main main;
		public float visibility;
		public Wind wind;
		public Clouds clouds;
		public int dt;
		public Sys sys;
		public int id;
		public string name;
		public int cod;

		public void ConvertTime()
		{
			
		}
    }
}
