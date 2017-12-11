using DSProjectUniversal.Util;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSProjectUniversal.Model
{
	class Company
	{
		private SuperServicePool _SuperServicePool;
		private LinkedList<Agency> _Agencies;
		public SuperService[] SuperServicePool{ get => _SuperServicePool.List; }
		public Agency[] Agencies { get => _Agencies.ToArray(); }

		public Company()
		{
			_Agencies = new LinkedList<Agency>();
			_SuperServicePool = new Model.SuperServicePool();
		}

	}
}
