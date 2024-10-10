using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballGameProgram
{
    // Interface used by Forward and Midfield players.
    public interface IAttack
    {
        public float Shoot();
        public (float, bool) Pass();
    }
}
