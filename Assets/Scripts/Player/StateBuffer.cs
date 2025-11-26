using System.Collections.Generic;

public class StateBuffer<T>
{
    private Queue<T> buffer;
    private int capacity;

    public StateBuffer(int capacity)
    {
        this.capacity = capacity;
        buffer = new Queue<T>(capacity);
    }

    public void Add(T state)
    {
        if (buffer.Count >= capacity)
        {
            buffer.Dequeue();
        }
        buffer.Enqueue(state);
    }

    public bool TryDequeue(out T state)
    {
        if (buffer.Count > 0)
        {
            state = buffer.Dequeue();
            return true;
        }
        state = default;
        return false;
    }

    public void Clear()
    {
        buffer.Clear();
    }

    public int Count => buffer.Count;
}
