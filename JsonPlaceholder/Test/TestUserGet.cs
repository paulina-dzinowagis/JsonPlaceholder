using JsonPlaceholder.Model;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;

namespace JsonPlaceholder.Test
{
    [TestFixture]
    public class TestUserGet
    {
        private static string _baseUrl;
        private static JsonDeserializer _deserializer;

        [OneTimeSetUp]
        public void Setup()
        {
            _baseUrl = "https://jsonplaceholder.typicode.com/posts";
            _deserializer = new JsonDeserializer();
        }

        [Test]
        public void CheckIf()
        {
            //Arrange
            RestClient client = new RestClient(_baseUrl);
            IRestRequest request = new RestRequest("/{id}", Method.GET)
            .AddUrlSegment("id", 1);

            //Act
            IRestResponse response = client.Execute(request);
            var output = _deserializer.Deserialize<User>(response);

            //Assert
            Assert.AreEqual(1, output.userId);

        }
    }
}
