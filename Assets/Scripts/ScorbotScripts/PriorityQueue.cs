using System;
using System.Collections.Generic;


public class PriorityQueue<T>
{
    private readonly List<(T, float)> elements;

    public PriorityQueue()
    {
        elements = new List<(T, float)>();
    }

    public int count => elements.Count;

    public void Enqueue(T item, float priority)
    {
        elements.Add((item, priority));
        elements.Sort((a, b) => a.Item2.CompareTo(b.Item2));
    }

    public T Dequeue()
    {
        if (count == 0)
            throw new InvalidOperationException("Queue is empty.");

        T item = elements[0].Item1;
        elements.RemoveAt(0);
        return item;
    }
}