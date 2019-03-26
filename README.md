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
    Pool<MyPooledType> pool;

    void Start() {
        pool = new Pool<MyPooledType>(new Factory<MyPooledType>(), START_SIZE;
    }

    void Foo() {
        MyPooledType item = pool.Spawn();
        // Time to do cool stuff

        // Release a pool member back to it's pool with this
        pool.Release(item);
        // Or this
        item.myPool.Release(item);
    }
} 
```

Use for MonoBehaviour derived classes.
```csharp
using Pool;

public class Example : MonoBehaviour {
    const START_SIZE = 5;
    Pool<MyPooledType> pool;

    void Start() {
        pool = new Pool<MyPooledType>(new MonoBehaviourFactory<MyPooledType>(prefab), START_SIZE;
    }

    void Foo() {
        MyPooledType item = pool.Spawn();
        // Time to do cool stuff

        // Release a pool member back to it's pool with this
        pool.Release(item);
        // Or this
        item.myPool.Release(item);
    }
} 
```

Use for Prefabs.
```csharp
using Pool;

public class Example : MonoBehaviour {
    const START_SIZE = 5;
    Pool<MyPooledType> pool;
    GameObject prefab;

    void Start() {
        pool = new Pool<MyPooledType>(new PrefabFactory<MyPooledType>(), START_SIZE;
    }

    void Foo() {
        MyPooledType item = pool.Spawn();
        // Time to do cool stuff

        // Release a pool member back to it's pool with this
        pool.Release(item);
        // Or this
        item.myPool.Release(item);
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
