using DSProjectUniversal.Util;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSProjectUniversal.Model
{
	public class Agency
	{
		/**
		 * <summary>A priority queue storeing orders with their immidiacy</summary>
		 * */
		private MaxHeap<Order> _OrdersList;

		/**
		 * <summary>A list to store services the agency provide</summary>
		 * */
		private LinkedList<Service> _Services;

		/**
		 * <summary>Getter of orders list</summary>
		 * <remarks>Converts to Order[] to avoid manipulation</remarks>
		 * */
		public Order[] Orders { get => _OrdersList.HeapArray; }

		/**
		 * <summary>Getter of services list</summary>
		 * <remarks>Converts to Service[] to avoid manipulation</remarks>
		 * */
		public Service[] Services { get => _Services.ToArray(); }

		/**
		 * <summary>Name of the agency</summary>
		 * */
		public string AgencyName { get; }

		/**
		 * <summary>Sets name of agency with given input</summary>
		 * <param name="name">Name of the agency</param>
		 * */
		public Agency(string name)
		{
			this.AgencyName = name;
		}

		/**
		 * <summary>Adds a service to services</summary>
		 * <param name="service">Service being added to services list</param>
		 * <returns>Result of adding</returns>
		 * <remarks>Adds with O(1)</remarks>
		 * */
		public bool AddService(Service service)
		{
			if (_Services.HasElement(service)) return false;
			_Services.AddLast(service);
			service.AddParent();
			return true;
		}

		/**
		 * <summary>Removes a service form services list</summary>
		 * <param name="service">The service being removed</param>
		 * <returns>Result of the removing</returns>
		 * <remarks>Removes with O(n)</remarks>
		 * */
		public bool RemoveService(Service service)
		{
			bool result = _Services.RemoveElement(service);
			if (result)
				service.RemoveParent();

			return result;
		}

		/**
		 * <summary>Adds order to orders list</summary>
		 * <param name="order">The order being added to orders lsit</param>
		 * <returns>Result of adding</returns>
		 * <remarks>Adds with O(1)</remarks>
		 * */
		public bool AddOrder(Order order)
		{
			if (_OrdersList.HasElement(order)) return false;
			return _OrdersList.Add(order);
		}

		/**
		 * <summary>Removes the most prior element of orderlist</summary>
		 * <returns>The most prior node which was removed</returns>
		 * <remarks>Gets and removed with O(lgn)</remarks>
		 * */
		public Order GetFirstOrder()
		{
			return _OrdersList.RemoveFirst();
		}
	}
}
