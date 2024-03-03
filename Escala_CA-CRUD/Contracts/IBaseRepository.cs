﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escala_CA_CRUD.Contracts
{
    public enum ErrorCode
    {
        Success,
        Error
    }
    public interface IBaseRepository<T>
    {
        T Get(object id);
        List<T> GetAll();
        ErrorCode Create(T t);
        ErrorCode Update(object id, T t);


    }
}
