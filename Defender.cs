using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballGameProgram
{
    public class Defender: Player, IDefend
    {
        public const float DefendMultiplier = 1.5F;
        public float DefendPower { get; private set; }
        public Defender(int playerNumber, string name, float powerLevel, Position position, Team team) : base(playerNumber, name, position, team)
        {
            DefendPower = powerLevel * DefendMultiplier;
        }

        public override string[] GetPlayerInfo()
        {
            string[] info = { PlayerNumber.ToString(), Name, DefendPower.ToString(), position.ToString(), team.Name };
            return info;
        }

        public float Defend()
        {
            return DefendPower;
        }

        public bool CallTeamMate()
        {
            return true;
        }
    }
}
