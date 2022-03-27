using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    internal class Entity: IComparable<Entity>
    {
        public int Id;

        public int ParentId;

        public string Name;

        public int CompareTo(Entity e)
        {
            if (this.Id < e.Id)
            {
                return -1;
            }
            else if(this.Id > e.Id)
            {
                return 1;
            }

            return 0;

        }

        static public Dictionary<int, List<Entity>> Sort(List<Entity> ListEntity)
        {
            Dictionary<int, List<Entity>> dictionary = new Dictionary<int, List<Entity>>();

            var query = ListEntity.OrderBy(Id => Id).Select(item => item);

            int previousParentId = 0;
            foreach (var item in query)
            {
                //if (item.ParentId != previousParentId)
                //{
                //    dictionary.Add(item.ParentId, new List<Entity>);
                //}
                Console.WriteLine($"{ item.ParentId}{ item.Id}");
            }

            return dictionary;
        }
    }
}
