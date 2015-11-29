using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TagCloud
{
	public class CloudGeneratorShould
	{
		[Test]
		public void FindAllWordsInTextFile()
		{
			var parser = new TextFileParser();
			var dict = parser.CreateDictionaryFromFile(@"../../test.txt").Keys.ToArray();
		}
	}
}
