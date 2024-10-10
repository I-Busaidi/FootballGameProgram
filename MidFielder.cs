using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballGameProgram
{
    // Inheriting Player and implementing IAttack + IDefend
    public class MidFielder : Player, IAttack, IDefend
    {
        private const float AttackMultiplier = 1.5F;
        private const float DefendMultiplier = 0.5F;
        private float AttackPower;
        private float DefendPower;
        public MidFielder(int playerNumber, string name, float powerLevel, Position position, Team team) : base(playerNumber, name, powerLevel, position, team)
        {
            // Increased attack power contribution when passing (x1.5).
            AttackPower = powerLevel*AttackMultiplier;
            // Decreased defence power contribution when defending (x0.5).
            DefendPower = powerLevel*DefendMultiplier;
        }

        public override string[] GetPlayerInfo()
        {
            string[] info = { PlayerNumber.ToString(), Name, AttackPower.ToString(), DefendPower.ToString(), position.ToString(), team.Name };
            return info;
        }

        public float Shoot()
        {
            // Midfielders do not add their modifier to attack power if the shoot instead of passing.
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
            // When midfielders pass, they add extra power to the contributed attack power.
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
