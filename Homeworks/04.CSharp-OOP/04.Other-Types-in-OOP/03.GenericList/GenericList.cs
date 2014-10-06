namespace GenericList
{
    using System;
    using System.Text;

    [VersionAttribute(2.11)]
    public class GenericList<T>
    {
        private const int DefaultCapacity = 16;
        private T[] _elements;
        private int _nextElement;
        private int _capacity;

        #region Constructors

        public GenericList()
            : this(DefaultCapacity)
        {
        }

        public GenericList(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException("capacity", "The capacity cannot be less then zero!");
            }

            _capacity = capacity;
            _elements = new T[_capacity];
            _nextElement = 0;
        }

        #endregion

        #region Properties

        // Get count of the elements
        public int Count
        {
            get { return _nextElement; }
        }

        // Indexer
        public T this[int index]
        {
            get
            {
                IsIndexInRange(index);
                return _elements[index];
            }

            set
            {
                IsIndexInRange(index);
                _elements[index] = value;
            }
        }

        #endregion

        // Add Element
        public void AddElement(T element)
        {
            if (_nextElement >= _capacity)
            {
                Grow();
            }

            _elements[_nextElement] = element;
            _nextElement++;
        }

        // Remove Element at given index
        public void RemoveElementAtIndex(int index)
        {
            IsIndexInRange(index);

            T nextElement = default(T);

            for (int i = index; i < _elements.Length - 1; i++)
            {
                nextElement = _elements[i + 1];
                _elements[i] = nextElement;
            }

            _nextElement--;
        }

        // Insert element at given index
        public void InsertElementAtIndex(int index, T element)
        {
            IsIndexInRange(index);

            if (_nextElement >= _capacity)
            {
                Grow();
            }

            for (int i = _nextElement; i > index; i--)
            {
                _elements[i] = _elements[i - 1];
            }

            _elements[index] = element;
            _nextElement++;
        }

        // Find element by value
        public string FindElementByValue(T value)
        {
            int index = Array.IndexOf(_elements, value);

            if (index < 0)
            {
                return "The element does not exist in the list.";
            }

            return "The element is found at index: " + index;
        }

        // Clear the list with default capacity (16)
        public void ClearList()
        {
            _elements = new T[_capacity];
            _nextElement = 0;
        }

        // Print the list
        public override string ToString()
        {
            var print = new StringBuilder();

            for (int i = 0; i < _nextElement - 1; i++)
            {
                print.AppendFormat("{0}, ", _elements[i]);
            }

            print.Append(_elements[_nextElement - 1]);

            return print.ToString();
        }

        // Grow size of the list (double)
        private void Grow()
        {
            var oldList = new T[_capacity];
            _elements.CopyTo(oldList, 0);
            _capacity *= 2;
            _elements = new T[_capacity];
            oldList.CopyTo(_elements, 0);
        }

        // Check is index in range
        private void IsIndexInRange(int index)
        {
            if (index < 0 && index >= _nextElement)
            {
                throw new IndexOutOfRangeException("The index is out of range!");
            }
        }
    }
}