using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSProject0.Model
{
	class Service
	{
		public string Name { get; }
		public string CustomerDescription { get; }
		public string TechnicalDescription { get; }
		public string CarModel { get; }
		public int Expence { get; }
		public int Id{ get; }
		private List<SubService> SubServices;

		Service(string name, string cusDesc, string techDesc, string carModel, int expence, int id)
		{
			this.Name = name;
			this.CustomerDescription = cusDesc;
			this.TechnicalDescription = techDesc;
			this.CarModel = carModel;
			this.Expence = expence;
			this.Id = id;
		}

		Service AddSubService(SubService subService)
		{
			SubServices.Add(subService);

			return this;
		}

		//bool HasSubService(int id)
		//{
		//	SubServices.
		//}
	}

	class SubService
	{
		public string Name { get; }
		private LinkedList<SubService> SubServices;
		private LinkedList<Service> ParrentServices;
	}
}
