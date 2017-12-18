using DSProjectUniversal.Util;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSProjectUniversal.Model
{
	/**
	 * <summary>Company class wich stores all data</summary>
	 * */
	public class Company
	{
		/**
		 * <summary>A list to store all services and subservices the company provides</summary>
		 * */
		private SuperServicePool _SuperServicePool;
		/**
		 * <summary>A list of agencies of company</summary>
		 * */
		private LinkedList<Agency> _Agencies;
		/**
		 * <summary>Getter for superServicePool to avoid manipulateion</summary>
		 * */
		public SuperService[] SuperServicePool{ get => _SuperServicePool.List; }
		/**
		 * <summary>Getter for agancies to avoid manipulation</summary>
		 * */
		public Agency[] Agencies { get => _Agencies.ToArray(); }
		/**
		 * <summary>A random field for class to generate random IDs</summary>
		 * */
		private Random Random;

		/**
		 * <summary>Initializes object fields</summary>
		 * */
		public Company()
		{
			_Agencies = new LinkedList<Agency>();
			_SuperServicePool = new Model.SuperServicePool();
			Random = new Random();
		}

		/**
		 * <summary>Adds an agency to list of agancies</summary>
		 * <param name="name">Name of the agency being added</param>
		 * <returns>Result of adding</returns>
		 * <remarks>
		 * Searchs the list of agencies for checking if an agency with the same name already exists
		 * Searchs with O(n) and adds with O(1)
		 * </remarks>
		 * */
		public bool AddAgency(string name)
		{
			foreach (var item in _Agencies.ToArray())
			{
				if (item.AgencyName == name) return false;
			}
			_Agencies.AddLast(new Agency(name));
			return true;
		}

		/**
		 * <summary>Removes an agency from company</summary>
		 * <param name="name">Name of the agency being removed</param>
		 * <returns>Result of removing</returns>
		 * <remarks>Searchs for agancy with O(n) and removes with O(n) where n is number of agencies</remarks>
		 * */
		public bool RemoveAgency(string name)
		{
			foreach (var item in _Agencies.ToArray())
			{
				if(item.AgencyName == name)
				{
					return _Agencies.RemoveElement(item);
				}
			}
			return false;
		}

		/**
		 * <summary>Adds a service to list of provided superservices</summary>
		 * <param name="name">Name of new service</param>
		 * <param name="carModel">Car model of the new service</param>
		 * <param name="cusDesc">Customer instructions of the new serivce</param>
		 * <param name="expence">Expences of the new service for company</param>
		 * <param name="techDesc">Technical instructions of the new service</param>
		 * <returns>Result of adding</returns>
		 * <remarks>
		 * Searchs if a service with the provided name doesn't exist then adds
		 * Searchs with O(n) and adds with O(1) where n is number of services
		 * </remarks>
		 * */
		public bool AddService(string name, string cusDesc, string techDesc, string carModel, int expence)
		{
			foreach (var item in _SuperServicePool.List)
			{
				if (item.Name == name && item.IsService) return false;
			}
			int id;
			lock (this)
			{
				id = Random.Next();
			}
			_SuperServicePool.AddSuperService(new Service(name, cusDesc, techDesc, carModel, expence, id));
			return true;
		}

		/**
		 * <summary>Adds a service or subservice to list of provided superservices by the company</summary>
		 * <param name="service">The super service being added</param>
		 * <returns>Result of adding</returns>
		 * <remarks>
		 * Searches if super service doesn't already existed then adds
		 * Searches with O(n) adds with O(1) where n is number of subservices + services
		 * </remarks>
		 * */
		public bool AddService(SuperService service)
		{
			foreach (var item in _SuperServicePool.List)
			{
				if (item.Name == service.Name) return false;
			}
			_SuperServicePool.AddSuperService(service);
			return true;
		}

		/**
		 * <summary>Removes a superservice from provided list of company</summary>
		 * <param name="id">ID of the super service being removed</param>
		 * <returns>Result of removing</returns>
		 * <remarks>
		 * Searches for the super service then removes it
		 * Searches with O(n) and removes with O(n) where n is number of subservices + services
		 * </remarks>
		 * */
		public bool RemoveService(int id)
		{
			foreach (var item in _SuperServicePool.List)
			{
				if(item.Id == id)
				{
					return _SuperServicePool.RemoveSuperService(item);
				}
			}
			return false;
		}
	}
}
