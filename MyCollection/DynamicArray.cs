using System.Collections;

namespace MyCollection;

public class DynamicArray<T> : IList<T>, IReadOnlyList<T>
{
    private const int DefaultCapacity = 16;
    
    public int Count => _size;
    public bool IsReadOnly => false;
    
    private int _size;
    private int _capacity;
    private T[] _items;
    
    public T this[int index]
    {
        get => _items[index];
        set 
        {
            if(index >= _size)
            {
                throw new ArgumentException("Invalid index");
            }

            _items[index] = value;
        }
    }

    public DynamicArray(int capacity = DefaultCapacity)
    {
        if (capacity < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(capacity));
        }

        _capacity = capacity;
        _size = 0;
        _items = capacity is 0
            ? Array.Empty<T>()
            : new T[capacity];
    }

    public DynamicArray(IEnumerable<T> items)
    {
        if (items is null)
        {
            throw new ArgumentNullException(nameof(items));
        }

        // Convert items to List<T> to suppress possible multiple enumeration
        var list = items.ToList();
        
        // Setting _capacity to the size of items to prevent needless resizes
        _capacity = list.Count;
        
        _items = new T[_capacity];
        _size = 0;

        foreach (var item in list)
        {
            Add(item);
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new DynamicArrayEnumerator<T>(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(T item)
    {
        if (_size >= _capacity)
        {
            Resize();
        }

        _items[_size] = item;
        _size++;
    }

    public void Clear()
    {
        _items = new T[DefaultCapacity];
        _capacity = _size = 0;
    }

    public bool Contains(T item)
    {
        for (int i = 0; i < _size; i++)
        {
            var element = _items[i];
            if (element?.Equals(item) == true)
            {
                return true;
            }
        }

        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (array.Length - arrayIndex < _items.Length)
        {
            throw new ArgumentException("Dest array is too small");
        }

        Array.Copy(_items, array, _items.Length);
    }

    public bool Remove(T item)
    {
        var index = Array.IndexOf(_items, item);
        var isRemoved = index != -1;

        RemoveAt(index);

        return isRemoved;
    }

    public int IndexOf(T item)
    {
        return Array.IndexOf(_items, item);
    }

    public void Insert(int index, T item)
    {
        if (_size < index)
        {
            throw new InvalidOperationException("Invalid index");
        }

        if (_size == _capacity)
        {
            Resize();
        }

        if (_size == index)
        {
            _items[index] = item;
        }

        Array.Copy(_items, index, _items, index + 1, _size - index);
        _size++;
        _items[index] = item;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index > _size)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        _size--;
        Array.Copy(_items, index + 1, _items, index, _size - index);
    }

    private void Resize()
    {
        var newCapacity = _capacity * 2;
        var tempArray = new T[newCapacity];
        Array.Copy(_items, tempArray, _size);
        _items = tempArray;
        _capacity = newCapacity;
    }
}