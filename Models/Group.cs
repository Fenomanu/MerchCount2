using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchCount2.Models
{
    public class Group
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string ImageName { get; set; }
        public float Price { get; set; }
        public string Notes { get; set; }

        public Group(int iD, string name, string imageName, float price, string notes)
        {
            ID = iD;
            Name = name;
            ImageName = imageName;
            Price = price;
            Notes = notes;
        }
        public Group(string name, string imageName, float price, string notes)
        {

        }
    }
}
