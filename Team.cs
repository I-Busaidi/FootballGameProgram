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

        private double TotalPower;
        private double AttackPower;
        private double DefencePower;
        private bool HasAdvantage;

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
            TotalPower += forwardPlayer.GetPowerLevel();
            ForwardPlayers.Add(forwardPlayer);
        }

        public void AddMidPlayer(MidFielder midFielder)
        {
            TotalPower += midFielder.GetPowerLevel();
            MidPlayers.Add(midFielder);
        }

        public void AddDefender(Defender defender)
        {
            TotalPower += defender.GetPowerLevel();
            Defenders.Add(defender);
        }

        public void AddGoalKeeper(GoalKeeper goalKeeper)
        {
            TotalPower += goalKeeper.GetPowerLevel();
            GoalKeeper = goalKeeper;
        }

        public (double, string, List<string>) StartAttack()
        {
            // This list saves the name of attacking players that pass the ball.
            List<string> PassersNames = new List<string>();
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

            // Loop continues while passes done are less than possiblr passes, and if the current player passes the ball,
            // and the team still has players that can attack and did not recieve the ball yet.
            while (PassesCount < NumberOfPossiblePasses && PassOrShoot.Item2 
                && (IndexOfMidPlayer < MidPlayers.Count || IndexOfAttacker < ForwardPlayers.Count))
            {
                // If the last player gets the ball he does not attempt to pass, but shoot the ball instead
                if(PassesCount == NumberOfPossiblePasses -1)
                {
                    AttackPower += ForwardPlayers[IndexOfAttacker].Shoot();
                    NameOfBallShooter = ForwardPlayers[IndexOfAttacker].Name;
                    break;
                }
                else
                {
                    // Perform this part if there is mid players remaining.
                    if(IndexOfMidPlayer < MidPlayers.Count)
                    {
                        PassOrShoot = MidPlayers[IndexOfMidPlayer].Pass();
                        if (PassOrShoot.Item2)
                        {
                            PassersNames.Add(MidPlayers[IndexOfMidPlayer].Name);
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

                    // Perform this part if there is forward players remaining.
                    else if (IndexOfAttacker < ForwardPlayers.Count)
                    {
                        PassOrShoot = ForwardPlayers[IndexOfAttacker].Pass();
                        if (PassOrShoot.Item2)
                        {
                            PassersNames.Add(ForwardPlayers[IndexOfAttacker].Name);
                            AttackPower += PassOrShoot.Item1;
                            PassesCount++;
                        }
                        else
                        {
                            AttackPower += ForwardPlayers[IndexOfAttacker].Shoot();
                            NameOfBallShooter = ForwardPlayers[IndexOfAttacker].Name;
                        }

                        IndexOfAttacker++;
                    }
                }
            }

            return (AttackPower, NameOfBallShooter, PassersNames);
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
                DefencePower += GoalKeeper.Defend();
                CalledTeamMate = GoalKeeper.CallTeamMate();
            }
                
            int DefendTries = 0;

            // Loop while there is defenders/midfielders that did not take part yet and if current defender calls a teammate successfully.
            while (DefendTries < NumberOfPossibleDefenders && CalledTeamMate 
                && (IndexOfDefender < Defenders.Count || IndexOfMidPlayer < MidPlayers.Count))
            {
                // Priority if for defenders, then midfielders.
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
