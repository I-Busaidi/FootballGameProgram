using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballGameProgram
{
    // Inheriting Player and implementing IAttack
    public class Forward : Player, IAttack
    {
        private const float AttackMultiplier = 2F;
        private float AttackPower;

        public Forward(int playerNumber, string name, float powerLevel, Position position, Team team) : base(playerNumber, name, powerLevel, position, team)
        {
            // increased attack power that is used when shooting at goal (x2).
            AttackPower = powerLevel * AttackMultiplier;
        }

        public override string[] GetPlayerInfo()
        {
            string[] info = { PlayerNumber.ToString(), Name, AttackPower.ToString(), position.ToString(), team.Name };
            return info;
        }

        public float Shoot()
        {
            // Forward players add their attack modifier to their contributed power level during the attack if they shoot the ball.
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
            // If forward Players pass, they do not add the attack modifier to their contributed attack power.
            return (GetPowerLevel(), PassedBall);
        }
    }
}
