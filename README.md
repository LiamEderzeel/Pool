# Pool
Pool is a simple object pool lib for unity 3d I wrote, so you don't have to write one at the start of every project.
Supports pooling of Prefabs, Monobhaviours and classes.
## Installation
1. Clone this repository and use the Package Manager Window > Package Manager to add the package.json located in the root of this repository.
## Examples
Use for normal classes.
```csharp
using Pool;

public class Example : MonoBehaviour {
    const START_SIZE = 5;
    Pool<Enemy> pool;

    void Start() {
        pool = new Pool<Enemy>(new Factory<Enemy>(), START_SIZE;
    }

	void Spawn() {
		Enemy enemy = pool.Allocate();

		EventHandler handler = null;
		handler = (sender, e) => {
			pool.Release(enemy);
			enemy.Death -= handler;
		};

		enemy.Death += handler;
		enemy.gameObject.SetActive(true);
	}
} 
```

Use for MonoBehaviour derived classes.
```csharp
using Pool;

public class Example : MonoBehaviour {
    const START_SIZE = 5;
    Pool<Enemy> pool;

    void Start() {
        pool = new Pool<MyPooledType>(new MonoBehaviourFactory<Enemy>(prefab), START_SIZE;
    }

	void Spawn() {
		Enemy enemy = pool.Allocate();

		EventHandler handler = null;
		handler = (sender, e) => {
			pool.Release(enemy);
			enemy.Death -= handler;
		};

		enemy.Death += handler;
		enemy.gameObject.SetActive(true);
	}
} 
```

Use for Prefabs.
```csharp
using Pool;

public class Example : MonoBehaviour {
    const START_SIZE = 5;
    Pool<Enemy> pool;
    GameObject prefab;

    void Start() {
        pool = new Pool<Enemy>(new PrefabFactory<Enemy>(), START_SIZE;
    }

	void Spawn() {
		Enemy enemy = pool.Allocate();

		EventHandler handler = null;
		handler = (sender, e) => {
			pool.Release(enemy);
			enemy.Death -= handler;
		};

		enemy.Death += handler;
		enemy.gameObject.SetActive(true);
	}
} 
```

Use IFactory to write a factory to fit your needs.
```csharp
using Pool;

public class ExampleFactory<T> : IFactory<T> where T : new() {

	string foo;

	public ExampleFactory() : this("foo") { }
	public ExampleFactory(string foo) {
		this.foo = foo;
	}

	public T Create() {
		T bar = new T(name);
        // What ever you need here
		return object;
	}
}
```
