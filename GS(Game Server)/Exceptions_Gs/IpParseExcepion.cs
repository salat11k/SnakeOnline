using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS_Game_Server_.Exceptions_GS
{
    public class IpParseExcepion: Exception
    {
        public IpParseExcepion(string message) : base(message) { }
    }
}
