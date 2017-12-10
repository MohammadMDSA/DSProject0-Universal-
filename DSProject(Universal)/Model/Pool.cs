using DSProjectUniversal.Util;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSProjectUniversal.Model
{
	/**
	 * <summary>A place to store all active services/subservice</summary>
	 * */
	public sealed class SuperServicePool
	{
		/**
		 * <summary>Stores SuperServices</summary>
		 * */
		private LinkedList<SuperService> List;
		/**
		 * <summary>Return number of active services</summary>
		 * */
		public int Length => List.Length;


		/**
		 * <summary>Creating list object</summary>
		 * */
		public SuperServicePool()
		{
			List = new LinkedList<SuperService>();
		}

		/**
		 * <summary>Adds a service in active services list</summary>
		 * <param name="service">The service/subservice to be added to pool</param>
		 * <returns>A reference to the very superpool</returns>
		 * <remarks>Adds with O(1)</remarks>
		 * */
		public SuperServicePool AddSuperService(SuperService service)
		{
			List.AddLast(service);
			return this;
		}

		/**
		 * <summary>Removes a service from active services</summary>
		 * <param name="service">The service/subservice to be removed from pool</param>
		 * <returns>A reference to the very superpool</returns>
		 * */
		public SuperServicePool RemoveSuperService(SuperService service)
		{
			List.RemoveElement(service);
			return this;
		}

		/**
		 * <summary>Finds an active service by ID</summary>
		 * <param name="id">ID of the service we are looking for</param>
		 * <remarks>Finds with O(n)</remarks>
		 * <returns>The service/subservice with given ID</returns>
		 * */
		public SuperService GetSuperService(int id)
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
