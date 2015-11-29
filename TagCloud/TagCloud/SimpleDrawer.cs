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
				float width = 0;
				var index = 0;
				var sizes = new[] {5, 4, 4, 4, 4, 3, 3, 3, 2, 2, 1};
				graphics.Clear(Color.White);
				foreach (var word in words.Take(11))
				{
					var font = new Font(FontFamily.GenericSansSerif, (bitmap.Height / 35) * sizes[index++], GraphicsUnit.Pixel);
					SizeF textSize = graphics.MeasureString(word.Key, font);
					graphics.DrawString(word.Key, font, new SolidBrush(Color.Red), new PointF(width, height));
					height += (bitmap.Height / 35) * sizes[index - 1];
				}
			}
			return bitmap;
		}
	}
}
