using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSProjectUniversal.Model
{
	public abstract class SuperPool
	{
	}

	sealed class ServicePool : SuperPool
	{

	}

	sealed class SubServicePool : SuperPool
	{
		
	}
}
