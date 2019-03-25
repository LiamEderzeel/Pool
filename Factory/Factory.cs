namespace Pool {
	public class Factory<T> : IFactory<T> where T : new() {
		public T Create() {
			return new T();
		}
	}
}
