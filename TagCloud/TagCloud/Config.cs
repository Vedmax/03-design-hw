using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TagCloud
{
	public class ConfigModel
	{
		public int Width;
		public int Height;
		public int Count;
		public string ImageFormat;
		public string Algorithm;
		public string Font;
		public string Color;
		public string Background;
	}

	public class Config
	{
		public readonly ConfigModel ConfigModel;

		public Config(string fileName)
		{
			ConfigModel = JsonConvert.DeserializeObject<ConfigModel>(File.ReadAllText(fileName));
		}
	}
}
