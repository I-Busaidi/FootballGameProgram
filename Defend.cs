using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballGameProgram
{
    // Interface used by Goalkeeper, Defenders, and Midfielders.
    public interface IDefend
    {
        public float Defend();
        public bool CallTeamMate();
    }
}
