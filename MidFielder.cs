using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballGameProgram
{
    public class MidFielder : Player, IAttack, IDefend
    {
        private const float AttackMultiplier = 1.5F;
        private const float DefendMultiplier = 0.5F;
        private float AttackPower;
        private float DefendPower;
        public MidFielder(int playerNumber, string name, float powerLevel, Position position, Team team) : base(playerNumber, name, powerLevel, position, team)
        {
            AttackPower = powerLevel*AttackMultiplier;
            DefendPower = powerLevel*DefendMultiplier;
        }

        public override string[] GetPlayerInfo()
        {
            string[] info = { PlayerNumber.ToString(), Name, AttackPower.ToString(), DefendPower.ToString(), position.ToString(), team.Name };
            return info;
        }

        public float Shoot()
        {
            return GetPowerLevel();
        }

        public (float, bool) Pass()
        {
            bool PassedBall = false;
            Random random = new Random();
            int RolledNumber = random.Next(1, 100);

            // Midfielders have a 70% chance to pass the ball.
            if (RolledNumber >= 30)
            {
                PassedBall = true;
            }
            return (AttackPower, PassedBall);
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

            // Midfielders have a 30% chance to call another player to help in the defence.
            if (RolledNumber >= 70)
            {
                CallSucceeded = true;
            }

            return CallSucceeded;
        }
    }
}
