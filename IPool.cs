namespace Pool {
	public interface IPool<T> {
		void Release(T member);
	}
}