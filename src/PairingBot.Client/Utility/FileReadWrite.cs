﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairingBot.Client.Utility
{
    public class FileReadWrite : IFileReadWrite
    {
        private const string fileLocation = ".\\LastPair.txt";
        public string ReadFile()
        {
            StreamReader sr = new StreamReader(fileLocation);
            var line = sr.ReadLine();
            Console.WriteLine(line);
            return line;
        }

        public string WriteToFile()
        {
            throw new NotImplementedException();
        }
    }
}
