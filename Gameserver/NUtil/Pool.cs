namespace ProjectZ.NUtil {
    public class Pool<T>
    {
        private Queue<T> _pool = new Queue<T>();

        private Mutex _clsLock;

        private int _maxObjects;  // Set this to whatever

        public Pool(int nSize)
        {
            _clsLock = new Mutex();
            _maxObjects = nSize;
            for (int i = 0; i < _maxObjects; i++)
            {
                _pool.Enqueue(Activator.CreateInstance<T>());
            }
        }

        public T? NEW()
        {
            T obj;

            if (_pool.Count < 1) {
                Console.WriteLine("ObjectPool: No more objects in pool - ignoring request");
                return default(T);
            }
            else {
                obj = _pool.Dequeue();
            }

            return obj;
        }

        public void DEL(T obj)
        {
            obj = default(T);
            if (_pool.Count < _maxObjects) {
                _pool.Enqueue(obj);
            } else {
                Console.WriteLine("ObjectPool: Pool is full");
            }
        }

        public T? SAFE_NEW() {
            T obj;

            _clsLock.WaitOne();
            if (_pool.Count < 1) {
                Console.WriteLine("ObjectPool: No more objects in pool - ignoring request");
                _clsLock.ReleaseMutex();
                return default(T);
            }
            else {
                obj = _pool.Dequeue();
                _clsLock.ReleaseMutex();
            }

            return obj;
        }

        public void SAVE_DEL(T obj) {
            _clsLock.WaitOne();
            obj = default(T);
            if (_pool.Count < _maxObjects) {
                _pool.Enqueue(obj);
            } else {
                Console.WriteLine("ObjectPool: Pool is full - where the hell did you get this object?");
            }
            _clsLock.ReleaseMutex();
        }
    }
}