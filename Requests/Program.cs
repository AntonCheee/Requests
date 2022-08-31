using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;

namespace Requests
{
    class Program
    {
        private static string UserPath = "/public/v2/users";

        static async Task Main()
        {
            static RestRequest Post(string name, string email, string gender, string status)
            {
                RestRequest request = new RestRequest(UserPath);
                request.AddBody(new User(name, email, gender, status));
                request.Method = Method.Post;
                return request;
            }

            RestClient client = new RestClient("https://gorest.co.in");
            client.Authenticator = new JwtAuthenticator("91eaea3df3cd144d3fde2f87a1b16f108785c5565c891da9671f42c3f8d5d120");
            var response = await client.PostAsync(Post("Popa", "popa@popa.com", "female", "active"));
            Console.WriteLine(response.Content);
        }       
    }

    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Status { get; set; }

        public User(string name, string email, string gender, string status)
        {
            Name = name;
            Email = email;
            Gender = gender;
            Status = status;
        }
    }
}
