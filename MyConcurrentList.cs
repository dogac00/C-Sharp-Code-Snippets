using System.Collections;
using System.Collections.Generic;

namespace MyConcurrentList
{
    class ConcurrentList<T> : IList<T>
    {
        private List<T> _items;
        private object _syncRoot;

        public ConcurrentList()
        {
            this._items = new List<T>();
            this._syncRoot = new object();
        }

        public IEnumerator<T> GetEnumerator()
        {
            lock (this._syncRoot)
                return this._items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            lock (this._syncRoot)
                this._items.Add(item);
        }

        public void Clear()
        {
            lock (this._syncRoot)
                this._items.Clear();
        }

        public bool Contains(T item)
        {
            lock (this._syncRoot)
                return this._items.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            lock (this._syncRoot)
                this._items.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            lock (this._syncRoot)
                return this._items.Remove(item);
        }

        public int Count
        {
            get
            {
                lock (this._syncRoot)
                    return this._items.Count;
            }
        }

        public bool IsReadOnly
        {
            get => false;
        }

        public int IndexOf(T item)
        {
            lock (this._syncRoot)
                return this._items.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            lock (this._syncRoot)
                this._items.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            lock (this._syncRoot)
                this._items.RemoveAt(index);
        }

        public T this[int index]
        {
            get
            {
                lock (this._syncRoot)
                    return this._items[index];
            }
            set
            {
                lock (this._syncRoot)
                    this._items[index] = value;
            }
        }
    }
}
