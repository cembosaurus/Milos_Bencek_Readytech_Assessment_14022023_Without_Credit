using Coffee.Services.Interfaces;
using Business.Coffee.DTOs;
using Business.ServiceResult.Interfaces;
using Newtonsoft.Json;

namespace Coffee.Services
{
    public class CoffeeService : ICoffeeService
    {

        private string _message;
        private readonly IServiceResultFactory _resultFact;

        public CoffeeService(IConfiguration config, IServiceResultFactory resultFact)
        {
            _message = config["message200"].ToString();
            _resultFact = resultFact;
        }



        public IServiceResult<string> GetCoffee()
        {
            var result = _resultFact.Result(JsonConvert.SerializeObject(new CoffeeReadDTO { Message = _message }), true, "");

            return result;
        }

    }
}
