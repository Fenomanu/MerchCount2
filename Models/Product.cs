using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchCount2.Models
{
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public int SagaID { get; set; }
        [Ignore]
        public Saga Saga { get; set; }
        public int GroupID {  get; set; }
        [Ignore]
        public Group Group { get; set; }

        [Ignore]
        public string ImageName 
        { get 
            {
                return string.Format("{0}/{1}.png",SagaID,ID);
            }
        }
        public string Notes { get; set; }
        [Ignore]
        public string FullImagePath
        {
            get
            {
                return Path.Combine(Constants.ImagesPath, ImageName);
            }
        }

        public Product(int iD, string name, int sagaID, Saga saga, int groupID, Group group, string notes)
        {
            ID = iD;
            Name = name;
            SagaID = sagaID;
            Saga = saga;
            GroupID = groupID;
            Group = group;
            Notes = notes;
        }

        public Product(int iD, string name)
        {
            ID = iD;
            Name = name;
            SagaID = 0;
            Saga = new Saga { ID = SagaID, Name = "Saga N" };
            GroupID = 0;
            Group = new Group { ID = 0, Name = Name };
            Notes = "";
        }
        public Product(string name, int sagaID, int groupID, string notes)
        {
            Name = name;
            SagaID = sagaID;
            GroupID = groupID;
            Notes = notes;
        }
        public Product(string name, int sagaID, Saga saga, int groupID, Group group, string notes)
        {
            Name = name;
            SagaID = sagaID;
            Saga = saga;
            GroupID = groupID;
            Group = group;
            Notes = notes;
        }
        public Product() { }
    }
}
