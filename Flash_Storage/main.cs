using LogDLL;
using PriceL;
using SerializeDLL;
using StorageDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Flash_Storage
{
    internal class Interface
    {
        public static void PrintMainMenu()
        {
            Console.Clear();
            Console.WriteLine("------Storage Drives------");
            Console.WriteLine("1 - Add a storage");
            Console.WriteLine("2 - Delete a storage");
            Console.WriteLine("3 - Print storage list");
            Console.WriteLine("4 - Search a storage");
            Console.WriteLine("5 - Save");
            Console.WriteLine("6 - Load");
            Console.WriteLine("7 - Clear storage list");
            Console.WriteLine("8 - Show Log");
            Console.WriteLine("0 - Exit");
        }
        public static void PrintStorageSelection()
        {
            Console.Clear();
            Console.WriteLine("------\")Select storage to create------");
            Console.WriteLine("1 - Flash");
            Console.WriteLine("2 - DVD");
            Console.WriteLine("3 - HDD");
            Console.WriteLine("0 - Return");
        }
        public static void PrintSerializationOptions()
        {
            Console.Clear();
            Console.WriteLine("------\")Select serialization type------");
            Console.WriteLine("1 - XML");
            Console.WriteLine("2 - JSON");
            Console.WriteLine("0 - Return");
        }

        public static void PrintShowLogMenu()
        {
            Console.Clear();
            Console.WriteLine("------\")Select log type------");
            Console.WriteLine("1 - Console");
            Console.WriteLine("2 - File");
            Console.WriteLine("0 - Return");
        }
        static void Main(string[] args)
        {
            int choice = -1;
            int choice2 = -1;
            PriceList drivesList = new PriceList();
            ILog log;
            ISerialize ser;
            while (choice != 0)
            {
                PrintMainMenu();
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        return;
                    case 1:
                        PrintStorageSelection();
                        Storage storage = null;
                        choice2 = int.Parse(Console.ReadLine());
                        if (choice2 == 1)
                            storage = new Flash();
                        else if (choice2 == 2)
                            storage = new DVD();
                        else if (choice2 == 3)
                            storage = new HDD();
                        else return;
                        Console.Clear();
                        storage.Init();
                        drivesList.Add(storage);
                        break;
                    case 2:
                        Console.Clear();
                        drivesList.PrintAll();
                        Console.WriteLine("Enter index to delete: ");
                        drivesList.RemoveByIndex(int.Parse(Console.ReadLine()));
                        break;
                    case 3:
                        Console.Clear();
                        drivesList.PrintAll();
                        Console.ReadLine();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Enter name of device to search:");
                        int index = drivesList.SearchByName(Console.ReadLine());
                        if(index != -1)
                            drivesList.Print(index);
                        else
                            Console.WriteLine("Not found.");
                        Console.ReadLine();
                        break;
                    case 5:
                        PrintSerializationOptions();
                        int input = Convert.ToInt32(Console.ReadLine());
                        switch (input)
                        {
                            case 1:
                                ser = new MyXMLSerializer();
                                break;
                            case 2:
                                ser = new MyJSONSerializer();
                                break;
                            default:
                                return;
                        }
                        ser.Save(drivesList);
                        break;
                    case 6:
                        PrintSerializationOptions();
                        int input2 = Convert.ToInt32(Console.ReadLine());
                        switch (input2)
                        {
                            case 1:
                                ser = new MyXMLSerializer();
                                break;
                            case 2:
                                ser = new MyJSONSerializer();
                                break;
                            default:
                                return;
                        }
                        drivesList = ser.Load();
                        break;
                    case 7:
                        drivesList.Clear();
                        break;
                    case 8:
                        PrintShowLogMenu();
                        int loginput = Convert.ToInt32(Console.ReadLine());
                        if(loginput == 1)
                            log = new ConsoleLog();
                        else
                            log = new FileLog();
                        Console.Clear();
                        log.Print(drivesList.ToString());
                        Console.ReadLine();
                        break;

                    default:
                        break;
                }
            }

        }
    }
}
