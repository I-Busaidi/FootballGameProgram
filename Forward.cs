using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballGameProgram
{
    public class Forward : Player, IAttack
    {
        private const float AttackMultiplier = 2F;
        private float AttackPower;

        public Forward(int playerNumber, string name, float powerLevel, Position position, Team team) : base(playerNumber, name, powerLevel, position, team)
        {
            AttackPower = powerLevel * AttackMultiplier;
        }

        public override string[] GetPlayerInfo()
        {
            string[] info = { PlayerNumber.ToString(), Name, AttackPower.ToString(), position.ToString(), team.Name };
            return info;
        }

        public float Shoot()
        {
            return AttackPower;
        }

        public (float, bool) Pass()
        {
            bool PassedBall = false;
            Random random = new Random();
            int RolledNumber = random.Next(1, 100);

            // Forward position players have a 30% chance to pass the ball.
            if (RolledNumber >= 70)
            {
                PassedBall = true;
            }
            return (GetPowerLevel(), PassedBall);
        }
    }
}
