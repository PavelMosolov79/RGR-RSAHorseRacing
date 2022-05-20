using System;
using System.Collections.Generic;

namespace Final
{
    public partial class Result
    {
        public Result()
        {
            Horses = new HashSet<Horse>();
        }

        public long Id { get; set; }
        public long? Runs { get; set; }
        public long? Wins { get; set; }
        public double? Win { get; set; }
        public long? _2nd { get; set; }
        public long? _3nd { get; set; }
        public long? Other { get; set; }
        public long? Places { get; set; }
        public double? Place { get; set; }
        public long? WinStake { get; set; }
        public long? TotalStake { get; set; }
        public long? Year { get; set; }

        public virtual ICollection<Horse> Horses { get; set; }
    }
}
