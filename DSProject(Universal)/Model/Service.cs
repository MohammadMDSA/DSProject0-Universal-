using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSProject0.Model
{
	abstract class SuperService
	{
		public String Name { get; protected set; }
		public int Id { get; protected set; }

		public SuperService(string name, int id)
		{
			this.Name = name;
			this.Id = id;
		}

		public abstract bool HasDependency(int id);
	}

	class Service : SuperService
	{
		public string CustomerDescription { get; }
		public string TechnicalDescription { get; }
		public string CarModel { get; }
		public int Expence { get; }
		private List<SubService> SubServices;

		public Service(string name, string cusDesc, string techDesc, string carModel, int expence, int id) : base(name, id)
		{
			this.CustomerDescription = cusDesc;
			this.TechnicalDescription = techDesc;
			this.CarModel = carModel;
			this.Expence = expence;
		}

		public Service AddSubService(SubService subService)
		{

			if (!this.HasSubService(subService.Id))
			{
				SubServices.Add(subService);
				subService.AddParrent(this);
			}

			return this;
		}

		private bool HasSubService(int id)
		{
			foreach (SubService item in SubServices)
			{
				if (item.Id == id)
					return true;
			}
			return false;
		}

		public override bool HasDependency(int id)
		{
			foreach (var item in SubServices)
			{
				if (item.Id == id) return true;
				else if (item.HasDependency(id)) return true;
			}
			return false;
		}
	}

	class SubService : SuperService
	{
		private List<SubService> SubServices;
		private List<SuperService> ParrentServices;

		public SubService(string name, int id) : base(name, id) { }

		public override bool HasDependency(int id)
		{
			foreach (var item in SubServices)
			{
				if (item.Id == id) return true;
				else if (item.HasDependency(id)) return true;
			}
			return false;
		}

		public SubService AddParrent(SuperService parrent)
		{
			ParrentServices.Add(parrent);

			return this;
		}
	}
}
