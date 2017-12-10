using DSProjectUniversal.Util;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSProjectUniversal.Model
{
	class Agency
	{
		/**
		 * <summary>A priority queue storeing orders with their immidia</summary>
		 * */
		private MaxHeap<Order> _OrdersListn;

		/**
		 * <summary>A list to store services the agency provide</summary>
		 * 
		 * */
		private LinkedList<Service> _Services;
		public Order[] Orders { get => _OrdersListn.HeapArray; }
		public Service[] Services { get => _Services.ToArray(); }
		public string AgencyName { get; }

		public Agency(string name)
		{
			this.AgencyName = name;
		}

		public bool AddService(Service service)
		{
			if (_Services.HasElement(service)) return false;
			_Services.AddLast(service);
			service.AddParent();
			return true;
		}

		public bool RemoveService(Service service)
		{
			bool result = _Services.RemoveElement(service);
			if (result)
				service.RemoveParent();

			return result;
		}

		public bool AddOrder(Order order)
		{

			if (_OrdersListn.HasElement(order)) return false;
			return _OrdersListn.Add(order);
		}

		public Order GetFirstOrder()
		{
			return _OrdersListn.RemoveFirst();
		}
	}
}
