using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballGameProgram
{
    public class Forward : Player, IAttack
    {
        public const float AttackMultiplier = 2F;
        public float AttackPower { get; private set; }


        public Forward(int playerNumber, string name, float powerLevel, Position position, Team team) : base(playerNumber, name, position, team)
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

        public float Pass()
        {
            return AttackPower;
        }
    }
}
