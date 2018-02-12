using System;
using System.Collections.Generic;
using System.Linq;

namespace PairingBot.Client
{
    public class Pairs
    {
        readonly List<string> _pairs;

        public Pairs(List<string> pairs)
        {
            _pairs = pairs;
        }

        public string GetPairs()
        {
            var random = _pairs.OrderBy(arg => Guid.NewGuid()).Take(2).ToList(); //you can randomise lists by using Guids!!
            
            return $"Today's pairs are : {random[0]} & {random[1]}";
        }
    }
}
