using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WavDeco.Core {

	public struct ListTag {
		/*
		 * 'IART' artist アーティスト名
		 * 'INAM' name 曲名
		 * 'IPRD' product アルバム名
		 * 'IGNR' genre ジャンル
		 * 'ICMT' comment コメント
		 * 'ITRK' track number トラック
		 * 'ICRD' creation date 作成日（作成年）
		 * 'ISFT' software （編集したソフトなど）
		 */

		public string Artist { get; set; }
		public string Name { get; set; }
		public string Product { get; set; }
		public string Genre { get; set; }
		public string Comment { get; set; }
		public uint? TrackNumber { get; set; }
		public uint? CreationYear { get; set; }
		public string Software { get; set; }


		public byte[] GetBytes() {
			uint WriteChunk(BinaryWriter writer, string tag, string data) {
				if (data is null) return 0;

				var bytes = Encoding.Default.GetBytes(data + "\0").ToArray();
				if (bytes.Length % 2 != 0) {
					Array.Resize(ref bytes, bytes.Length + 1);
					bytes[bytes.Length - 1] = 0;
				}

				writer.Write(FourCC.FromString(tag));
				writer.Write((uint)bytes.Length);
				writer.Write(bytes);

				return (uint)(sizeof(uint) * 2 + bytes.Length);
			}


			using (MemoryStream stream = new MemoryStream())
			using (BinaryWriter writer = new BinaryWriter(stream, Encoding.Default, true)) {
				writer.Write(FourCC.FromString("LIST"));
				writer.Write((uint)0); // ダミー値

				writer.Write(FourCC.FromString("INFO"));

				uint len = 0;
				len += WriteChunk(writer, "IART", Artist);
				len += WriteChunk(writer, "INAM", Name);
				len += WriteChunk(writer, "IPRD", Product);
				len += WriteChunk(writer, "IGNR", Genre);
				len += WriteChunk(writer, "ICMT", Comment);
				len += WriteChunk(writer, "ITRK", TrackNumber?.ToString());
				len += WriteChunk(writer, "ICRD", CreationYear?.ToString());
				len += WriteChunk(writer, "ISFT", Software);

				if (len == 0) {
					// タグ情報なし : データを返さない
					return new byte[0];
				}

				// INFO分を加算
				len += sizeof(uint);

				if (len % 2 != 0) {
					len++;
					writer.Write((byte)0);
				}

				// サイズ部分を更新
				stream.Seek(sizeof(uint), SeekOrigin.Begin);
				writer.Write(len);


				return stream.ToArray();
			}

		}


	}
}
