using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AutoSales.Model
{
    public class SalesOverviewRow
    {
        public string Model { get; init; } = default!;

        public long January { get; init; }
        public long February { get; init; }
        public long March { get; init; }
        public long April { get; init; }
        public long May { get; init; }
        public long June { get; init; }
        public long July { get; init; }
        public long August { get; init; }  
        public long September { get; init; }
        public long October { get; init; }
        public long November { get; init; }
        public long December { get; init; }
    }
}
