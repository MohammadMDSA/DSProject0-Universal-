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
			return temp;
		}
	
		/**
		 * <summary>Removes a node from linked list with specific data</summary>
		 * <param name="data">Data of the node being removed</param>
		 * <returns>Reference to the very linked list</returns>
		 * <remarks>Removes with O(n)</remarks>
		 * */
		public LinkedList<T> RemoveElement(T data)
		{
			if (Length == 0) return this;
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
			if (!found) return this;
			if(container.Previous != null)
				container.Previous.SetNext(container.Next);
			if(container.Next != null)
				container.Next.SetPrevious(container.Previous);
			container.SetPrevious(null);
			container.SetPrevious(null);
			Length--;
			return this;
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
	}

	public class Node<T>
	{
		public Node<T> Next { get; private set; }
		public Node<T> Previous { get; private set; }
		public T Data { get; private set; }

		public Node()
		{
			this.Previous = null;
			this.Next = null;
		}

		public Node(T data)
		{
			this.Data = data;
		}

		public Node(T data, Node<T> previous) : this(data)
		{
			this.Previous = previous;
		}

		public Node(T data, Node<T> previous, Node<T> next) : this(data, previous)
		{
			this.Next = next;
		}

		public Node<T> SetNext(Node<T> next)
		{
			this.Next = next;
			return this;
		}

		public Node<T> SetPrevious(Node<T> previous)
		{
			this.Previous = previous;
			return this;
		}

		public Node<T> SetData(T data)
		{
			this.Data = data;
			return this;
		}
	}
}
