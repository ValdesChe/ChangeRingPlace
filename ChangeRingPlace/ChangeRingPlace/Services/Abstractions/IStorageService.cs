﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChangeRingPlace.Services.Abstractions
{
    public interface IStorageService
    {
        Task<T> GetAsync<T>(string key, T defaultValue = default(T));
        Task SaveAsync<T>(string key, T obj);
        Task RemoveAsync(string key);
    }
}
