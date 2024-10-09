using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballGameProgram
{
    public class Team
    {
        public int TeamNumber { get; private set; }
        public string Name { get; private set; }
        public int Goals { get; private set; }
        public double TotalPower { get; private set; }
        public double AttackPower { get; private set; }
        public double DefencePower { get; private set; }
        public bool HasAdvantage { get; private set; }

        public List<Forward> ForwardPlayers { get; private set; }
        public List<MidFielder> MidPlayers { get; private set; }
        public List<Defender> Defenders { get; private set; }
        public GoalKeeper? GoalKeeper { get; private set; }

        public Team(int TeamNumber, string Name)
        {
            this.TeamNumber = TeamNumber;
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

        public void AddGoalKeeper(GoalKeeper goalKeeper)
        {
            GoalKeeper = goalKeeper;
        }

        public double StartAttack()
        {
            return AttackPower;
        }

        public double DefendAttack()
        {
            return DefencePower;
        }

        public void ScoreGoal()
        {
            Goals += 1;
        }
    }
}
