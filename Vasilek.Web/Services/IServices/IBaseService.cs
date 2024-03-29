﻿using Vasilek.Web.Models;

namespace Vasilek.Web.Services.IServices
{
    public interface IBaseService:IDisposable
    {
        ResponseDtoBase responseModel { get; set; }
        Task <T> SendAsync<T>(ApiRequest apiRequest);
    }
}
