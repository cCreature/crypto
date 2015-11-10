using System;
using System.IO;
using System.Linq;

namespace Zad1
{
    internal class FileReader
    {
        private readonly string _path;

        public FileReader(string path)
        {
            _path = path;
        }

        public string[] ReadFile()
        {
            var text = File.ReadAllText(_path);
            var cells = text.Split((char[]) null, StringSplitOptions.RemoveEmptyEntries);


  
            return cells;
        }

      
    }
}
