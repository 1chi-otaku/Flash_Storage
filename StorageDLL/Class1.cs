using LogDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StorageDLL
{
    
    [KnownType(typeof(Flash))]
    [KnownType(typeof(DVD))]
    [KnownType(typeof(HDD))]
    [XmlInclude(typeof(Flash))]
    [XmlInclude(typeof(DVD))]
    [XmlInclude(typeof(HDD))]

    [DataContract]
    [Serializable]
    public abstract class Storage
    {

        [DataMember]
        public string Developer { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public double Capacity { get; set; }


        public Storage(string dev, string name, double cap)
        {
            Developer = dev;
            Name = name;
            Capacity = cap;
        }
        public Storage()
        {

        }
        virtual public void Init()
        {
            try
            {
                Console.WriteLine("Enter Developer: ");
                Developer = Console.ReadLine();
                Console.WriteLine("Enter Name: ");
                Name = Console.ReadLine();
                Console.WriteLine("Enter Capacity:");
                Capacity = double.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
        virtual public void Print(ILog log)
        {
            log.Print(this.ToString());
        }
        public override string ToString()
        {
            return "Developer - " + Developer + "\nName - " + Name + "\nCapacity - " + Capacity;
        }

    }
    [DataContract]
    [Serializable]
    public class Flash : Storage
    {
        [DataMember]
        public double USBSpeed { get; set; }
        public Flash(double usbSpeed, string dev, string name, double cap)
            : base(dev, name, cap)
        {
            USBSpeed = usbSpeed;
        }
        public Flash() { }
        public override void Init()
        {
            base.Init();
            Console.WriteLine("Enter USB speed:");
            USBSpeed = double.Parse(Console.ReadLine());
        }
        public override string ToString()
        {
            return base.ToString() + "\nUSB Speed - " + USBSpeed;
        }
        public override void Print(ILog log)
        {
            log.Print(ToString());
        }
    }
    [DataContract]
    [Serializable]
    public class DVD : Storage
    {
        [DataMember]
        public double WriteSpeed { get; set; }

        public DVD() { }
        public DVD(double writeSpeed, string dev, string name, double cap)
           : base(dev, name, cap)
        {
           WriteSpeed= writeSpeed;
        }
        public override void Init()
        {
            base.Init();
            Console.WriteLine("Enter Write Speed:");
            WriteSpeed = double.Parse(Console.ReadLine());
        }
        public override string ToString()
        {
            return base.ToString() + "\nWrite Speed - " + WriteSpeed;
        }
        public override void Print(ILog log)
        {
            log.Print(ToString());
        }

    }

    [DataContract]
    [Serializable]
    public class HDD : Storage
    {
        [DataMember]
        public double SpindleSpeed { get; set; }

        public override void Init()
        {
            base.Init();
            Console.WriteLine("Enter Spindle Speed:");
            SpindleSpeed = double.Parse(Console.ReadLine());
        }
        public HDD(double spindleSpeed, string dev, string name, double cap)
           : base(dev, name, cap)
        {
            SpindleSpeed = spindleSpeed;
        }
        public HDD() { }
        public override string ToString()
        {
            return base.ToString() + "\nSpindle Speed - " + SpindleSpeed;
        }
        public override void Print(ILog log)
        {
            log.Print(ToString());
        }
    }
}
