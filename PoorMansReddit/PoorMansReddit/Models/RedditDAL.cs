using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PoorMansReddit.Models
{
    public class RedditDAL
    {
        public string CallAPI()
        {
            string endpoint = "https://www.reddit.com/r/aww/.json";
            // Extra setup tends to go around here (Additional headers, passwords, endpoint shenanigans)

            // Sending a letter out to someone, hoping for a response
            HttpWebRequest request = WebRequest.CreateHttp(endpoint);

            // Pulls in the response. If it worked, we get a file containing our JSON.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            // Store the JSON as a string into File I/O
            StreamReader rd = new StreamReader(response.GetResponseStream());

            string output = rd.ReadToEnd();
            return output;
        }

        public List<Child> ConvertToChildElements()
        {
            string data = CallAPI();
            Rootobject r = JsonConvert.DeserializeObject<Rootobject>(data);
            Data d = r.data;
            List<Child> childElements = new List<Child>();
            for (int i = 0; i < d.children.Length; i++)
            {
                Child child = d.children[i];
                childElements.Add(child);
            }
            return childElements;
        }
    }
}
