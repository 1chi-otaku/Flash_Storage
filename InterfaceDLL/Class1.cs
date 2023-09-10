using LogDLL;
using PriceL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDLL
{
    public class FlashInterface
    {
        PriceList drivesList = new PriceList();
        ILog log;
        ISerializable serializable;
       
        var num = int.Parse(Console.ReadLine());
        public static void PrintAddStorageMenu() {
            Console.WriteLine("------Choose type of storage------");
            Console.WriteLine("1 - Flash drive");
            Console.WriteLine("2 - DVD");
            Console.WriteLine("3 - HDD");
            Console.WriteLine("0 - Return");
        }
    }
}
