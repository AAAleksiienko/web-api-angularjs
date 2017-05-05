using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using web_api_components.DTO;


namespace web_api_components.Models
{
    public class ProductBALayer
    {
        public List<ProductDTO> findAll()
        {
            using (appstoreEntities1 db = new appstoreEntities1())
            {
                return db.Products.ToList().Select(p => new ProductDTO(p)).ToList();
            }
        }

        public ProductDTO findProduct(int id)
        {
            try
            {
                return findAll().Single(p => p.Id.Equals(id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e); // временно, для обработки ошибки, если в базе нет по id ничего
                return new ProductDTO { };
            }
        }

        public void deleteProduct(int id)
        {
            using (appstoreEntities1 db = new appstoreEntities1())
            {
                Products product = db.Products.Find(id);
                if (product != null)
                {
                    db.Products.Remove(product);
                    db.SaveChanges();
                }
            }
        }

        public ProductDTO changeProduct(string id, ProductDTO product)
        {
            using (appstoreEntities1 db = new appstoreEntities1())
            {
                if (id == product.Id.ToString())
                {
                    var result = db.Products.SingleOrDefault(p => p.Id == product.Id);
                    if (result != null)
                    {
                        var rec = ProductDTO.Update(result, product);
                        db.SaveChanges();
                        return new ProductDTO(rec);
                    }
                }
                return new ProductDTO { };
            }
        }

        public ProductDTO addProduct(ProductDTO pd)
        {
            using (appstoreEntities1 db = new appstoreEntities1())
            {
                var rec = ProductDTO.Convert(pd);
                db.Products.Add(rec);
                db.SaveChanges();
                return new ProductDTO(rec);
            }
        }
    }
}