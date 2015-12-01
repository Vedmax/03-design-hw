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
				graphics.Clear(Color.FromName(config.Background));
				var sum = words.Take(config.Count).Sum(x => x.Value);
				foreach (var word in words.Take(config.Count))
				{
					var wordHeight = (bitmap.Height/sum)*word.Value;
                    // DONE попробуй порефакторить, например вот эти 3 строчки можно выделить в функцию DrawWord и сразу станет понятнее что происходит 
					DrawWord(word, graphics, wordHeight, height, config);
					height += wordHeight;
				}
			}
			return bitmap;
		}

		public void DrawWord(KeyValuePair<string, int> word, Graphics graphics, float wordHeight, float height, Config config)
		{
			var font = new Font(config.Font, wordHeight, GraphicsUnit.Pixel);
			graphics.DrawString(word.Key, font, new SolidBrush(Color.FromName(config.Color)), new PointF(0, height));
		}
	}
}
