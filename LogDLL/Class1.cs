using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace LogDLL
{
    public interface ILog
    {
        void Print(string message);
    }

    public class ConsoleLog : ILog
    {
        public void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
    public class FileLog: ILog
    {
        public async void Print(string message)
        {
            using (StreamWriter writer = new StreamWriter("Filelog.txt", false))
            {
                await writer.WriteLineAsync(message);
            }
        }
    }

}
