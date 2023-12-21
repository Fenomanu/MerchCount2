using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchCount2.Models
{
    class TempCart
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        [ForeignKey(nameof(Product.ID))]
        public int ProductId { get; set; }
        public float Price { get; set; }
        public string Notes { get; set; }
        public bool IsAdminOnly { get; set; }

        // Other Properties
        [Ignore]
        public List<TempCartItem> TempCartItems { get; set; }
        
        public TempCart() { }
    }
}
