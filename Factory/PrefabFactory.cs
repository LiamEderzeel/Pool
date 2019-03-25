using UnityEngine;

namespace Pool {
	public class PrefabFactory<T> : IFactory<T> where T : MonoBehaviour {

		GameObject prefab;
		string name;
		int index = 0;

		public PrefabFactory(GameObject prefab) : this(prefab, prefab.name) { }

		public PrefabFactory(GameObject prefab, string name) {
			this.prefab = prefab;
			this.name = name;
		}

		public T Create() {
			GameObject tempGameObject = GameObject.Instantiate(prefab) as GameObject;
			tempGameObject.name = name + index.ToString();
			T objectOfType = tempGameObject.GetComponent<T>();
			index++;
			return objectOfType;
		}
	}
}