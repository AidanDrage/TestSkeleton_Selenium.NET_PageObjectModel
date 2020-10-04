using RestSharp;
using System.Diagnostics;

namespace SpecflowTemplate.Helpers
{
    public class APIHelper
    {
        public void InitialiseServer()
        {
            //TODO: Launches a json server (in the default cmd location which is the user profile), but currently I cant return
            //any process info to kill it again, untill then just manually end the node.js process 
            var process = Process.Start("cmd.exe", "/c json-server --watch db.json");
        }

        public void CloseServer()
        {
            foreach (var process in Process.GetProcessesByName("node"))
            {
                process.Kill();
            }
        }

        public RestResponse Get(string uri)
        {
            var client = new RestClient(uri);

            var request = new RestRequest("");

            return (RestResponse)client.Get(request);
        }

        public RestResponse Post(string uri, string body)
        {
            var client = new RestClient(uri);

            var request = new RestRequest("").AddJsonBody(body);

            return (RestResponse)client.Post(request);
        }
    }
}
