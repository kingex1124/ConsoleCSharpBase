using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCSharpBase
{
    public class LinQGroupBy
    {
        public List<Product> _product = new List<Product>();

        public LinQGroupBy()
        {
            _product.Add(new Product() { ProductID = 0, ProductName = "手機", Description = "攜帶型移動裝置", DC = "601", Gup = 601, Cus = "61001", BoxNo = "0", MarkNo = "0", PalletNo = "0" });
            _product.Add(new Product() { ProductID = 1, ProductName = "手機1", Description = "攜帶型移動裝置", DC = "601", Gup = 601, Cus = "61001", BoxNo = "0", MarkNo = "0", PalletNo = "0" });
            _product.Add(new Product() { ProductID = 2, ProductName = "手機2", Description = "攜帶型移動裝置", DC = "601", Gup = 601, Cus = "61001", BoxNo = "1", MarkNo = "0", PalletNo = "0" });
            _product.Add(new Product() { ProductID = 3, ProductName = "手機3", Description = "攜帶型移動裝置", DC = "601", Gup = 601, Cus = "61001", BoxNo = "1", MarkNo = "0", PalletNo = "0" });
            _product.Add(new Product() { ProductID = 4, ProductName = "手機4", Description = "攜帶型移動裝置", DC = "601", Gup = 602, Cus = "61001", BoxNo = "2", MarkNo = "0", PalletNo = "0" });
            _product.Add(new Product() { ProductID = 5, ProductName = "手機5", Description = "攜帶型移動裝置", DC = "601", Gup = 602, Cus = "61001", BoxNo = "2", MarkNo = "0", PalletNo = "0" });
            _product.Add(new Product() { ProductID = 6, ProductName = "手機6", Description = "攜帶型移動裝置", DC = "601", Gup = 602, Cus = "61001", BoxNo = "3", MarkNo = "0", PalletNo = "0" });
            _product.Add(new Product() { ProductID = 7, ProductName = "手機7", Description = "攜帶型移動裝置", DC = "601", Gup = 602, Cus = "61001", BoxNo = "3", MarkNo = "0", PalletNo = "0" });
            _product.Add(new Product() { ProductID = 8, ProductName = "手機8", Description = "攜帶型移動裝置", DC = "601", Gup = 603, Cus = "61001", BoxNo = "1", MarkNo = "0", PalletNo = "0" });
            _product.Add(new Product() { ProductID = 9, ProductName = "手機9", Description = "攜帶型移動裝置", DC = "601", Gup = 603, Cus = "61001", BoxNo = "1", MarkNo = "0", PalletNo = "0" });
            _product.Add(new Product() { ProductID = 10, ProductName = "手機10", Description = "攜帶型移動裝置", DC = "601", Gup = 603, Cus = "61001", BoxNo = "0", MarkNo = "0", PalletNo = "0" });
            _product.Add(new Product() { ProductID = 11, ProductName = "手機11", Description = "攜帶型移動裝置", DC = "601", Gup = 603, Cus = "61001", BoxNo = "0", MarkNo = "0", PalletNo = "0" });
        }

        public void GetGroupGup()
        {
            var result = _product.GroupBy(o => new { o.Gup, o.BoxNo });
            var sum = result.Sum(o => o.Key.Gup);
            foreach (var item in result)
            {
                Console.WriteLine(string.Format("Key:{0},{1}", item.Key.Gup, item.Key.BoxNo));
                foreach (var proudct in item)
                    Console.WriteLine(string.Format("ProductID:{0} ProductName:{1} Gup:{2} BoxNo:{3}", proudct.ProductID, proudct.ProductName, proudct.Gup, proudct.BoxNo));
            }
        }
    }
}
