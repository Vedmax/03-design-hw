using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagCloud
{
	public class SimpleDrawer : IDrawer
	{
		public Bitmap CreateCloud(Bitmap bitmap, Config config, Dictionary<string, int> words)
		{
			return bitmap;
		}
	}
}
