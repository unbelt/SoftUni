namespace StupidList
{
    using System;

    public class StupidList<T>
    {
        private T[] array = new T[0];

        public int Lenght
        {
            get { return this.array.Length; }
        }

        public T First
        {
            get { return this.array[0]; }
        }

        public T Last
        {
            get { return this.array[this.array.Length - 1]; }
        }

        public void Add(T item)
        {
            var newArray = new T[this.array.Length + 1];
            Array.Copy(this.array, newArray, this.array.Length);
            newArray[newArray.Length - 1] = item;
            this.array = newArray;
        }

        public T Remove(int index)
        {
            var result = this.array[index];
            var newArray = new T[this.array.Length - 1];
            Array.Copy(this.array, newArray, index);
            Array.Copy(this.array, index + 1, newArray, index, this.array.Length - index - 1);
            this.array = newArray;

            return result;
        }

        public T RemoveFirst()
        {
            return this.Remove(0);
        }

        public T RemoveLast()
        {
            return this.Remove(this.Lenght - 1);
        }
    }
}