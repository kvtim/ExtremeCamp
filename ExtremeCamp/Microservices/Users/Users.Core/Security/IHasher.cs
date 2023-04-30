﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.Core.Security
{
    public interface IHasher
    {
        string Hash(string input);
        bool Verify(string input, string hashString);
    }
}
