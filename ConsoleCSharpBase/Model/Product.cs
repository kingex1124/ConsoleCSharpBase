using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCSharpBase
{
    public class Product
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        public int ProductID { get; set; }
        /// <summary>
        /// 產品名稱
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 敘述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 批號
        /// </summary>
        public string MarkNo { get; set; }
        /// <summary>
        /// 棧板號
        /// </summary>
        public string PalletNo { get; set; }
        /// <summary>
        /// 箱號
        /// </summary>
        public string BoxNo { get; set; }
        /// <summary>
        /// 物流中心
        /// </summary>
        public string DC { get; set; }
        /// <summary>
        /// 業主
        /// </summary>
        public int Gup { get; set; } 
        /// <summary>
        /// 貨主
        /// </summary>
        public string Cus { get; set; }
    }
}
