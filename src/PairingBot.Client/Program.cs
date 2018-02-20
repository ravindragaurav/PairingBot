using System.Collections.Generic;

namespace PairingBot.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            string urlWithAccessToken = "";

            SlackClient client = new SlackClient(urlWithAccessToken);

            List<string> teamMembers = new List<string>();

            teamMembers.Add("Gaurav");
            teamMembers.Add("Aash");
            teamMembers.Add("Doug");
            teamMembers.Add("John");

            var pairs = new Pairs(teamMembers);
            var result = pairs.GetPairs();
            client.PostMessage(username: "Gaurav",
                                text: result,
                                channel: "#cobrapairs");
        }
    }
}
