using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballGameProgram
{
    // Inheriting Player and implementing IDefend
    public class Defender: Player, IDefend
    {
        private const float DefendMultiplier = 1.5F;
        private float DefendPower;
        public Defender(int playerNumber, string name, float powerLevel, Position position, Team team) : base(playerNumber, name, powerLevel, position, team)
        {
            // Increased contributed power when defending (x1.5).
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
            bool CallSucceeded = false;
            Random random = new Random();
            int RolledNumber = random.Next(1, 100);

            // Defenders have a 50% chance to call a player to aid in the defence.
            if (RolledNumber >= 50)
            {
                CallSucceeded = true;
            }

            return CallSucceeded;
        }
    }
}
