using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSProject_Universal_.Util
{
	class LinkedList<T>
	{
		private Node<T> First;
		private Node<T> Last;
		public int Length { get; private set; }

		public LinkedList()
		{
			this.Last = null;
			this.First = new Node<T>();
			this.Length = 0;
		}
	}

	class Node<T>
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
