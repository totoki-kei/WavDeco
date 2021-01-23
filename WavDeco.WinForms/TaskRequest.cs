namespace WavDeco.WinForms {
	public class TaskRequest<T> {
		public int Trial { get; private set; }	
		public T Value { get; private set; }

		public TaskRequest(T value) {
			Trial = 0;
			Value = value;
		}

		public bool IncrementTrialCount(int limit) {
			return ++Trial <= limit;
		}
	}
}