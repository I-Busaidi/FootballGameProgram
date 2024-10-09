using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballGameProgram
{
    public class MidFielder : Player, IAttack, IDefend
    {
        public const float AttackMultiplier = 1.5F;
        public const float DefendMultiplier = 0.5F;
        public float AttackPower { get; private set; }
        public float DefendPower { get; private set; }
        public MidFielder(int playerNumber, string name, float powerLevel, Position position, Team team) : base(playerNumber, name, position, team)
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
            return AttackPower;
        }

        public float Pass()
        {
            return AttackPower;
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
