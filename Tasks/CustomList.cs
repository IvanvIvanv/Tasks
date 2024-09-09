using System;

namespace Tasks
{
    public sealed class CustomList<T>
    {
        public int Capacity => _array.Length;

        private int _count;
        public int Count => _count;

        private T[] _array;

        public T this[int index]
        {
            get => _array[index];
            set => _array[index] = value;
        }

        public CustomList()
        {
            _array = new T[2];
        }

        public CustomList(int bufferLength)
        {
            _array = new T[bufferLength];
        }

        public void Add(T value)
        {
            IncrementCount();
            _array[_count - 1] = value;
        }

        public void Remove()
        {
            if (_count == 0) return;
            _count--;
        }

        public bool TryInsert(T value, int index)
        {
            if (index > _count) return false;

            IncrementCount();

            for (int i = _count - 1; i > index; i--)
            {
                _array[i] = _array[i - 1];
            }

            _array[index] = value;

            return true;
        }

        public void Clear()
        {
            _count = 0;
        }

        public bool TryErase(int index)
        {
            try
            {
                CountOutOfRangeCheck(index);
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }

            _array[index] = default!;
            return true;
        }

        public bool TryGetAt(int index, out T result)
        {
            try
            {
                CountOutOfRangeCheck(index);
            }
            catch (ArgumentOutOfRangeException) 
            {
                result = default!;
                return false; 
            }

            result = _array[index];
            return true;
        }

        public bool TryForceCapacity(int newCapacity)
        {
            if (newCapacity < 0) return false;
            ResizeArray(newCapacity);
            return true;
        }

        public int Find(T value)
        {
            for (int i = 0; i < _count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(value, _array[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        private void CountOutOfRangeCheck(int index)
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(index, Count);
        }

        private void IncrementCount()
        {
            if (_count >= Capacity) ResizeArray(Capacity * 2);
            _count++;
        }

        private void ResizeArray(int newSize)
        {
            Array.Resize(ref _array, newSize);
            if (_count > Capacity) _count = Capacity;
        }
    }
}
