﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankManager.Interfaces
{
    public interface IRepository<T>
    {
        int Create( T t );
        int Update(T t);
        IEnumerable<T> FindAll();
        T FindById( int id );
    }
}
