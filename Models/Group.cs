
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
        public bool IsAdminOnly {  get; set; }

        public Group(int iD, string name, string imageName, float price, string notes, bool isAdminOnly)
        {
            ID = iD;
            Name = name;
            ImageName = imageName;
            Price = price;
            Notes = notes;
            IsAdminOnly = isAdminOnly;
        }
        public Group(string name, string imageName, float price, string notes, bool isAdminOnly)
        {
            Name = name;
            ImageName = imageName;
            Price = price;
            Notes = notes;
            IsAdminOnly = isAdminOnly;
        }
        public Group()
        {
            Name = "";
            ImageName = "";
            Price = 0;
            Notes = "";
            IsAdminOnly = false;
        }

        public Image Image
        {
            get
            {
                Image img = new Image();
                if (IsAdminOnly)
                {
                    img.Source = Path.Combine();
                }
                else
                {
                    img.Source = Path.Combine();
                }

                return img;
            }
        }
    }
}
