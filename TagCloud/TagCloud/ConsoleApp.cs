using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagCloud
{
	public class ConsoleApp : IApplication
	{
		private readonly CommandLineArgs _args;
		private readonly Config _config;
		private readonly IFileParser _parser;
		private readonly IDrawer _drawer;
		private readonly IWordPreparer _wordPreparer;

		public Dictionary<string, ImageFormat> Formats = new Dictionary<string, ImageFormat>
		{
			{"png", ImageFormat.Png},
			{"jpeg", ImageFormat.Jpeg},
			{"gif", ImageFormat.Gif},
			{"bmp", ImageFormat.Bmp}
		};


		public ConsoleApp(CommandLineArgs arguments, Config configuration, IFileParser fileParser, IDrawer drawer, IWordPreparer wordPreparer)
		{
			_args = arguments;
			_config = configuration;
			_parser = fileParser;
			_drawer = drawer;
			_wordPreparer = wordPreparer;
		}

		public void Start()
		{
			var topWords = _wordPreparer.GetTopWords(_args, _parser);
			CreateImage(_args.ResultFile, topWords);
		}
		

		public void CreateImage(string fileName, Dictionary<string, int> words)
		{
			using (var bitmap = new Bitmap(_config.Width, _config.Height))
			{
				var image = _drawer.CreateCloud(bitmap, _config, words);
				image.Save(_args.ResultFile + '.' + _config.ImageFormat, Formats[_config.ImageFormat]);
			}
		}
	}
}
