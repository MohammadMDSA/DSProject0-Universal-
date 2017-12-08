using DSProject_Universal_;
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
		 * <summary>Initializes ID and Name of current service or subservice with given ID and Name</summary>
		 * */
		public SuperService(string name, int id)
		{
			this.Name = name;
			this.Id = id;
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
		 * <summary>List of subservices of service</summary>
		 * <remarks>Uses Util.LinkedList</remarks>
		 * */
		public LinkedList<SubService> SubServices { get; private set; }

		/**
		 * <summary>Sets fields of class with constructor inputs</summary>
		 * */
		public Service(string name, string cusDesc, string techDesc, string carModel, int expence, int id) : base(name, id)
		{
			this.CustomerDescription = cusDesc;
			this.TechnicalDescription = techDesc;
			this.CarModel = carModel;
			this.Expence = expence;
			this.SubServices = new LinkedList<SubService>();
		}

		/**
		 * <summary></summary>
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

		private bool HasSubService(int id)
		{
			foreach (var item in SubServices.ToArray())
			{
				if (item.Id == id)
					return true;
			}
			return false;
		}

		public override bool HasDependency(int id)
		{
			foreach (var item in SubServices.ToArray())
			{
				if (item.Id == id) return true;
				else if (item.HasDependency(id)) return true;
			}
			return false;
		}

		public Service RemoveSubservice(SubService subService)
		{
			SubServices.RemoveElement(subService);

			subService.RomoveParent(this);
			return this;
		}

		public void Delete()
		{
			foreach (var item in SubServices.ToArray())
			{
				this.RemoveSubservice(item);
			}

			App.ServicePool.RemoveService(this);
		}
	}

	public class SubService : SuperService
	{
		private LinkedList<SubService> SubServices;
		private LinkedList<SuperService> ParentServices;

		public SubService(string name, int id) : base(name, id) { }

		public override bool HasDependency(int id)
		{
			foreach (var item in SubServices.ToArray())
			{
				if (item.Id == id) return true;
				else if (item.HasDependency(id)) return true;
			}
			return false;
		}

		public SubService AddParrent(SuperService parrent)
		{
			ParentServices.AddLast(parrent);

			return this;
		}

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
