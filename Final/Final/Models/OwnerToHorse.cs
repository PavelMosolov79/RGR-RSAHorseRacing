using System;
using System.Collections.Generic;

namespace Final
{
    public partial class OwnerToHorse
    {
        public long? HorseId { get; set; }
        public long? OwnerId { get; set; }

        public virtual Horse? Horse { get; set; }
        public virtual Owner? Owner { get; set; }
    }
}
