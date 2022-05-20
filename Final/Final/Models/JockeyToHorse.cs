using System;
using System.Collections.Generic;

namespace Final
{
    public partial class JockeyToHorse
    {
        public long? HorseId { get; set; }
        public long? JockeyId { get; set; }

        public virtual Horse? Horse { get; set; }
        public virtual Jockey? Jockey { get; set; }
    }
}
