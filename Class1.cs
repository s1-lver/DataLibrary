namespace DataLibrary;
public class ArrayList<T>
{
    private int _count;
    private T[] _list;

    public T this[uint index] // allows for indexing
    {
        get => _list[index];
        set => _list[index] = value;
    }

    public ArrayList()
    {
        _count = 0;
        _list = [];
    }

    public void Add(T item)
    {
        if (_list.Length == _count)
        {
            Resize();
        }

        _list[_count++] = item;
    }

    public bool Remove(T item)
    {
        if (_count == 0) return false;
        for (uint i = 0; i < _count; i++)
        {
            if (_list[i].Equals(item))
            {
                ShiftPastIndex(i);
                return true;
            }
        }

        return false;
    }

    public bool RemoveAt(uint index)
    {
        if (index > _count - 1) return false;
        ShiftPastIndex(index);
        return true;
    }

    public int Count => _count;

    private void ShiftPastIndex(uint index)
    {
        for (uint i = index + 1; i < _count; i++)
        {
            _list[i - 1] = _list[i];
        }
    }

    private void Resize()
    {
        var newList = new T[_count + 1];
        Array.Copy(_list, newList, _count);
        _list = newList;
    }
}

public class ArrayStack<T>
{
    private int _count; // this is a bit different as it just uses count
    private T[] _items;

    public ArrayStack(int capacity = 4)
    {
        _items = new T[capacity];
        _count = 0;
    }

    public void Push(T item)
    {
        if (_count == _items.Length)
        {
            Resize();
        }

        _items[_count++] = item;
    }

    public T Pop()
    {
        T item = _items[--_count];
        _items[_count] = default;
        return item;
    }

    public T Peek()
    {
        return _items[_count - 1];
    }

    public int Count => _count;

    private void Resize()
    {
        var newList = new T[_count + 1];
        _items.CopyTo(newList, 0);
        _items = newList;
    }
}