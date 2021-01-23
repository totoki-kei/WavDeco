using System;
using System.Diagnostics;
using System.Threading;

namespace WavDeco.WinForms {
	public class PhreaseSet {
		public string TextFilePath { get; set; }
		public DateTime TextFileTime { get; set; }
		public string WaveFilePath { get; set; }
		public DateTime WaveFileTime { get; set; }
		public DateTime LastProcessed { get; set; }

		public bool IsReady(Setting setting) {
			if (string.IsNullOrEmpty(TextFilePath)) return false;
			if (string.IsNullOrEmpty(WaveFilePath)) return false;

			{
				var delta = (TextFileTime - WaveFileTime);
				Debug.WriteLine(delta, "delta");
				if (Math.Abs(delta.TotalSeconds) > 1.0) return false;
			}

			if (LastProcessed != default) {
				var delta = DateTime.Now - LastProcessed;
				if (delta.TotalSeconds < 10) return false;
			}

			return true;
		}

	}
}