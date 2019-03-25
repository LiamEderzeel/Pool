namespace Pool {
	using System.Collections.Generic;

	public class Pool<T> : IPool<T> where T : IPoolMember<T> {

		public List<T> objects = new List<T>();
		public HashSet<T> unavailable = new HashSet<T>();
		IFactory<T> factory;

		public Pool(IFactory<T> factory) : this(factory, 5) { }

		public Pool(IFactory<T> factory, int poolSize) {
			this.factory = factory;

			for(int i = 0; i < poolSize; i++) {
				Create();
			}
		}

		public T Allocate() {
			for(int i = 0; i < objects.Count; i++) {
				if(!unavailable.Contains(objects[i])) {
					unavailable.Add(objects[i]);
					return objects[i];
				}
			}
			T newObject = Create();
			unavailable.Add(newObject);
			return newObject;
		}

		public void Release(T member) {
			member.Reset();
			unavailable.Remove(member);
		}

		T Create() {
			T member = factory.Create();
			member.myPool = this;
			objects.Add(member);
			return member;
		}
	}
}