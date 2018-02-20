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

            var lastPairs = GetLastPairs(file.ReadFile());


            //if the new random pair tuple is in the in previous tuple, then random again 
            var random = _pairs.OrderBy(arg => Guid.NewGuid()).Take(2).ToList();

            var random2 = _pairs.Except(random).ToList();




            //find canonical pairs
            //doug & aash is the same as john & gaurav
            var tuplePair = new List<Tuple<string, string>>();
            tuplePair.Add(Tuple.Create(random[0], random[1]));
            tuplePair.Add(Tuple.Create(random2[0], random2[1]));

            //then randomise pairs until you've found a unique pair
            //then write the new pair
            //return the new pair


            return $"Today's pairs are : {random[0]} & {random[1]}";
        }

        private List<Tuple<string, string>> GetLastPairs(string lastPairs)
        {
            var tuplePair = new List<Tuple<string, string>>();

            var lastpair1 = lastPairs.Split(',').ToList();

            List<string> lastpair2 = new List<string>();
            //how will you manage the order of elements. D & G is the same as J & A, which is the same as G & D


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
