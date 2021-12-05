using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveKiosk.Model
{
    class AdjustmentAttId
    {
        gr691_fnvEntities entities = new gr691_fnvEntities();
        public int Min()
        {
            return (from i in entities.Attraction select i.ID).Min();
        }
        public int Max()
        {
            return (from i in entities.Attraction select i.ID).Max();
        }
        public int Increment(int id)
        {
            return ++id;
        }
        public int Decrement(int id)
        {
            return --id;
        }

    }
}
