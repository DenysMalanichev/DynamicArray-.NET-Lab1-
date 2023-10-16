using System.Collections;

namespace MyCollection;

internal class DynamicArrayEnumerator<T> : IEnumerator<T>
{
    private readonly IList<T> _list;
    private int _cursor;
    private T _current;
    public T Current => _current;
    object IEnumerator.Current => _current!;

    public DynamicArrayEnumerator(IList<T> list)
    {
        _list = list;
        _cursor = 0;
        _current = _list.Any() ? _list[_cursor] : default!;
    }

    public bool MoveNext()
    {
        if (_cursor < _list.Count)
        {
            _current = _list[_cursor];
            _cursor++;
            return true;
        }

        return false;
    }

    public void Reset()
    {
        _cursor = 0;
        _current = _list[0];
    }
    
    public void Dispose()
    {
    }
}