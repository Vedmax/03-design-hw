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
			using (var graphics = Graphics.FromImage(bitmap))
			{
				float height = 0;
				graphics.Clear(Color.Yellow);
				var sum = words.Take(config.Count).Sum(x => x.Value);
				foreach (var word in words.Take(config.Count))
				{
                    // попробуй порефакторить, например вот эти 3 строчки можно выделить в функцию DrawWord и сразу станет понятнее что происходит 
					var font = new Font(FontFamily.GenericSansSerif, (bitmap.Height / sum) * word.Value, GraphicsUnit.Pixel);
					graphics.DrawString(word.Key, font, new SolidBrush(Color.Red), new PointF(0, height));
					height += (bitmap.Height / sum) * word.Value;
				}
			}
			return bitmap;
		}
	}
}
