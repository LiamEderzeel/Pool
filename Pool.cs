namespace Pool {
	using System;
	using System.Collections;
	using System.Collections.Generic;

	public class Pool<T> : IEnumerable where T : IResettable {
		private Stack<T> _availableMembers = new Stack<T>();
		private Dictionary<int, T> _unavailableMembers = new Dictionary<int, T>();
		private IFactory<T> _factory;

		public Pool(IFactory<T> factory) : this(factory, 0) { }

		public Pool(IFactory<T> factory, int poolSize) {
			_factory = factory;

			for(int i = 0; i < poolSize; i++) {
				_availableMembers.Push(Create());
			}
		}

		public T Allocate() {
			if(_availableMembers.Count < 1) {
                T newMember = Create();
                _unavailableMembers.Add(newMember.GetHashCode(), newMember);
                return newMember;
			}

			T allocatedMember = _availableMembers.Pop();
			_unavailableMembers.Add(allocatedMember.GetHashCode(), allocatedMember);
			return allocatedMember;
		}

		public void Release(T member) {
			member.Reset();
			_unavailableMembers.Remove(member.GetHashCode());
			_availableMembers.Push(member);
		}

		T Create() {
			return _factory.Create();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return (IEnumerator<T>)_availableMembers.GetEnumerator();
		}
	}
}