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
            TotalPower += forwardPlayer.PowerLevel;
            ForwardPlayers.Add(forwardPlayer);
        }

        public void AddMidPlayer(MidFielder midFielder)
        {
            TotalPower += midFielder.PowerLevel;
            MidPlayers.Add(midFielder);
        }

        public void AddDefender(Defender defender)
        {
            TotalPower += defender.PowerLevel;
            Defenders.Add(defender);
        }

        public void AddGoalKeeper(GoalKeeper goalKeeper)
        {
            TotalPower += goalKeeper.PowerLevel;
            GoalKeeper = goalKeeper;
        }

        public (double, string) StartAttack()
        {
            string NameOfBallShooter;
            int NumberOfPossiblePasses = MidPlayers.Count + ForwardPlayers.Count;
            int PassesCount = 0;
            int IndexOfMidPlayer = 1;
            int IndexOfAttacker = 0;

            // Resetting Attack Power for a new attempt.
            AttackPower = 0;

            // At least 1 player is involved in the attack.
            NameOfBallShooter = MidPlayers[0].Name;
            // Attack always starts from the Midfielders.

            var PassOrShoot = MidPlayers[0].Pass();
            AttackPower += PassOrShoot.Item1;

            while (PassesCount < NumberOfPossiblePasses && PassOrShoot.Item2 
                && (IndexOfMidPlayer < MidPlayers.Count || IndexOfAttacker < ForwardPlayers.Count))
            {
                if(PassesCount == NumberOfPossiblePasses -1)
                {
                    AttackPower += ForwardPlayers[IndexOfAttacker].Shoot();
                    NameOfBallShooter = ForwardPlayers[IndexOfAttacker].Name;
                    break;
                }
                else
                {
                    if(IndexOfMidPlayer < MidPlayers.Count)
                    {
                        PassOrShoot = MidPlayers[IndexOfMidPlayer].Pass();
                        if (PassOrShoot.Item2)
                        {
                            AttackPower += PassOrShoot.Item1;
                            PassesCount++;
                        }
                        else
                        {
                            AttackPower += MidPlayers[IndexOfMidPlayer].Shoot();
                            NameOfBallShooter = MidPlayers[IndexOfMidPlayer].Name;
                        }

                        IndexOfMidPlayer++;
                    }
                    else if (IndexOfAttacker < ForwardPlayers.Count)
                    {
                        PassOrShoot = ForwardPlayers[IndexOfAttacker].Pass();
                        if (PassOrShoot.Item2)
                        {
                            AttackPower += PassOrShoot.Item1;
                            PassesCount++;
                        }
                        else
                        {
                            AttackPower += ForwardPlayers[IndexOfAttacker].Shoot();
                            NameOfBallShooter = MidPlayers[IndexOfMidPlayer].Name;
                        }

                        IndexOfAttacker++;
                    }
                }
            }

            return (AttackPower, NameOfBallShooter);
        }

        public double DefendAttack()
        {
            bool CalledTeamMate = false;
            int NumberOfPossibleDefenders = Defenders.Count + MidPlayers.Count;
            int IndexOfDefender = 0;
            int IndexOfMidPlayer = 0;

            // Resetting the Defence Power before starting a new defence manuever.
            DefencePower = 0;
            
            // Goalkeeper is always involved in the defence.
            if (GoalKeeper != null)
            {
                DefencePower += GoalKeeper.DefendPower;
                CalledTeamMate = GoalKeeper.CallTeamMate();
            }
                
            int DefendTries = 0;

            while (DefendTries < NumberOfPossibleDefenders && CalledTeamMate 
                && (IndexOfDefender < Defenders.Count || IndexOfMidPlayer < MidPlayers.Count))
            {
                if (IndexOfDefender < Defenders.Count)
                {
                    DefencePower += Defenders[IndexOfDefender].Defend();
                    CalledTeamMate = Defenders[IndexOfDefender].CallTeamMate();
                    IndexOfDefender++;
                }
                else if (IndexOfMidPlayer < MidPlayers.Count)
                {
                    DefencePower += MidPlayers[IndexOfMidPlayer].Defend();
                    CalledTeamMate = MidPlayers[IndexOfMidPlayer].CallTeamMate();
                    IndexOfMidPlayer++;
                }
                DefendTries++;
            }
            return DefencePower;
        }

        public void ScoreGoal()
        {
            Goals += 1;
        }
    }
}
