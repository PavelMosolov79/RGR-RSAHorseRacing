using System;
using System.Collections.Generic;

namespace Final
{
    public partial class Horse
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public long ResultId { get; set; }

        public virtual Result Result { get; set; } = null!;
    }
}
