using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;
using PriceL;
using StorageDLL;

namespace SerializeDLL
{
    public interface ISerialize { 
        void Save(PriceList list);
        PriceList Load();
    }

    public class MyXMLSerializer : ISerialize
    {
        public MyXMLSerializer()
        {
        }
        public PriceList Load()
        {
            FileStream stream = new FileStream("listXML.xml", FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Storage>));
            List<Storage> list = (List<Storage>)serializer.Deserialize(stream);
            stream.Close();
            PriceList list2 = new PriceList(list);
            return list2;
        }
        public void Save(PriceList list)
        {
            FileStream stream = new FileStream("listXML.xml", FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Storage>));
            serializer.Serialize(stream, list.list);
            stream.Close();
        }
    }

    public class MyJSONSerializer : ISerialize
    {
        public PriceList Load()
        {
            FileStream stream = new FileStream("listJSON.json", FileMode.Open);
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Storage>));
            List<Storage> list = (List<Storage>)jsonFormatter.ReadObject(stream);
            PriceList list2 = new PriceList(list);
            stream.Close();
            return list2;
        }

        public void Save(PriceList list)
        {
            FileStream stream = new FileStream("listJSON.json", FileMode.Create);
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Storage>));
            jsonFormatter.WriteObject(stream, list.list);
            stream.Close();
        }
    }
}
