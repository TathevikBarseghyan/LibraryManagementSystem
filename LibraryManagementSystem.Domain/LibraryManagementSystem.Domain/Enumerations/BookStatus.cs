﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Domain.Enumerations
{
    public enum BookStatus
    {
        Available,
        Reserved,
        Loaned,
        Lost,
        Sold
    }
}
