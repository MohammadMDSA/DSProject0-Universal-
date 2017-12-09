using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSProjectUniversal.Util
{
	class MaxHeap<T> where T : IComparable
	{
		public T[] HeapArray;
		public readonly int MaxSize;
		public int Size { get; private set; }

		public MaxHeap(int MaxSize)
		{
			this.MaxSize = MaxSize;
			this.HeapArray = new T[this.MaxSize + 1];
			this.Size = 0;
		}

		public bool Add(T obj)
		{
			if(this.Size == MaxSize)
			{
				return false;
			}

			int index = Size + 1;
			HeapArray[index] = obj;
			while(hasParent(index) && HeapArray[index].CompareTo(HeapArray[index / 2]) > 0)
			{
				T temp = HeapArray[index];
				HeapArray[index] = HeapArray[index / 2];
				HeapArray[index / 2] = temp;
				index /= 2;
			}
			Size++;
			return true;
		}

		public bool remove(T obj)
		{
			if (Size == 0) return false;
			int index = 1;
			bool found = false;
			for (int i = 1; i <= Size; i++)
			{
				if (HeapArray[i].Equals(obj))
				{
					found = true;
					index = i;
					break;
				}
			}
			if (!found) return false;

			HeapArray[index] = HeapArray[Size];
			HeapArray[Size] = default(T);
			Size--;

			while (true)
			{
				if (hasParent(index) && HeapArray[index].CompareTo(HeapArray[index / 2]) > 0)
				{
					T temp = HeapArray[index];
					HeapArray[index] = HeapArray[index / 2];
					HeapArray[index / 2] = temp;
					index = index / 2;
					continue;
				}
				else
				{
					bool hasRight = false;
					bool bad = false;
					if (hasLeftChild(index))
					{
						if (HeapArray[index].CompareTo(HeapArray[2 * index]) < 0)
						{
							bad = true;
						}
					}
					if (hasRightChild(index))
					{
						hasRight = true;
						if (HeapArray[index].CompareTo(HeapArray[2 * index + 1]) < 0)
						{
							bad = true;
						}
					}
					if (!bad)
					{
						return true;
					}
					int maxChild = 2 * index;
					if (hasRight)
					{
						if (HeapArray[2 * index].CompareTo(HeapArray[2 * index + 1]) < 0)
						{
							maxChild = 2 * index + 1;
						}
					}
					T temp = HeapArray[index];
					HeapArray[index] = HeapArray[maxChild];
					HeapArray[maxChild] = temp;
					index = maxChild;
				}
			}
		}

		private bool hasParent(int index)
		{
			if (index == 1) return false;
			if (HeapArray[index / 2] == null) return false;
			return true;
		}

		private bool hasLeftChild(int index)
		{
			if (index * 2 > Size) return false;
			if (HeapArray[index * 2] == null) return false;
			return true;
		}

		private bool hasRightChild(int index)
		{
			if (index * 2 + 1 > Size) return false;
			if (HeapArray[index * 2] == null) return false;
			return true;
		}
	}
}
