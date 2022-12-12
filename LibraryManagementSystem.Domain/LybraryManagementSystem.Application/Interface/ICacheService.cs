using LybraryManagementSystem.Application.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LybraryManagementSystem.Application.Interface
{
    public  interface ICacheService
    {
        T GetData<T>(string key);
        T SetData<T>(string key, T model);
    }
}
