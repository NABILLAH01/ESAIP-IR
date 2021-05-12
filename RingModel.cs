using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projetIoT
{
    public class RingModel
    {
        private int id;

        public int Id { get => id; set => id = value; }
        private bool ringing;
        public bool Ringing {get=>ringing; set=>ringing=value;}
        private DateTime startAt ;

        private DateTime endAt  ;
        public DateTime StartAt { get=>startAt; set=> startAt=value; }
        public DateTime EndAt { get=>endAt; set=>endAt=value; }
    }
}
