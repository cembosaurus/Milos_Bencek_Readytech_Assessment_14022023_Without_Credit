﻿using Business.ServiceResult.Interfaces;

namespace Coffee.Services.Interfaces
{
    public interface ICoffeeService
    {
        IServiceResult<string> GetCoffee();
    }
}
