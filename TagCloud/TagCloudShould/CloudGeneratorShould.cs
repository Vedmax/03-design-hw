using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TagCloud
{
	public class CloudGeneratorShould
	{
		[Test]
		public void CreateDictionaryFromTextFile()
		{
			var stream = new MemoryStream(Encoding.UTF8.GetBytes("A, b!\nC."));
			var parser = new TextFileParser();
			var dict = parser.CreateDictionaryFromStream(stream);
			CollectionAssert.AreEquivalent(dict.Keys.ToArray(), new string[] {"a", "b", "c"});
		}

		[Test]
		public void SortWords()
		{
			var stream = new MemoryStream(Encoding.UTF8.GetBytes("A, b!\nC."));
			var parser = new TextFileParser();
			var dict = parser.CreateDictionaryFromStream(stream);
			stream = new MemoryStream(Encoding.UTF8.GetBytes("a\nc"));
			var bannWords = parser.CreateDictionaryFromStream(stream);
			var preparer = new SimplePreparer();
			var filteredWords = preparer.GetSortedWords(dict, bannWords);

			CollectionAssert.AreEquivalent(filteredWords.Keys.ToArray(), new string[] {"b"});
		}

		[Test]
		public void SortWordsInRightOrder()
		{
			var stream = new MemoryStream(Encoding.UTF8.GetBytes("A, b b b!\nC."));
			var parser = new TextFileParser();
			var dict = parser.CreateDictionaryFromStream(stream);
			var preparer = new SimplePreparer();
			var filteredWords = preparer.GetSortedWords(dict, new Dictionary<string, int>());

			CollectionAssert.AreEquivalent(filteredWords.Keys.ToArray()[0], "b");
		}

		[Test]
		public void ParseConfigRight()
		{
			var stream = new MemoryStream(Encoding.UTF8.GetBytes(@"{
				Width: 600,
				Height: 600,
				Count: 11,
				ImageFormat: 'jpeg',
				Algorithm: 'simple',
				Font: 'Arial',
				Color: 'Black',
				Background: 'Green'
			}"));
			var ConfigModel = new Config(stream).ConfigModel;

			Assert.AreEqual(ConfigModel.Width, 600);
			Assert.AreEqual(ConfigModel.Height, 600);
			Assert.AreEqual(ConfigModel.Count, 11);
			Assert.AreEqual(ConfigModel.ImageFormat, "jpeg");
			Assert.AreEqual(ConfigModel.Algorithm, "simple");
			Assert.AreEqual(ConfigModel.Font, "Arial");
			Assert.AreEqual(ConfigModel.Color, "Black");
			Assert.AreEqual(ConfigModel.Background, "Green");
		}
	}
}
