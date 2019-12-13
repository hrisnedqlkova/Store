using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.Models
{
	public class Product:BaseModel
	{
		public List<Product> Products;

		public DateTime Date { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }
        public string Description { get; set; }


	}
}
