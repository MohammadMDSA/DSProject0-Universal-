﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSProjectUniversal.Util
{
	/**
	 * <summary>Maxheap data structure to store data</summary>
	 * <remarks>Use to create prioritu queue</remarks>
	 * */
	class MaxHeap<T> where T : IComparable<T>
	{
		/**
		 * <summary>An array to store heap data</summary>
		 * */
		private T[] _HeapArray;

		/**
		 * <summary>Getter for implementation array to avoid manipulation</summary>
		 * */
		public T[] HeapArray
		{
			get
			{
				T[] result = new T[Size];
				for (int i = 1; i <= Size; i++)
				{
					result[i - 1] = _HeapArray[i];
				}
				return result;
			}
		}
		/**
		 * <summary>Maximum size of the heap (and implementation array)</summary>
		 * */
		public readonly int MaxSize;
		/**
		 * <summary>Number of elements in heap</summary>
		 * */
		public int Size { get; private set; }

		/**
		 * <summary>Sets heap maximum size and initiates fields value</summary>
		 * <param name="MaxSize">Maximum size of heap</param>
		 * */
		public MaxHeap(int MaxSize)
		{
			this.MaxSize = MaxSize;
			this._HeapArray = new T[this.MaxSize + 1];
			this.Size = 0;
		}

		/**
		 * <summary>Adds an element to heap</summary>
		 * <param name="obj">The object being added to heap</param>
		 * <returns>Result of adding</returns>
		 * <remarks>Adds with O(logn)</remarks>
		 * */
		public bool Add(T obj)
		{
			if (this.Size == MaxSize)
			{
				return false;
			}

			int index = Size + 1;
			_HeapArray[index] = obj;
			while (HasParent(index) && _HeapArray[index].CompareTo(_HeapArray[index / 2]) > 0)
			{
				T temp = _HeapArray[index];
				_HeapArray[index] = _HeapArray[index / 2];
				_HeapArray[index / 2] = temp;
				index /= 2;
			}
			Size++;
			return true;
		}

		/**
		 * <summary>Removes an object from heap</summary>
		 * <param name="obj">Object being removed from heap</param>
		 * <returns>Result of removing</returns>
		 * <remarks>Removes with O(logn)</remarks>
		 * */
		public bool Remove(T obj)
		{
			if (Size == 0) return false;
			int index = 1;
			bool found = false;
			for (int i = 1; i <= Size; i++)
			{
				if (_HeapArray[i].Equals(obj))
				{
					found = true;
					index = i;
					break;
				}
			}
			if (!found) return false;

			_HeapArray[index] = _HeapArray[Size];
			_HeapArray[Size] = default(T);
			Size--;

			if (HasParent(index) && _HeapArray[index].CompareTo(_HeapArray[index / 2]) > 0)
			{
				while (HasParent(index) && _HeapArray[index].CompareTo(_HeapArray[index / 2]) > 0)
				{
					T temp = _HeapArray[index];
					_HeapArray[index] = _HeapArray[index / 2];
					_HeapArray[index / 2] = temp;
					index = index / 2;
				}
				return true;
			}
			else
			{
				while (true)
				{
					bool hasRight = false;
					bool bad = false;
					if (HasLeftChild(index))
					{
						if (_HeapArray[index].CompareTo(_HeapArray[2 * index]) < 0)
						{
							bad = true;
						}
					}
					if (HasRightChild(index))
					{
						hasRight = true;
						if (_HeapArray[index].CompareTo(_HeapArray[2 * index + 1]) < 0)
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
						if (_HeapArray[2 * index].CompareTo(_HeapArray[2 * index + 1]) < 0)
						{
							maxChild = 2 * index + 1;
						}
					}
					T temp = _HeapArray[index];
					_HeapArray[index] = _HeapArray[maxChild];
					_HeapArray[maxChild] = temp;
					index = maxChild;
				}
			}
		}


		/**
		 * <summary>Determines if a node has parent or not</summary>
		 * <param name="index">Index of the node we are checking in implementation array</param>
		 * <returns>Result of cheching</returns>
		 * <remarks>Check with O(1)</remarks>
		 * */
		private bool HasParent(int index)
		{
			if (index == 1) return false;
			if (_HeapArray[index / 2] == null) return false;
			return true;
		}

		/**
		 * <summary>Determines if a node has left child or not</summary>
		 * <param name="index">Index of the node we are checking in implementation array</param>
		 * <returns>Result of cheching</returns>
		 * <remarks>Check with O(1)</remarks>
		 * */
		private bool HasLeftChild(int index)
		{
			if (index * 2 > Size) return false;
			if (_HeapArray[index * 2] == null) return false;
			return true;
		}

		/**
		 * <summary>Determines if a node has right child or not</summary>
		 * <param name="index">Index of the node we are checking in implementation array</param>
		 * <returns>Result of cheching</returns>
		 * <remarks>Check with O(1)</remarks>
		 * */
		private bool HasRightChild(int index)
		{
			if (index * 2 + 1 > Size) return false;
			if (_HeapArray[index * 2] == null) return false;
			return true;
		}

		/**
		 * <summary>Removes root of the heap</summary>
		 * <returns>The object which was stored in root of the heap</returns>
		 * <remarks>Removes with O(logn)</remarks>
		 * */
		public T RemoveFirst()
		{
			T result = _HeapArray[1];
			bool remResult = this.Remove(result);
			if (!remResult) return default(T);
			return result;
		}

		/**
		 * <summary>Check heap if it has an object or not</summary>
		 * <param name="element">The object we are searching for in heap</param>
		 * <returns>Result of searchin</returns>
		 * <remarks>Searchs with O(n)</remarks>
		 * */
		public bool HasElement(T element)
		{
			foreach (var item in _HeapArray)
			{
				if (element.Equals(item))
				{
					return true;
				}
			}
			return false;
		}
	}
}
