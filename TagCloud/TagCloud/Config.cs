using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace TagCloud
{
	public class Config
	{
		public int Width;
		public int Height;
		public int Count;
		public string ImageFormat;
		public string Algorithm;
		public string Font;
		public string Color;
		public string Background;


		public Config(string fileName)
		{
			var config = File.ReadAllLines(fileName);
			GetSizes(config);
			ImageFormat = config[2];
			Algorithm = config[3];
			Count = int.Parse(config[4]);
			Font = config[5];
			Color = config[6];
			Background = config[7];
		}


		private void GetSizes(IReadOnlyList<string> config)
		{
			Width = int.Parse(config[0]);
			Height = int.Parse(config[1]);
		}
	}
}
