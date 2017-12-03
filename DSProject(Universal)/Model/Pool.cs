using DSProjectUniversal.Util;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSProjectUniversal.Model
{
	/**
	 * <summary>A place to store all active services</summary>
	 * */
	public sealed class ServicePool
	{
		/**
		 * <summary>Stores SuperServices</summary>
		 * */
		private LinkedList<Service> List;
		/**
		 * <summary>Return number of active services</summary>
		 * */
		public int Length => List.Length;


		/**
		 * <summary>Creating list object</summary>
		 * */
		public ServicePool()
		{
			List = new LinkedList<Service>();
		}

		/**
		 * <summary>Adds a service in active services list</summary>
		 * */
		public ServicePool AddService(Service service)
		{
			List.AddLast(service);
			return this;
		}

		/**
		 * <summary>Removes a service from active services</summary>
		 * */
		public ServicePool RemoveService(Service service)
		{
			List.RemoveElement(service);
			return this;
		}

		/**
		 * <summary>Finds an active service by ID</summary>
		 * <param name="id">ID of the service we are looking for</param>
		 * <remarks>Finds with O(n)</remarks>
		 * <returns>The service with given ID</returns>
		 * */
		public Service GetService(int id)
		{
			var temp = List.ToArray();
			foreach (var item in temp)
			{
				if (item.Id == id)
					return item;
			}
			return null;
		}
	}

	/**
	 * <summary>A place to store all active subservices</summary>
	 * */
	public sealed class SubServicePool
	{
		/**
		 * <summary>Stores SuperServices</summary>
		 * */
		protected LinkedList<SubService> List;
		/**
		 * <summary>Returns number of active subservices</summary>
		 * */
		public int Length => List.Length;

		/**
		 * <summary>Creates list object to store subservices</summary>
		 * */
		public SubServicePool()
		{
			List = new LinkedList<SubService>();
		}

		/**
		 * <summary>Add a sub service to active subservices list</summary>
		 * */
		public SubServicePool AddSubService(SubService subService)
		{
			List.AddLast(subService);
			return this;
		}

		/**
		 * <summary>Removes a subservice from active subservices list</summary>
		 * */
		public SubServicePool RemoveSubService(SubService subService)
		{
			List.RemoveElement(subService);
			return this;
		}

		/**
		 * <summary>Finds a subservice by ID</summary>
		 * <param name="id">ID of subservice we are looking for</param>
		 * <remarks>Finds with O(n)</remarks>
		 * <returns>The subservice with the given ID</returns>
		 * */
		public SubService GetSubService(int id)
		{
			var temp = List.ToArray();
			foreach (var item in temp)
			{
				if (item.Id == id)
					return item;
			}
			return null;
		}
	}
}
