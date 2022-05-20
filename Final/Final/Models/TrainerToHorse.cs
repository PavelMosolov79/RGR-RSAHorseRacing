using System;
using System.Collections.Generic;

namespace Final
{
    public partial class TrainerToHorse
    {
        public long? HorseId { get; set; }
        public long? TrainerId { get; set; }

        public virtual Horse? Horse { get; set; }
        public virtual Trainer? Trainer { get; set; }
    }
}
