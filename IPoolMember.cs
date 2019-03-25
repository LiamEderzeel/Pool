namespace Pool {
	using System;
	public interface IPoolMember<T> {
		IPool<T> myPool { get; set; }
		void Reset();
	}
}
