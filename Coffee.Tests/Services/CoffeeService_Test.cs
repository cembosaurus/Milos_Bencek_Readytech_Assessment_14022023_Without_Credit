using Business.Coffee.DTOs;
using Business.ServiceResult;
using Business.ServiceResult.Interfaces;
using Coffee.Services;
using Coffee.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Moq;
using Newtonsoft.Json;

namespace Coffee.Tests.Services
{

    [TestFixture]
    internal class CoffeeService_Test
    {

        private IConfiguration _config;
        private const string _configKey = "message200";
        private const string _configValue = "Your piping hot coffee is ready";
        private IServiceResultFactory _resultFact;
        private ICoffeeService _coffeeService;


        [SetUp]
        public void Setup()
        {
            _config = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string> { { _configKey, _configValue } })
                .Build();

            _resultFact = new ServiceResultFactory();
            _coffeeService = new CoffeeService(_config, _resultFact);
        }




        [Test]
        public void GetCoffee_WhenCalled_ReturnsServiceResultWithJSONData()
        {
            var serviceResult = _coffeeService.GetCoffee();

            var result = JsonConvert.DeserializeObject<CoffeeReadDTO>(serviceResult.Data);


            Assert.That(result?.Message, Is.EqualTo(_config.GetSection(_configKey).Value));
        }

    }
}
