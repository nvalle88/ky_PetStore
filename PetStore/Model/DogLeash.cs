﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Model
{
    public class DogLeash : Product
    {

        public int LengthInches { get; set; }
        public string? Material { get; set; }
    }
}
