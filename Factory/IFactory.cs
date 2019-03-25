namespace Pool {
	public interface IFactory<T> {
		T Create();
	}
}