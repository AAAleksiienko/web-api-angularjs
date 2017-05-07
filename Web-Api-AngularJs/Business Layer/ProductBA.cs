using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Api_AngularJs.Data_Access_Layer;

namespace Web_Api_AngularJs.Business_Layer
{
    public class ProductBA
    {

        public List<ProductDA> findAll()
        {
            using (appstoreEntities db = new appstoreEntities())
            {
                return db.Products.ToList().Select(p => new ProductDA(p)).ToList();
            }
        }

        public ProductDA findProduct(int id)
        {
            try
            {
                return findAll().Single(p => p.Id.Equals(id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e); // временно, для обработки ошибки, если в базе нет по id ничего
                return new ProductDA { };
            }
        }

        public void deleteProduct(int id)
        {
            using (appstoreEntities db = new appstoreEntities())
            {
                Product product = db.Products.Find(id);
                if (product != null)
                {
                    db.Products.Remove(product);
                    db.SaveChanges();
                }
            }
        }

        public ProductDA changeProduct(string id, ProductDA product)
        {
            using (appstoreEntities db = new appstoreEntities())
            {
                if (id == product.Id.ToString())
                {
                    var result = db.Products.SingleOrDefault(p => p.Id == product.Id);
                    if (result != null)
                    {
                        var rec = ProductDA.Update(result, product);
                        db.SaveChanges();
                        return new ProductDA(rec);
                    }
                }
                return new ProductDA { };
            }
        }

        public ProductDA addProduct(ProductDA pd)
        {
            using (appstoreEntities db = new appstoreEntities())
            {
                var rec = ProductDA.Convert(pd);
                db.Products.Add(rec);
                db.SaveChanges();
                return new ProductDA(rec);
            }
        }

    }
}