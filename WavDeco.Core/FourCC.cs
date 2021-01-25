using System.Text;

namespace WavDeco.Core {
	public static class FourCC {

		public static uint FromString(string s) {
			// 先頭4文字がASCIIであると仮定する
			uint ret = 0;

			for (int i = 0; i < s.Length && i < 4; i++) {
				ret |= (uint)(s[i] & 0xFF) << (i * 8);
			}

			return ret;
		}

		public static string ToString(uint val) {
			StringBuilder ret = new StringBuilder();

			for (int i = 0; i < sizeof(uint); i++) {
				ret.Append(char.ConvertFromUtf32((int)(val >> (i * 4)) & 0xFF));
			}

			return ret.ToString();

		}

	}
}
