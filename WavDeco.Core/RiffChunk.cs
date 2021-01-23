using System;
using System.Collections.Generic;
using System.Text;

namespace WavDeco.Core {

	class RiffChunk {
		public uint Offset { get; private set; }
		public uint Tag { get; private set; }
		public uint Size { get; private set; }
	}

}
