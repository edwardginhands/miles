using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Miles.Interface
{
    public interface ILocation
    {
        int Id { get; set; }
        string Name { get; set; }
    }
}
