using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSProjectUniversal.Model
{
	/**
	 * <summary>Order class which represents order of customers</summary>
	 * */
	public class Order : IComparable<Order>
	{
		/**
		 * <summary>Priority of the order</summary>
		 * <remarks>Accepts an atomic value of enum Priority</remarks>
		 * */
		public Priority Priority { get; }
		/**
		 * <summary>The service was requested by the customer for the order</summary>
		 * */
		public Service Service { get; }
		/**
		 * <summary>Name of the order</summary>
		 * */
		public string Name { get; }
		/**
		 * <summary>The time, order was submitted</summary>
		 * */
		public DateTime Time { get; }

		/**
		 * <summary>Sets informations of the order and creates its object</summary>
		 * */
		public Order(string name, Service service, Priority priority)
		{
			this.Name = name;
			this.Priority = priority;
			this.Service = service;
			Time = DateTime.Now;
		}

		/**
		 * <summary>Makes orders comparable to put them in queue</summary>
		 * <param name="other">Other order being compared to this order</param>
		 * <returns>Returns a value greater than zero, zero and value less than zero when this object has higher, equel or lower priority than given object respectively</returns>
		 * */
		public int CompareTo(Order other)
		{
			if (this.Priority > other.Priority) return 1;
			if (this.Priority < other.Priority) return -1;
			if (this.Time > other.Time) return -1;
			if (this.Time < other.Time) return 1;
			return 0;
		}
	}

	/**
	 * <summary>An enum represents priority</summary>
	 * <remarks>Uses atomic and limited values</remarks>
	 * */
	public enum Priority
	{
		/**
		 * <summary>Represents the highest priority</summary>
		 * */
		VeryHigh = 4,
		/**
		 * <summary>Represents high priority</summary>
		 * */
		High = 3,
		/**
		 * <summary>Represents normal priority</summary>
		 * */
		Normal = 2,
		/**
		 * <summary>Represents low priority</summary>
		 * */
		Low = 1,
		/**
		 * <summary>Represents the lowerst priority</summary>
		 * */
		VeryLow = 0
	}
}
