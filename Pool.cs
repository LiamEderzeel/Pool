namespace Pool {
	using System;
	using System.Collections;
	using System.Collections.Generic;

	public class Pool<T> : IEnumerable where T : IResettable {

		public List<T> members = new List<T>();
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
			for(int i = 0; i < members.Count; i++) {
				if(!unavailable.Contains(members[i])) {
					unavailable.Add(members[i]);
					return members[i];
				}
			}
			T newMember = Create();
			unavailable.Add(newMember);
			return newMember;
		}

		public void Release(T member) {
			member.Reset();
			unavailable.Remove(member);
		}

		T Create() {
			T member = factory.Create();
			members.Add(member);
			return member;
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return (IEnumerator<T>)members.GetEnumerator();
		}

	}
}