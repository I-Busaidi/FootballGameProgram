using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballGameProgram
{
    public class GoalKeeper: Player, IDefend
    {
        private const float DefendMultiplier = 2F;
        private float DefendPower;
        public GoalKeeper(int playerNumber, string name, float powerLevel, Position position, Team team) : base(playerNumber, name, powerLevel, position, team)
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
            bool CallSucceeded = false;
            Random random = new Random();
            int RolledNumber = random.Next(1, 100);

            // Goalkeeper has a 70% chance to call a player to help in the defence.
            if (RolledNumber >= 30)
            {
                CallSucceeded = true;
            }

            return CallSucceeded;
        }
    }
}
