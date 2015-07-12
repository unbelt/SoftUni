public void Add(T item)
{
	var newArray = new T[this.array.Length + 1];
	Array.Copy(this.array, newArray, this.array.Length);
	newArray[newArray.Length - 1] = item;
	this.array = newArray;
}

// -- Complexity: O(N)
// ----------------------------------------------------------------------------


public T Remove(int index)
{
	var result = this.array[index];
	var newArray = new T[this.array.Length - 1];
	Array.Copy(this.array, newArray, index);
	Array.Copy(this.array, index + 1, newArray, index, this.array.Length - index - 1);
	this.array = newArray;

	return result;
}

// -- Complexity: O(N) [best case]
// -- Complexity: O(N) [worst case]
// -- Complexity: O(N) [average case]
// ----------------------------------------------------------------------------


public T RemoveFirst()
{
	return this.Remove(0);
}

// -- Complexity: O(N)
// ----------------------------------------------------------------------------


public T RemoveLast()
{
    return this.Remove(this.Lenght - 1);
}

// -- Complexity: O(N)
// ----------------------------------------------------------------------------


public int Lenght
{
	get { return this.array.Length; }
}

// -- Complexity: O(1)
// ----------------------------------------------------------------------------


// This[Index] Complexity

// -- Complexity: O(1)
// ----------------------------------------------------------------------------


public T First
{
	get { return this.array[0]; }
}

// -- Complexity: O(1)
// ----------------------------------------------------------------------------


public T Last
{
    get { return this.array[this.array.Length - 1]; }
}

// -- Complexity: O(1)
// ----------------------------------------------------------------------------