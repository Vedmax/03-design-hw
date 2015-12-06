using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagCloud
{
	public class PdfWordsReader : IFileParser
	{
		public Dictionary<string, int> CreateDictionaryFromFile(string fileName)
		{
			throw new NotImplementedException();
		}

		public Dictionary<string, int> CreateDictionaryFromStream(Stream stream)
		{
			throw new NotImplementedException();
		}
	}
}
