using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.AccessControl;
using System.Text;

namespace WavDeco.Core {
	public class WavFile {

		public static void WriteTagToWavFile(string path, ListTag tag, bool makeBackup) {
			WriteTagToWavFile(path, tag, makeBackup ? 100 : 0);
		}
		public static void WriteTagToWavFile(string path, ListTag tag, int backupCount) {
			string bak = path + ".bak";
			string tmp = path + ".tmp";


			try {

				using (var src = new FileStream(path, FileMode.Open, FileAccess.Read))
				using (var reader = new BinaryReader(src, Encoding.Default, true)) {
					// ファイルフォーマットの確認
					var firstTag = reader.ReadUInt32();
					if (firstTag != FourCC.FromString("RIFF")) {
						throw new FileFormatException("RIFF チャンクがありません。");
					}

					var totalSize = reader.ReadUInt32();
					if (totalSize % 2 != 0) {
						throw new FileFormatException("RIFF チャンクのデータ長が不正です。");
					}

					var formType = reader.ReadUInt32();
					if (formType != FourCC.FromString("WAVE")) {
						throw new FileFormatException("フォームタイプが WAVE ではありません。");
					}


					using (var dest = new FileStream(tmp, FileMode.CreateNew))
					using (var writer = new BinaryWriter(dest, Encoding.Default, true)) {
						writer.Write(FourCC.FromString("RIFF"));
						writer.Write((uint)0); // dummy
						writer.Write(FourCC.FromString("WAVE"));


						while (true) {
							long pos = src.Position;
							if (pos >= totalSize + sizeof(uint) * 2) break;

							var innerTag = reader.ReadUInt32();
							var innerSize = reader.ReadUInt32();

							// すでに存在するLISTタグ
							if (innerTag == FourCC.FromString("LIST")) {
								// データ部分は読み飛ばす
								src.Seek(innerSize, SeekOrigin.Current);
							}
							else {
								writer.Write(innerTag);
								writer.Write(innerSize);

								//src.CopyTo(dest, (int)innerSize);

								// CopyToだとバイト数制限が動作しない？？？
								// 仕方ないので自前コピーする
								byte[] buffer = new byte[8192];
								int remain = (int)innerSize;
								while (remain > 0) {
									int len = remain;
									if (len > buffer.Length) len = buffer.Length;

									int read = src.Read(buffer, 0, len);
									dest.Write(buffer, 0, read);

									remain -= read;
								}
							}

						}

						var tagBytes = tag.GetBytes();

						// タグの書き込み
						writer.Write(tagBytes);

						// 書き込み後のカーソルから後ろを削除
						dest.SetLength(dest.Position);

						// RIFFチャンクのサイズ情報を更新
						dest.Seek(sizeof(uint), SeekOrigin.Begin);
						writer.Write((uint)(dest.Length - dest.Position - sizeof(uint)));


					}

				}

				// TODO
				// ここのバックアップ処理について世代管理をちゃんと行えるようにする

				bool replaceCompleted = false;
				for(int i = 0; i < backupCount; i++) {
					try {
						File.Move(path, bak);
						File.Move(tmp, path);

						if (backupCount == 0) {
							File.Delete(bak);
						}

						replaceCompleted = true;
						break;
					} catch(IOException) {
						bak = path + ".bak." + i.ToString("X2");
					}
				}

				if (!replaceCompleted) {
					// 直接行く
					File.Delete(path);
					File.Move(tmp, path);
				}

			}
			catch {
				throw;
			} finally {
				File.Delete(tmp);
			}




		}

		//public static void WriteTagToWavFile(string path, ListTag tag) {
		//	// ファイルを開く

		//	using (var file = new FileStream(path, FileMode.Open, FileAccess.ReadWrite)) {

		//		bool isCurrentListTagIsLastTag = false;
		//		long currentListTagOffset = -1;
		//		uint currentListTagSize = 0;

		//		// ファイルフォーマットの確認
		//		using (var reader = new BinaryReader(file, Encoding.Default, true)) {
		//			var firstTag = reader.ReadUInt32();
		//			if (firstTag != FourCC.FromString("RIFF")) {
		//				throw new FileFormatException("RIFF チャンクがありません。");
		//			}

		//			var totalSize = reader.ReadUInt32();
		//			if (totalSize % 2 != 0) {
		//				throw new FileFormatException("RIFF チャンクのデータ長が不正です。");
		//			}

		//			var formType = reader.ReadUInt32();
		//			if (formType != FourCC.FromString("WAVE")) {
		//				throw new FileFormatException("フォームタイプが WAVE ではありません。");
		//			}

		//			while (true) {
		//				long pos = file.Position;
		//				if (pos == totalSize + sizeof(uint) * 2) break;

		//				var innerTag = reader.ReadUInt32();
		//				var innerSize = reader.ReadUInt32();

		//				// すでに存在するLISTタグ
		//				if (innerTag == FourCC.FromString("LIST")) {
		//					// タグの位置とサイズを記憶する
		//					currentListTagOffset = pos;
		//					currentListTagSize = innerSize;
		//					isCurrentListTagIsLastTag = true;
		//				}
		//				else {
		//					isCurrentListTagIsLastTag = false;
		//				}

		//				// データ部分は読み飛ばす
		//				file.Seek(innerSize, SeekOrigin.Current);
		//			}
		//		}

		//		// ファイル情報確認完了
		//		var tagBytes = tag.GetBytes();

		//		using (var writer = new BinaryWriter(file, Encoding.Default, true)) {
		//			if (currentListTagOffset != -1) {
		//				// すでにLISTタグがある

		//				file.Seek(currentListTagOffset, SeekOrigin.Begin);

		//				if (!isCurrentListTagIsLastTag) {
		//					// LISTタグがRIFFチャンク中の先頭または途中にある
		//					// そのタグを潰す
		//					writer.Write(FourCC.FromString("DEL"));

		//					// 末尾に移動
		//					file.Seek(0, SeekOrigin.End);
		//				}
		//			}
		//			else {
		//				// LISTタグはまだ存在しない
		//				// 末尾に移動
		//				file.Seek(0, SeekOrigin.End);
		//			}

		//			// タグの書き込み
		//			writer.Write(tagBytes);

		//			// 書き込み後のカーソルから後ろを削除
		//			file.SetLength(file.Position);

		//			// RIFFチャンクのサイズ情報を更新
		//			file.Seek(sizeof(uint), SeekOrigin.Begin);
		//			writer.Write((uint)(file.Length - file.Position - sizeof(uint)));
		//		}

		//	}

		//}
	}
}
