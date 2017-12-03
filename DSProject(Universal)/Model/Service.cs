using DSProject_Universal_;
using DSProjectUniversal.Util;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSProjectUniversal.Model
{
	public abstract class SuperService
	{
		public string Name { get; protected set; }
		public int Id { get; protected set; }

		public SuperService(string name, int id)
		{
			this.Name = name;
			this.Id = id;
		}

		public abstract bool HasDependency(int id);

	}

	public class Service : SuperService
	{
		public string CustomerDescription { get; }
		public string TechnicalDescription { get; }
		public string CarModel { get; }
		public int Expence { get; }
		public LinkedList<SubService> SubServices { get; private set; }

		public Service(string name, string cusDesc, string techDesc, string carModel, int expence, int id) : base(name, id)
		{
			this.CustomerDescription = cusDesc;
			this.TechnicalDescription = techDesc;
			this.CarModel = carModel;
			this.Expence = expence;
			this.SubServices = new LinkedList<SubService>();
		}

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

			App.ServicePool.RemoveService
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
			ParrentServices.AddLast(parrent);

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
