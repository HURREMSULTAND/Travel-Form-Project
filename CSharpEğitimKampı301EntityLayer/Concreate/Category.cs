using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEğitimKampı301EntityLayer.Concreate
{
	public class Category
	{
		public int CategoryId { get; set; }
		public string CategoryName { get; set; }
		public bool CategoryStatus { get; set; }

		public List<Product> Products { get; set; }


	}
}
// field - variable- property farkı????
// bir değişken direk class içinde tanımlanırsa --> field
//bir değişken  class metot içinde get/set ile tanımlanırsaa tanmlanırs-->property
// bir değişken void metot içinde tanımlanırsa -->değişken 
