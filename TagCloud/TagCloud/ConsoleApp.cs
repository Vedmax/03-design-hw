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
		private readonly ISaver _imageSaver;


		public ConsoleApp(CommandLineArgs arguments, Config configuration, IFileParser fileParser, IDrawer drawer, 
			IWordPreparer wordPreparer, ISaver imageSaver)
		{
			_args = arguments;
			_config = configuration;
			_parser = fileParser;
			_drawer = drawer;
			_wordPreparer = wordPreparer;
			_imageSaver = imageSaver;
		}

		public void Start()
		{
			var topWords = _wordPreparer.GetTopWords(_args, _parser);
			var image = _drawer.CreateCloud(_config, topWords);
			_imageSaver.SaveImage(image, _args.ResultFile, _config);
		}
	}
}
