using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairingBot.Client.Utility
{
    public interface IFileReadWrite
    {
        string ReadFile();
        string WriteToFile();
    }
}
