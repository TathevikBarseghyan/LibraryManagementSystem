﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Domain.Entities
{
    public class Admin : User 
    {
        public void BlockClient() { }
        public void UnblockClient() { }
    }
}
