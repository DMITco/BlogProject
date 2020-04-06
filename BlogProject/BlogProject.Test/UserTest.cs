using BlogProject.API;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Moq;
using Moq.Protected;
using RichardSzalay.MockHttp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using BlogProject.DataLayer.Entities.User;
using Newtonsoft.Json;
using BlogProject.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace BlogProject.Test
{
    public class UserTest
    {
        //ForOrginalCode
        //private readonly TestServer _server;
        //private readonly HttpClient _client;




        private readonly HttpClient client;
        // private readonly MockHttpMessageHandler mockclient;

        public UserTest()
        {
            //ForOrginalCode
            Mock<TestServer> server = new Mock<TestServer>(new WebHostBuilder().UseStartup<Startup>());

            client = server.Object.CreateClient();

            //  mockclient = new MockHttpMessageHandler();
            // client = mockclient.ToHttpClient();
        }

        //[Fact]
        //public async Task GetAllUserTest()
        //{
        //    mockclient.When("https://localhost:5001/api/users/")
        //            .Respond(HttpStatusCode.OK); // Respond with JSON

        //    // Inject the handler or client into your application code
        //    var response = await client.GetAsync("https://localhost:5001/api/users/");
        //    Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        //    ////Orginal Code
        //    //var request = new HttpRequestMessage(new HttpMethod("Get"), "/Api/Users");
        //    //var response =await _client.SendAsync(request);
        //    // Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        //}


        //[Fact]
        //public async Task GetUserTest()
        //{
        //    mockclient.When("https://localhost:5001/api/users/100")
        //            .Respond(HttpStatusCode.OK); // Respond with JSON

        //    // Inject the handler or client into your application code
        //    var response = await client.GetAsync("https://localhost:5001/api/users/100");
        //    Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        //    ////Orginal Code
        //    //var request = new HttpRequestMessage(new HttpMethod("Get"), "/Api/Users");
        //    //var response =await _client.SendAsync(request);
        //    // Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        //}

        [Fact]
        public async Task PostUserTest()
        {
            // User User = new User()
            //;

            // string json = JsonConvert.SerializeObject(User);
            // mockclient.When("https://localhost:5001/api/users")
            //         .Respond("application/json", json); // Respond with JSON

            // // Inject the handler or client into your application code
            // HttpContent Content = new StringContent(json, Encoding.UTF8, "application/json");
            // var response = await client.PostAsync("https://localhost:5001/api/users", Content);
            // var jsonresponse = await response.Content.ReadAsStringAsync();



            // Assert.Equal(JsonConvert.DeserializeObject(jsonresponse), JsonConvert.DeserializeObject(json));
            // Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            ////Orginal Code
            Mock<HttpRequestMessage> request = new Mock<HttpRequestMessage>(new HttpMethod("Post"), "/Api/Users");
            // var request = new HttpRequestMessage(new HttpMethod("Post"), "/Api/Users");


            //"{\"name\":\"John Doe\",\"age\":33}"
            request.Object.Content = new StringContent("{\"userName\": \"Javadoio\",\"name\": \"JAhanbin\",\"family\": \"jAHANVIB\",\"email\": \"Javado@JIJI.COM\",\"password\": \"123456789\",\"activeCode\": \"123456789\",\"isActice\": true,\"userAvatar\": \"123456789YTRE\",\"registerDate\": \"0001-01-01T00:00:00\"}", Encoding.UTF8, "application/json");


            AuthenticationHeaderValue authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJyb2xlIjoiMSIsIm5iZiI6MTU4NjA3MDA3OSwiZXhwIjoxNTg2MTEzMjc5LCJpYXQiOjE1ODYwNzAwNzl9.zA8v1Nw5vtWOTiswGszatgPuXbnw4EaJv1TBqJeD3Y8");
            request.Object.Headers.Authorization = authorization;


            var response = await client.SendAsync(request.Object);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }
    }
}
