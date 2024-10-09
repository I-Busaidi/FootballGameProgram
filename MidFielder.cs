using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballGameProgram
{
    public class MidFielder : Player, IAttack
    {
        public MidFielder(int playerNumber, string name, int powerLevel, Position position, Team team) : base(playerNumber, name, powerLevel, position, team)
        {

        }

        public override string GetPlayerInfo()
        {
            StringBuilder sb = new StringBuilder();
            return sb.ToString();
        }

        
    }
}
