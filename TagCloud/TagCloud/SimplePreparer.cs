using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagCloud
{
	public class SimplePreparer : IWordPreparer
	{
		public Dictionary<string, int> GetSortedWords(Dictionary<string, int> words, Dictionary<string, int> bannedWords)
		{
			return words
				.Where(x => !bannedWords.ContainsKey(x.Key))
				.OrderByDescending(x => x.Value)
				.ToDictionary(pair => pair.Key, pair => pair.Value);
		}

		public Dictionary<string, int> GetTopWords(CommandLineArgs args, IFileParser parser)
		{
			var wordsDictionary = parser.CreateDictionaryFromFile(args.TextFile);
			var bannedWordsDictionary = parser.CreateDictionaryFromFile(args.BannedWordsFile);
			return GetSortedWords(wordsDictionary, bannedWordsDictionary);
		}
	}
}
