using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IFilterDataDto
    {
        public string? Category { get; set; }
        public string? Ingredient { get; set; }
        public string? Subcategory { get; set; }
    }
}