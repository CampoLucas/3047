using System;
using System.Collections.Generic;

/// <summary>
/// help to reduce resource overhead when you need multiple instances of a class that are expensive to create or manage.
/// </summary>
/// <typeparam name="T"></typeparam>
public class PoolGeneric<T>
{
    private Queue<T> _elements;
    private Func<T> _elementGenerator;

    public PoolGeneric(in Func<T> elementGenerator)
    {
        _elements = new Queue<T>();
        _elementGenerator = elementGenerator;
    }

    /// <summary>
    /// if there are elements in the pool, returns the element in the beginning of the queue, there are no elements, creates a new element
    /// </summary>
    /// <returns></returns>
    public T GetElement() => _elements.Count > 0 ? _elements.Dequeue() : _elementGenerator();
    /// <summary>
    /// Adds an object to the pool
    /// </summary>
    /// <param name="item"></param>
    public void ReleaseObject(T item) => _elements.Enqueue(item);
}
