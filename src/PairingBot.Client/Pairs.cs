using PairingBot.Client.Utility;
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
            //read last pairs here
            FileReadWrite file = new FileReadWrite();

            var yesterdayPairs = GetLastPairs(file.ReadFile()); //this returns a List<tuple> of canonical pairs
            var todayPairs = new List<Tuple<string, string>>();
            
            var randomPair = _pairs.OrderBy(arg => Guid.NewGuid()).Take(2).ToList();
            todayPairs.Add(Tuple.Create(randomPair[0], randomPair[1]));

            while(yesterdayPairs.Contains(todayPairs[0]))
            {
                todayPairs = new List<Tuple<string, string>>();
                randomPair = _pairs.OrderBy(arg => Guid.NewGuid()).Take(2).ToList();
                
                todayPairs.Add(Tuple.Create(randomPair[0], randomPair[1]));
            }
            //then write the new pair
            file.WriteToFile($"{todayPairs[0].Item1.ToString()},{todayPairs[0].Item2.ToString()}");

            //return the new pair
            return $"Today's pairs are : {todayPairs[0].Item1.ToString()} & {todayPairs[0].Item2.ToString()}";
        }

        private List<Tuple<string, string>> GetLastPairs(string lastPairs)
        {
            var tuplePair = new List<Tuple<string, string>>();
            var lastpair1 = lastPairs.Split(',').ToList();
            List<string> lastpair2 = new List<string>();

            foreach(var x in _pairs)
            {
                if(!lastpair1.Contains(x))
                {
                    lastpair2.Add(x);
                }
            }
            tuplePair.Add(Tuple.Create(lastpair1[0], lastpair1[1]));
            tuplePair.Add(Tuple.Create(lastpair1[1], lastpair1[0]));
            tuplePair.Add(Tuple.Create(lastpair2[0], lastpair2[1]));
            tuplePair.Add(Tuple.Create(lastpair2[1], lastpair2[0]));

            return tuplePair;
        }

    }
}
