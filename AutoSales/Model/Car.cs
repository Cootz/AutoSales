using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSales.Model
{
    public class Car
    {
        public int Id { get; set; }

        public string Model { get; set; } = default!;
        public string Brand { get; set; } = default!;

        // Aditional car info
    }
}
