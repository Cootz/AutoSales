using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSales.Model
{
    
    public class Sale
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public uint Price { get; set; }

        public Car Car { get; set; } = default!;
    }
}