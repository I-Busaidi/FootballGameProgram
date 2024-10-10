using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballGameProgram
{
    public class PlayMatch
    {
        public string MatchStartMessage { get; private set; }
        public Team team1 { get; private set; }
        public Team team2 { get; private set; }
        public PlayMatch(Team team1, Team team2)
        {
            this.team1 = team1;
            this.team2 = team2;
            MatchStartMessage = $"Ladies and gentlemen, welcome!\nToday we have a very anticipated match between {team1.Name} and {team2.Name}!\nLet the game begin!\n\n";
        }

        public string PlayHalf()
        {
            StringBuilder sb = new StringBuilder();
            Random random = new Random();
            int CoinFlip = random.Next(0, 2);

            // Getting the number of turns (min: 4, max: 10)
            int NumberOfTurns = random.Next(4, 11);
            bool team1Attacked = false;

            // Starting team is decided by the coin flip (random 0 or 1)
            if (CoinFlip == 0)
            {
                sb.AppendLine($"Team {team1.Name} is starting the kickoff!");
            }
            else
            {
                sb.AppendLine($"Team {team2.Name} is starting the kickoff!");
                team1Attacked = true;
            }
            for (int i = 0; i < NumberOfTurns; i++)
            {
                // If team 1 is starting first then initiate a team 1 attack and team 2 defence,
                // then alternate for a number of turns decided by the random generator.
                if (!team1Attacked)
                {
                    var Team1Attack = team1.StartAttack();
                    var Team2Defend = team2.DefendAttack();
                    sb.AppendLine();
                    sb.AppendLine($"{team1.Name}'s Turn to Attack:");
                    sb.AppendLine();
                    if (Team1Attack.Item3.Count == 0)
                    {
                        sb.AppendLine($"{team1.Name} are attacking!");
                        sb.AppendLine();
                        sb.AppendLine($"{Team1Attack.Item2} is attempting to score!");
                    }
                    else if (Team1Attack.Item3.Count == 1)
                    {
                        sb.AppendLine($"{Team1Attack.Item3[0]} Passed the ball to {Team1Attack.Item2}!");
                        sb.AppendLine();
                        sb.AppendLine($"{Team1Attack.Item2} is attempting to score!");
                    }
                    else
                    {
                        for (int j = 1; j < Team1Attack.Item3.Count; j++)
                        {
                            sb.AppendLine($"{Team1Attack.Item3[j - 1]} Passed the ball to {Team1Attack.Item3[j]}!");
                            sb.AppendLine();
                        }
                        sb.AppendLine($"{Team1Attack.Item3[Team1Attack.Item3.Count - 1]} Passed the ball to {Team1Attack.Item2}!");
                        sb.AppendLine();
                        sb.AppendLine($"{Team1Attack.Item2} is attempting to score!");
                    }
                    sb.AppendLine();
                    if (Team1Attack.Item1 > Team2Defend)
                    {
                        team1.ScoreGoal();
                        sb.AppendLine($"{Team1Attack.Item2} has scored a goal for his team {team1.Name}!");
                    }
                    else
                    {
                        sb.AppendLine($"The defence of {team2.Name} is too strong for {team1.Name} to overcome! and {team2.Name} were able to defend their goal!");
                    }
                    sb.AppendLine();
                    sb.AppendLine($"Score: {team1.Name}:{team1.Goals} | {team2.Name}:{team2.Goals}");
                    sb.AppendLine("-----------------------------------------------------------------");
                    team1Attacked = true;
                }

                // Team 2 turn, starts after team 1 attacks or if they win the coin flip.
                else
                {
                    sb.AppendLine();
                    sb.AppendLine($"{team2.Name}'s Turn to Attack:");
                    sb.AppendLine();
                    var Team2Attack = team2.StartAttack();
                    var Team1Defend = team1.DefendAttack();
                    if (Team2Attack.Item3.Count == 0)
                    {
                        sb.AppendLine($"{team2.Name} are attacking!");
                        sb.AppendLine();
                        sb.AppendLine($"{Team2Attack.Item2} is attempting to score!");
                    }
                    else if (Team2Attack.Item3.Count == 1)
                    {
                        sb.AppendLine($"{Team2Attack.Item3[0]} Passed the ball to {Team2Attack.Item2}!");
                        sb.AppendLine();
                        sb.AppendLine($"{Team2Attack.Item2} is attempting to score!");
                    }
                    else
                    {
                        for (int j = 1; j < Team2Attack.Item3.Count; j++)
                        {
                            sb.AppendLine($"{Team2Attack.Item3[j - 1]} Passed the ball to {Team2Attack.Item3[j]}!");
                            sb.AppendLine();
                        }
                        sb.AppendLine($"{Team2Attack.Item3[Team2Attack.Item3.Count - 1]} Passed the ball to {Team2Attack.Item2}!");
                        sb.AppendLine();
                        sb.AppendLine($"{Team2Attack.Item2} is attempting to score!");
                    }
                    sb.AppendLine();
                    if (Team2Attack.Item1 > Team1Defend)
                    {
                        team2.ScoreGoal();
                        sb.AppendLine($"{Team2Attack.Item2} has scored a goal for his team {team2.Name}!");
                    }
                    else
                    {
                        sb.AppendLine($"The defence of {team1.Name} is too strong for {team2.Name} to overcome! and {team1.Name} were able to defend their goal!");
                    }
                    sb.AppendLine();
                    sb.AppendLine($"Score: {team1.Name}:{team1.Goals} | {team2.Name}:{team2.Goals}");
                    sb.AppendLine("-----------------------------------------------------------------");
                    team1Attacked = false;
                }
            }
            return sb.ToString();
        }

        public string MatchResult()
        {
            string Result;
            if (team1.Goals > team2.Goals)
            {
                Result = $"{team1.Name} has won the match by a score of {team1.Goals} to {team2.Goals}!";
            }
            else if (team1.Goals < team2.Goals)
            {
                Result = $"{team2.Name} has won the match by a score of {team2.Goals} to {team1.Goals}!";
            }
            else
            {
                Result = $"The match ended with a draw {team1.Goals} to {team2.Goals}!";
            }
            return Result;
        }
    }
}
