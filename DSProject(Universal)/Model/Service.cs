using DSProjectUniversal;
using DSProjectUniversal.Util;
using DSProjectUniversal.View;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSProjectUniversal.Model
{
	/**
	 * <summary>An abstract represents services and subservices</summary>
	 * */
	public abstract class SuperService
	{

		/**
		 * <summary>Number of parents</summary>
		 * <remarks>Uses Util.LinkedList</remarks>
		 * */
		protected int ParentServices;

		/**
		 * <summary>Name of service or subservice</summary>
		 * */
		public string Name { get; protected set; }
		/**
		 * <summary>Unique ID for service or subservice</summary>
		 * */
		public int Id { get; protected set; }

		/**
		 * <summary>To deferentiate service from subserice</summary>
		 * */

		public bool IsService { get; }
		/**
		 * <summary>List of subservices of service or subservice</summary>
		 * <remarks>Uses Util.LinkedList</remarks>
		 * */
		private LinkedList<SubService> _SubServices;

		/**
		 * <summary>A getter for superservice subservices and conerts linkedlist to array to avoid dara manipulation</summary>
		 * */
		public SubService[] SubServices { get => _SubServices.ToArray(); }

		/**
		 * <summary>Initializes ID and Name of current service or subservice with given ID and Name</summary>
		 * */
		public SuperService(string name, int id, bool isService)
		{			this.Name = name;
			this.Id = id;
			this.IsService = isService;
			ParentServices = 0;
			_SubServices = new LinkedList<SubService>();
		}

		/**
		 * <summary>Removes a subservice/service from parents' list</summary>
		 * <returns>A reference to the very subservice</returns>
		 * <remarks>Removes with O(n)</remarks>
		 * */
		public SuperService RemoveParent()
		{
			ParentServices--;
			if (ParentServices == 0)
			{
				foreach (var item in _SubServices.ToArray())
				{
					item.RemoveParent();
				}
				CompanyViewxaml.Company.RemoveService(this.Id);
			}

			return this;
		}

		/**
		 * <summary>Adds 1 to parents' count</summary>
		 * <returns>A reference to the very subservice</returns>
		 * <remarks>Adds with O(1)</remarks>
		 * */
		public SuperService AddParent()
		{
			ParentServices++;

			return this;
		}

		/**
		 * <summary>Checks if subservice with given ID is in dependency subservices</summary>
		 * <param name="id">ID of sebservice we are searching for</param>
		 * <returns>Returns result of the search</returns>
		 * <remarks>
		 * Checks its own subservices, then checks all of its dependency tree for subservice with given id
		 * Search whit O(n) where O is number of all subservices
		 * </remarks>
		 * */
		public bool HasDependency(int id)
		{
			foreach (var item in _SubServices.ToArray())
			{
				if (item.Id == id) return true;
			}
			foreach (var item in _SubServices.ToArray())
			{
				if (item.HasDependency(id)) return true;
			}
			return false;
		}

		/**
		 * <summary>Adds a subservice to the superservice</summary>
		 * <remarks>First check if service doesn't have the subserve, then adds to service's subservices</remarks>
		 * <param name="subService">Adds given subserivce to service's subservices list</param>
		 * <returns>A reference to the very service</returns>
		 * <remarks>Searchs with O(n) and Adds with O(1)</remarks>
		 * */
		public bool AddSubService(SubService subService)
		{

			if (!this.HasSubService(subService.Id))
			{
				_SubServices.AddLast(subService);
				subService.AddParent();
				return true;
			}
			else
				return false;

		}

		/**
		 * <summary>Checks superservice subservices to see if it already has the given subservice</summary>
		 * <param name="id">ID of the subservice we are searching for</param>
		 * <returns>Result of the searching</returns>
		 * <remarks>Checks with O(n)</remarks>
		 * */
		private bool HasSubService(int id)
		{
			foreach (var item in _SubServices.ToArray())
			{
				if (item.Id == id)
					return true;
			}
			return false;
		}

		/**
		 * <summary>Removes a subservice from service's subservices' list</summary>
		 * <param name="subService">The subservice we are adding to service's subservices's list</param>
		 * <returns>A reference to the very service</returns>
		 * <remarks>Removes with O(n)</remarks>
		 * */
		public SuperService RemoveSubservice(SubService subService)
		{
			_SubServices.RemoveElement(subService);
			subService.RemoveParent();
			return this;
		}
	}

	/**
	 * <summary>A class represents active services for agencies</summary>
	 * */
	public class Service : SuperService
	{
		/**
		 * <summary>Service description for customers</summary>
		 * */
		public string CustomerDescription { get; }
		/**
		 * <summary>Services' technical description</summary>
		 * */
		public string TechnicalDescription { get; }
		/**
		 * <summary>Car model for service</summary>
		 * */
		public string CarModel { get; }
		/**
		 * <summary>The expence of service for company</summary>
		 * */
		public int Expence { get; }

		/**
		 * <summary>Sets fields of class with constructor inputs</summary>
		 * */
		public Service(string name, string cusDesc, string techDesc, string carModel, int expence, int id) : base(name, id, true)
		{
			this.CustomerDescription = cusDesc;
			this.TechnicalDescription = techDesc;
			this.CarModel = carModel;
			this.Expence = expence;
		}

	}

	/**
	 * <summary>A class represents active subservice of services</summary>
	 * */
	public class SubService : SuperService
	{

		/**
		 * <summary>Calls base constructor to set ID and name</summary>
		 * <param name="id">ID of new subservice</param>
		 * <param name="name">Name of new subservice</param>
		 * */
		public SubService(string name, int id) : base(name, id, false) { }

	}
}
