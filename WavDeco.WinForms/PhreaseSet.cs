using System;
using System.Diagnostics;

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
				Debug.WriteLine(delta, "delta(txt/wav)");
				if (Math.Abs(delta.TotalMilliseconds) > setting.TimestampDeltaThresholdMsec) return false;
			}

			{
				var delta = DateTime.Now - LastProcessed;
				Debug.WriteLine(delta, "delta(lastproc)");
				if (delta.TotalMilliseconds < setting.OperationIntervalMsec) return false;
			}

			return true;
		}

	}
}