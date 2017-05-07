using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Api_AngularJs.Data_Access_Layer
{
    public class ProductDA
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        public ProductDA() { }

        public ProductDA(Product pd)
        {
            Id = pd.Id;
            Name = pd.Name;
            Price = pd.Price;
            Quantity = pd.Quantity;
        }

        public static Product Convert(ProductDA pd)
        {

            return Update(new Product(), pd);
        }

        public static Product Update(Product pd, ProductDA pdDTO)
        {
            pd.Id = pdDTO.Id.GetValueOrDefault();
            pd.Name = pdDTO.Name;
            pd.Price = pdDTO.Price;
            pd.Quantity = pdDTO.Quantity;
            return pd;
        }
    }
}