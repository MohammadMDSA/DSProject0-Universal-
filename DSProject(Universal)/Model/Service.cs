using DSProjectUniversal;
using DSProjectUniversal.Util;
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
		public LinkedList<SubService> SubServices { get; protected set; }

		/**
		 * <summary>Initializes ID and Name of current service or subservice with given ID and Name</summary>
		 * */
		public SuperService(string name, int id, bool isService)
		{
			this.Name = name;
			this.Id = id;
			this.IsService = isService;
		}

		/**
		 * <summary>Checks service or subservice if it has a subservice in its subservices recursivly</summary>
		 * <param name="id">ID of the subservice we are looking for</param>
		 * <returns>Returns true if it has the subservice and return false otherwise</returns>
		 * */
		public abstract bool HasDependency(int id);

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
			this.SubServices = new LinkedList<SubService>();
		}

		/**
		 * <summary>Adds a subservice to the service</summary>
		 * <remarks>First check if service doesn't have the subserve, then adds to service's subservices</remarks>
		 * <param name="subService">Adds given subserivce to service's subservices list</param>
		 * <returns>A reference to the very service</returns>
		 * <remarks>Adds with O(1)</remarks>
		 * */
		public Service AddSubService(SubService subService)
		{

			if (!this.HasSubService(subService.Id))
			{
				SubServices.AddLast(subService);
				subService.AddParrent(this);
			}

			return this;
		}
		/**
		 * <summary>Checks service subservices to see if it already has the given subservice</summary>
		 * <param name="id">ID of the subservice we are searching for</param>
		 * <returns>Result of the searching</returns>
		 * <remarks>Checks with O(n)</remarks>
		 * */
		private bool HasSubService(int id)
		{
			foreach (var item in SubServices.ToArray())
			{
				if (item.Id == id)
					return true;
			}
			return false;
		}

		/**
		 * <summary>Checks service's dependency tree it see if has the subservice with given ID</summary>
		 * <param name="id">ID of subservice we are are searching for</param>
		 * <returns>Result of the serarching</returns>
		 * <remarks>Checks with O(n) where n is number of all subservices</remarks>
		 * */
		public override bool HasDependency(int id)
		{
			foreach (var item in SubServices.ToArray())
			{
				if (item.Id == id) return true;
				else if (item.HasDependency(id)) return true;
			}
			return false;
		}

		/**
		 * <summary>Removes a subservice from service's subservices' list</summary>
		 * <param name="subService">The subservice we are adding to service's subservices's list</param>
		 * <returns>A reference to the very service</returns>
		 * <remarks>Removes with O(n)</remarks>
		 * */
		public Service RemoveSubservice(SubService subService)
		{
			SubServices.RemoveElement(subService);
			subService.RomoveParent(this);
			return this;
		}

		/**
		 * <summary>Deletes service and tell all its subservices to remove this service frome their parents list</summary>
		 * */
		public void Delete()
		{
			foreach (var item in SubServices.ToArray())
			{
				this.RemoveSubservice(item);
			}

			App.ServicePool.RemoveService(this);
		}
	}

	/**
	 * <summary>A class represents active subservice of services</summary>
	 * */
	public class SubService : SuperService
	{
		/**
		 * <summary>A list of SuperServices to store parents of the subservice</summary>
		 * <remarks>Uses Util.LinkedList</remarks>
		 * */
		private LinkedList<SuperService> ParentServices;

		/**
		 * <summary>Calls base constructor to set ID and name</summary>
		 * */
		public SubService(string name, int id) : base(name, id, false) { }

		/**
		 * <summary>Checks if subservice with given ID is in dependency subservices</summary>
		 * <param name="id">ID of sebservice we are searching for</param>
		 * <returns>Returns result of the search</returns>
		 * <remarks>Checks its own subservices, then checks all of its dependency tree for subservice with given id</remarks>
		 * */
		public override bool HasDependency(int id)
		{
			foreach (var item in SubServices.ToArray())
			{
				if (item.Id == id) return true;
			}
			foreach (var item in SubServices.ToArray())
			{
				if (item.HasDependency(id)) return true;
			}
			return false;
		}

		/**
		 * <summary>Adds a subservice or service as it's parent in its parents' list</summary>
		 * <returns>A reference to the very subservice</returns>
		 * <remarks>Adds with O(1)</remarks>
		 * */
		public SubService AddParrent(SuperService parrent)
		{
			ParentServices.AddLast(parrent);

			return this;
		}

		/**
		 * <summary>Removes a subservice/service from parents' list</summary>
		 * <param name="parent">The super service being removed from parents</param>
		 * <returns>A reference to the very subservice</returns>
		 * <remarks>Removes with O(n)</remarks>
		 * */
		public SubService RomoveParent(SuperService parent)
		{
			ParentServices.RemoveElement(parent);
			if (ParentServices.Length == 0)
			{
				foreach (var item in SubServices.ToArray())
				{
					item.RomoveParent(this);
				}
				App.SubServicePool.RemoveSubService(this);
			}

			return this;
		}
	}
}
