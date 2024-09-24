using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Model
{
    public class CatFood : Product
    {
        public decimal WeightPounds { get; set; }
        public bool KittenFood { get; set; }
    }
}
