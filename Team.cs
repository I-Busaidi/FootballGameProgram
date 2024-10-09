using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballGameProgram
{
    public class Team
    {
        public string Name { get; set; }
        public int Goals { get; set; }
        public int TotalPower { get; set; }
        public int AttackPower { get; set; }
        public int DefencePower { get; set; }
        public bool HasAdvantage { get; set; }

        public List<Forward> ForwardPlayers { get; set; }
        public List<MidFielder> MidPlayers { get; set; }
        public List<Defender> Defenders { get; set; }
        public GoalKeeper GoalKeeper { get; set; }

        public Team(string Name)
        {
            this.Name = Name;
            Goals = 0;
            TotalPower = 0;
            AttackPower = 0;
            DefencePower = 0;
            HasAdvantage = false;
            ForwardPlayers = new List<Forward>();
            MidPlayers = new List<MidFielder>();
            Defenders = new List<Defender>();
        }

        public void AddForwardPlayer(Forward forwardPlayer)
        {
            ForwardPlayers.Add(forwardPlayer);
        }

        public void AddMidPlayer(MidFielder midFielder)
        {
            MidPlayers.Add(midFielder);
        }

        public void AddDefender(Defender defender)
        {
            Defenders.Add(defender);
        }

        public int StartAttack()
        {
            return AttackPower;
        }

        public int DefendAttack()
        {
            return DefencePower;
        }
    }
}
