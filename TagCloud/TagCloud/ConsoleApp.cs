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

		public Dictionary<string, ImageFormat> Formats = new Dictionary<string, ImageFormat>
		{
			{"png", ImageFormat.Png},
			{"jpeg", ImageFormat.Jpeg},
			{"gif", ImageFormat.Gif},
			{"bmp", ImageFormat.Bmp}
		};

		public Dictionary<string, IDrawer> Drawers = new Dictionary<string, IDrawer>
		{
			{"simple", new SimpleDrawer()}
		};

		public ConsoleApp(CommandLineArgs arguments, Config configuration, IFileParser fileParser)
		{
			_args = arguments;
			_config = configuration;
			_parser = fileParser;
		}

		public void Start()
		{
			var wordsDictionary = _parser.CreateDictionaryFromFile(_args.TextFile);
			var bannedWordsDictionary = _parser.CreateDictionaryFromFile(_args.BannedWordsFile);
			var topWords = GetSortedWords(wordsDictionary, bannedWordsDictionary);

			CreateImage(_args.ResultFile, topWords);
		}

		private static Dictionary<string, int> GetSortedWords(Dictionary<string, int> words, Dictionary<string, int> bannedWords)
		{
			return words
				.Where(x => !bannedWords.ContainsKey(x.Key))
				.OrderByDescending(x => x.Value)
				.ToDictionary(pair => pair.Key, pair => pair.Value);
		}

		public void CreateImage(string fileName, Dictionary<string, int> words)
		{
			using (var bitmap = new Bitmap(_config.Width, _config.Height))
			{
				var drawer = Drawers[_config.Algorithm];
				var image = drawer.CreateCloud(bitmap, _config, words);
				image.Save(_args.ResultFile + '.' + _config.ImageFormat, Formats[_config.ImageFormat]);
			}
		}
	}
}
