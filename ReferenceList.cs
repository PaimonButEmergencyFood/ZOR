public class RefTree<T>
{
    private T[] _array;

    public RefTree()
    {
        _array = new T[0];
    }
    public void Add(int key, ref T value)
    {
        if (_array.Length == 0)
        {
            _array = new T[1];
            _array[0] = value;
            return;
        }

        int length = _array.Length;
        if (length <= (int)key)
        {
            T[] tmp = new T[key + 1];
            Array.Copy(_array, tmp, length);
            _array = tmp;
        }
        _array[key] = value;
    }
    public ref T Get(int key)
    {
        int index = 0;
        int length = _array.Length;
        while (index < length)
        {
            int currentKey = (int)index;
            if (currentKey == key)
            {
                return ref _array[index];
            }
            index++;
        }
        throw new KeyNotFoundException();
    }

    public void Remove(int key)
    {
        _array[key] = default(T);
    }
    public bool HasKey(int key)
    {
        int index = 0;
        int length = _array.Length;
        while (index < length)
        {
            int currentKey = (int)index;
            if (currentKey == key)
            {
                if (_array[index] == null)
                {
                    return false;
                }
                return true;
            }
            index++;
        }
        return false;
    }

    public int Count => (int)_array.Length;
    public bool IsEmpty => _array.Length == 0;
}