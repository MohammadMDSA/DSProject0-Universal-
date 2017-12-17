using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSProjectUniversal.Util
{
	/**
	 * <summary>A Linked list structure to store data</summary>
	 * */
	public class LinkedList<T>
	{
		/**
		 * <summary>Holds reference of first node of linked list(Always empty)</summary>
		 * */
		public Node<T> First { get; private set; }
		/**
		 * <summary>Holds reference of last node of linked list</summary>
		 * */
		public Node<T> Last { get; private set; }
		/**
		 * <summary>Number of nodes in linked list</summary>
		 * */
		public int Length { get; private set; }

		/**
		 * <summary>Sets value of length to 0 and initializes first node</summary>
		 * */
		public LinkedList()
		{
			this.Last = this.First = this.First = new Node<T>();
			this.Length = 0;
		}

		/**
		 * <summary>Adds a node to end of linked list</summary>
		 * <param name="data">Data of the new node</param>
		 * <returns>Reference to the very linked list</returns>
		 * <remarks>Adds with O(1)</remarks>
		 * */
		public LinkedList<T> AddLast(T data)
		{
			var newNode = new Node<T>(data, this.Last);
			Length++;
			this.Last.SetNext(newNode);
			this.Last = newNode;

			return this;
		}

		/**
		 * <summary>Removes the last node of lined list</summary>
		 * <returns>Retunrs the very node functions deleted</returns>
		 * <remarks>Removes with O(1)</remarks>
		 * */
		public Node<T> RemoveLast()
		{
			if (Length == 0) throw new Exception("Linked list is empty...");
			var temp = this.Last;
			this.Last = this.Last.Previous;
			this.Last.Next.SetPrevious(null);
			this.Last.SetNext(null);
			Length--;
			return temp;
		}
	
		/**
		 * <summary>Removes a node from linked list with specific data</summary>
		 * <param name="data">Data of the node being removed</param>
		 * <returns>Result of removing</returns>
		 * <remarks>Removes with O(n)</remarks>
		 * */
		public bool RemoveElement(T data)
		{
			if (Length == 0) return false;
			Node<T> container = First;
			bool found = false;
			while(container.Next != null)
			{
				if(container.Next.Data.Equals(data))
				{
					found = true;
					container = container.Next;
					break;
				}
				container = container.Next;

			}
			if (!found) return false;
			if(container.Previous != null)
				container.Previous.SetNext(container.Next);
			if (container.Next != null)
				container.Next.SetPrevious(container.Previous);
			else
				Last = container.Previous;
			container.SetPrevious(null);
			container.SetNext(null);
			Length--;
			return false;
		}

		/**
		 * <summary>Converts linked list to its node's array</summary>
		 * <returns>An array of nodes of linked list</returns>
		 * <remarks>Converts with O(n)</remarks>
		 * */
		public Node<T>[] ToNodeArray()
		{
			var index = 0;
			var current = First;
			var result = new Node<T>[this.Length];
			while(current.Next != null)
			{
				result[index++] = current.Next;
				current = current.Next;
			}
			return result;
		}
		
		/**
		 * <summary>Converts stored data to an array</summary>
		 * <returns>An array of contained data</returns>
		 * <remarks>Converts with O(n)</remarks>
		 * */
		public T[] ToArray()
		{
			var index = 0;
			var current = First;
			var result = new T[this.Length];
			while (current.Next != null)
			{
				result[index++] = current.Next.Data;
				current = current.Next;
			}
			return result;
		}

		/**
		 * <summary>Check linkedlist for a specific object</summary>
		 * <param name="element">Element we are searching for in linkedlist</param>
		 * <returns>Result of searching</returns>
		 * <remarks>Search with O(n)</remarks>
		 * */
		public bool HasElement(T element)
		{
			Node<T> current = First;
			while(current.Next != null)
			{
				if (current.Next.Data.Equals(element)) return true;
				current = current.Next;
			}
			return false;
		}
	}

	/**
	 * <summary>Class of objects representing nodes of a linked list</summary>
	 * */
	public class Node<T>
	{
		/**
		 * <summary>Pointer to next node in list</summary>
		 * */
		public Node<T> Next { get; private set; }
		/**
		 * <summary>Pointer to previous node in list</summary>
		 * */
		public Node<T> Previous { get; private set; }
		/**
		 * <summary>Data object of the node to store any kind of data</summary>
		 * */
		public T Data { get; private set; }

		/**
		 * <summary>Sets pointers to next and previous nodes in list to false</summary>
		 * */
		public Node()
		{
			this.Previous = null;
			this.Next = null;
		}

		/**
		 * <summary>Sets data of node to the given data</summary>
		 * */
		public Node(T data)
		{
			this.Data = data;
		}

		/**
		 * <summary>Sets data and pointer to previous node of list to given values</summary>
		 * */
		public Node(T data, Node<T> previous) : this(data)
		{
			this.Previous = previous;
		}

		/**
		 * <summary>Sets data and pointers to previous and next nodes on list to given values</summary>
		 * */
		public Node(T data, Node<T> previous, Node<T> next) : this(data, previous)
		{
			this.Next = next;
		}

		/**
		 * <summary>Sets pointer to next node on list to given value</summary>
		 * <param name="next">Reference to the node set to be pointer to next node on list</param>
		 * <returns>Reference to the very node</returns>
		 * */
		public Node<T> SetNext(Node<T> next)
		{
			this.Next = next;
			return this;
		}

		/**
		 * <summary>Sets pointer to previious node on list to given value</summary>
		 * <param name="previous">Reference to the node set to be pointer to previous node on list</param>
		 * <returns>Reference to the very node</returns>
		 * */
		public Node<T> SetPrevious(Node<T> previous)
		{
			this.Previous = previous;
			return this;
		}

		/**
		 * <summary>Sets data of node to given value</summary>
		 * <param name="data">The data we are setting node's data to</param>
		 * <returns>Reference to the very node</returns>
		 * */
		public Node<T> SetData(T data)
		{
			this.Data = data;
			return this;
		}
	}
}
