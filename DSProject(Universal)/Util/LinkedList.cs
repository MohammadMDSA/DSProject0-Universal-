using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSProjectUniversal.Util
{
	public class LinkedList<T>
	{
		public Node<T> First { get; private set; }
		public Node<T> Last { get; private set; }
		public int Length { get; private set; }

		public LinkedList()
		{
			this.Last = this.First = this.First = new Node<T>();
			this.Length = 0;
		}

		public LinkedList<T> AddLast(T data)
		{
			var newNode = new Node<T>(data, this.Last);
			Length++;
			this.Last.SetNext(newNode);
			this.Last = newNode;

			return this;
		}

		public Node<T> RemoveLast()
		{
			if (Length == 0) throw new Exception("Linked list is empty...");
			var temp = this.Last;
			this.Last = this.Last.Previous;
			this.Last.Next.SetPrevious(null);
			this.Last.SetNext(null);
			return temp;
		}

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
