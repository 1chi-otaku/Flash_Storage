using StorageDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PriceL
{
    public class PriceList
    {
        public List<Storage> list { get; set; }

        public PriceList()
        {
            list = new List<Storage>();
        }
        public PriceList(List<Storage> list)
        {
            this.list = list;
        }
        public void Add(Storage storage)
        {
            list.Add(storage);
        }
        public void Clear()
        {
            list.Clear();
        }
        public void RemoveByIndex(int index)
        {
            list.RemoveAt(index);
        }
        public int SearchByName(string name)
        {
            for (int i = 0; i < list.Capacity; i++)
            {
                if (list[i].Name == name) return i;
            }
            return -1;
        }
        public bool Print(int index)
        {
            if(index > list.Count || index <= -1) {
                return false;
            }
            else
            {
                Console.WriteLine("#" + index + ":");
                Console.WriteLine(list[index]);
                Console.WriteLine();
                return true; 
            }
        }

        public void PrintAll()
        {
            for (int i = 0; i < list.Count; i++)
            {
                Print(i);
            }
        }

        public override string ToString()
        {
            string storage_string = null;
            for (int i = 0; i < list.Count; i++)
            {
                storage_string += list[i];
                storage_string+= "\n";
            }
            return storage_string;
        }
    }
}
