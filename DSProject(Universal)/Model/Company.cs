using DSProjectUniversal.Util;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSProjectUniversal.Model
{
	public class Company
	{
		private SuperServicePool _SuperServicePool;
		private LinkedList<Agency> _Agencies;
		public SuperService[] SuperServicePool{ get => _SuperServicePool.List; }
		public Agency[] Agencies { get => _Agencies.ToArray(); }
		private Random Random;

		public Company()
		{
			_Agencies = new LinkedList<Agency>();
			_SuperServicePool = new Model.SuperServicePool();
			Random = new Random();
		}

		public bool AddAgency(string name)
		{
			foreach (var item in _Agencies.ToArray())
			{
				if (item.AgencyName == name) return false;
			}
			_Agencies.AddLast(new Agency(name));
			return true;
		}

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

		public bool AddService(Service service)
		{
			foreach (var item in _SuperServicePool.List)
			{
				if (item.Name == service.Name && item.IsService) return false;
			}
			_SuperServicePool.AddSuperService(service);
			return true;
		}

		public bool RemoveService(int id)
		{
			foreach (var item in _SuperServicePool.List)
			{
				if(item.Id == id && item.IsService)
				{
					return _SuperServicePool.RemoveSuperService(item);
				}
			}
			return false;
		}
	}
}
