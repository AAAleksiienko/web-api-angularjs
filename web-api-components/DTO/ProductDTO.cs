using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_api_components.DTO
{
    public class ProductDTO
    {
        public int ?Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        public ProductDTO() { }

        public ProductDTO(Products pd)
        {
            Id = pd.Id;
            Name = pd.Name;
            Price = pd.Price;
            Quantity = pd.Quantity;
        }

        public static Products Convert(ProductDTO pd)
        {

            return Update(new Products(), pd);
        }

        public static Products Update(Products pd, ProductDTO pdDTO)
        {
            pd.Id = pdDTO.Id.GetValueOrDefault();
            pd.Name = pdDTO.Name;
            pd.Price = pdDTO.Price;
            pd.Quantity = pdDTO.Quantity;
            return pd;
        }
    }
}