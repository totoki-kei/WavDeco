using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text;
using WavDeco.Core;

namespace WavDeco.Test {
	[TestClass]
	public class UnitTest1 {
		[TestMethod]
		public void TestListTag1() {
			ListTag tag = new ListTag();

			Assert.IsNull(tag.Artist);
			Assert.IsNull(tag.Name);
			Assert.IsNull(tag.Product);
			Assert.IsNull(tag.Genre);
			Assert.IsNull(tag.Comment);
			Assert.IsNull(tag.TrackNumber);
			Assert.IsNull(tag.CreationYear);
			Assert.IsNull(tag.Software);

			{
				var data = tag.GetBytes();
				Assert.AreEqual(0, data.Length);
			}

			// 15bytes
			tag.Name = "ASCII Test Data";

			{
				const uint estimated = 8 + 4 + 8 + 15 + 1;

				var data = tag.GetBytes();
				Assert.AreEqual((int)estimated, data.Length);

				Assert.AreEqual(FourCC.FromString("LIST"), BitConverter.ToUInt32(data, 0x00));
				Assert.AreEqual(estimated - 8, BitConverter.ToUInt32(data, 0x04));
				Assert.AreEqual(FourCC.FromString("INFO"), BitConverter.ToUInt32(data, 0x08));
				Assert.AreEqual(FourCC.FromString("INAM"), BitConverter.ToUInt32(data, 0x0C));
				Assert.AreEqual(estimated - 20, BitConverter.ToUInt32(data, 0x10));

				Assert.AreEqual(tag.Name, Encoding.Default.GetString(data, 0x14, 15));
			}
		}

		[TestMethod]
		public void TestWriteTag () {
			var tag = new ListTag();
			tag.Name = "これはテストです。採集実行日：" + DateTime.Now;

			WavFile.WriteTagToWavFile(@"..\..\testData\input\01-1.wav", tag, true);
		}
	}


}
