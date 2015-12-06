using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagCloud
{
	public interface IFileParser
	{
		Dictionary<string, int> CreateDictionaryFromFile(string fileName);
		Dictionary<string, int> CreateDictionaryFromStream(Stream stream);
	}
}
