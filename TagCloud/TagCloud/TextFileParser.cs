using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NuGet;

namespace TagCloud
{
	public class TextFileParser : IFileParser
	{
		public Dictionary<string, int> CreateDictionaryFromFile(string fileName)
		{
			var stream = File.Open(fileName, FileMode.Open);
			return CreateDictionaryFromStream(stream);
		}

		public Dictionary<string, int> CreateDictionaryFromStream(Stream stream)
		{
			var reader = new StreamReader(stream, Encoding.UTF8);
			var dictionary = new Dictionary<string, int>();
			var words = reader.ReadToEnd()
				.Split('.', ' ', ':', '!', '?', '\r', '\n', ',')
				.Where(x => !string.IsNullOrEmpty(x))
				.Select(x => x.ToLower());
			foreach (var word in words)
			{
				if (dictionary.ContainsKey(word))
					dictionary[word]++;
				else
					dictionary.Add(word, 1);
			}
			return dictionary;
		}
	}
}
