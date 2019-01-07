using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watches
{
    public struct MovementType
    {
        public WatchType Type { get; set; }

        public Descriptions Description { get; set; }

        public MovementType(WatchType type, Descriptions description)
        {
            Type = type;
            if (Type == WatchType.Electronic && (int)description > 4 || Type == WatchType.Mechanical && (int)description < 4)
            {
                Description = Descriptions.BalanceWheel;
            }
            else
            {
                Description = description;
            }
        }
    }
}
