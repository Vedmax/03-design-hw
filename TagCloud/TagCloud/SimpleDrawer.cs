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
		public Bitmap CreateCloud(Config config, Dictionary<string, int> words)
		{
			var bitmap = new Bitmap(config.ConfigModel.Width, config.ConfigModel.Height);
			using (var graphics = Graphics.FromImage(bitmap))
			{
				float height = 0;
				graphics.Clear(Color.FromName(config.ConfigModel.Background));
				var sum = words.Take(config.ConfigModel.Count).Sum(x => x.Value);
				foreach (var word in words.Take(config.ConfigModel.Count))
				{
					var wordHeight = (bitmap.Height/sum)*word.Value;
					DrawWord(word, graphics, wordHeight, height, config);
					height += wordHeight;
				}
			}
			return bitmap;
		}

		public void DrawWord(KeyValuePair<string, int> word, Graphics graphics, float wordHeight, float height, Config config)
		{
			var font = new Font(config.ConfigModel.Font, wordHeight, GraphicsUnit.Pixel);
			graphics.DrawString(word.Key, font, new SolidBrush(Color.FromName(config.ConfigModel.Color)), new PointF(0, height));
		}
	}
}
