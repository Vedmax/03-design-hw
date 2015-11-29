using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagCloud
{
	public interface IDrawer
	{
		Bitmap CreateCloud(Bitmap bitmap, Config config, Dictionary<string, int> words);
	}
}
