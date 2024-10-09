using System.Text;

namespace FootballGameProgram
{
    internal class Program
    {
        static List<string> NamesPool = new List<string>() {
            "Lionel Messi",
            "Cristiano Ronaldo",
            "Neymar Jr.",
            "Kylian Mbappé",
            "Kevin De Bruyne",
            "Mohamed Salah",
            "Virgil van Dijk",
            "Sadio Mané",
            "Robert Lewandowski",
            "Karim Benzema",
            "Harry Kane",
            "Raheem Sterling",
            "Gareth Bale",
            "Luka Modrić",
            "Paul Pogba",
            "Antoine Griezmann",
            "Son Heung-min",
            "Romelu Lukaku",
            "Jadon Sancho",
            "Bruno Fernandes",
            "N'Golo Kanté",
            "Alisson Becker",
            "Manuel Neuer",
            "Jan Oblak",
            "Thibaut Courtois",
            "Sergio Ramos",
            "Marcelo",
            "Andrew Robertson",
            "Trent Alexander-Arnold",
            "Georginio Wijnaldum",
            "Frenkie de Jong",
            "Phil Foden",
            "Christian Pulisic",
            "Dominik Szoboszlai",
            "Jack Grealish",
            "Ousmane Dembélé",
            "Thomas Müller",
            "Ilkay Gündogan",
            "César Azpilicueta",
            "Ederson",
            "Mason Mount",
            "Kai Havertz",
            "Gerard Moreno",
            "Dani Olmo",
            "Rodri",
            "Youri Tielemans",
            "Giorgio Chiellini",
            "Leonardo Bonucci",
            "Philippe Coutinho"
        };
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To The Football Game Simulator!");
            Console.Write("\nEnter the 1st team name: ");
            string Team1Name;
            while (string.IsNullOrEmpty(Team1Name = Console.ReadLine()))
            {
                Console.Clear();
                Console.WriteLine("Invalid Input, please try again.");
                Console.Write("\nEnter the 1st team name: ");
            }

            Console.Clear();
            Console.Write("\nEnter the 2nd team name: ");
            string Team2Name;
            while (string.IsNullOrEmpty(Team2Name = Console.ReadLine()))
            {
                Console.Clear();
                Console.WriteLine("Invalid Input, please try again.");
                Console.Write("\nEnter the 2nd team name: ");
            }

            Team team1 = new Team(1, Team1Name);
            Team team2 = new Team(2, Team2Name);

            Console.Clear();
            Console.WriteLine("Generating Team 1 Players.");
            Console.WriteLine(AddPlayers(team1));
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("Generating Team 2 Players.");
            Console.WriteLine(AddPlayers(team2));

            Console.WriteLine("Press any key to start match...");
            Console.ReadKey();
            Console.Clear();

            PlayMatch Match = new PlayMatch(team1, team2);
            Console.WriteLine(Match.MatchStartMessage);

            Console.WriteLine("First Half\n");
            Console.WriteLine(Match.PlayHalf());

            Console.WriteLine("Press any key to start second half...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Second Half\n");
            Console.WriteLine(Match.PlayHalf());

            Console.WriteLine("Press any key to show match results...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine($"{team1.Name} vs {team2.Name} results:\n");
            Console.WriteLine(Match.MatchResult());
        }

        static string AddPlayers(Team team)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Team {team.Name}");
            sb.AppendLine();
            sb.AppendLine($"{"No.", -5} | {"Name", -25} | {"Position", -15} | {"Skill", -5}");
            string border = new string('-', 60);
            sb.AppendLine(border);
            Random random = new Random();
            int RandomSkillGenerator = random.Next(1, 100);
            int RandomNameIndex = random.Next(0, NamesPool.Count);
            team.AddGoalKeeper(new GoalKeeper(1, NamesPool[RandomNameIndex], RandomSkillGenerator, Player.Position.GoalKeeper, team));
            sb.AppendLine($"{1,-5} | {NamesPool[RandomNameIndex],-25} | {Player.Position.GoalKeeper,-15} | {RandomSkillGenerator,-5}");
            NamesPool.Remove(NamesPool[RandomNameIndex]);

            RandomSkillGenerator = random.Next(1, 100);
            RandomNameIndex = random.Next(0, NamesPool.Count);
            team.AddForwardPlayer(new Forward(2, NamesPool[RandomNameIndex], RandomSkillGenerator, Player.Position.Forward, team));
            sb.AppendLine($"{2,-5} | {NamesPool[RandomNameIndex],-25} | {Player.Position.Forward,-15} | {RandomSkillGenerator,-5}");
            NamesPool.Remove(NamesPool[RandomNameIndex]);

            RandomSkillGenerator = random.Next(1, 100);
            RandomNameIndex = random.Next(0, NamesPool.Count);
            team.AddMidPlayer(new MidFielder(3, NamesPool[RandomNameIndex], RandomSkillGenerator, Player.Position.MidFielder, team));
            sb.AppendLine($"{3,-5} | {NamesPool[RandomNameIndex],-25} | {Player.Position.MidFielder,-15} | {RandomSkillGenerator,-5}");
            NamesPool.Remove(NamesPool[RandomNameIndex]);

            RandomSkillGenerator = random.Next(1, 100);
            RandomNameIndex = random.Next(0, NamesPool.Count);
            team.AddDefender(new Defender(4, NamesPool[RandomNameIndex], RandomSkillGenerator, Player.Position.Defender, team));
            sb.AppendLine($"{4,-5} | {NamesPool[RandomNameIndex],-25} | {Player.Position.Defender,-15} | {RandomSkillGenerator,-5}");
            NamesPool.Remove(NamesPool[RandomNameIndex]);

            int playerNumber = 5;

            int RandomPlayerAssignment;
            for (int i = 0; i < 7; i++)
            {
                RandomSkillGenerator = random.Next(1, 100);
                RandomPlayerAssignment = random.Next(1, 100);
                RandomNameIndex = random.Next(0, NamesPool.Count);

                if (RandomPlayerAssignment >= 0 && RandomPlayerAssignment < 33)
                {
                    team.AddForwardPlayer(new Forward(2, NamesPool[RandomNameIndex], RandomSkillGenerator, Player.Position.Forward, team));
                    sb.AppendLine($"{playerNumber,-5} | {NamesPool[RandomNameIndex],-25} | {Player.Position.Forward,-15} | {RandomSkillGenerator,-5}");
                }
                else if (RandomPlayerAssignment >= 33 && RandomPlayerAssignment < 66)
                {
                    team.AddMidPlayer(new MidFielder(3, NamesPool[RandomNameIndex], RandomSkillGenerator, Player.Position.MidFielder, team));
                    sb.AppendLine($"{playerNumber,-5} | {NamesPool[RandomNameIndex],-25} | {Player.Position.MidFielder,-15} | {RandomSkillGenerator,-5}");
                }
                else
                {
                    team.AddDefender(new Defender(4, NamesPool[RandomNameIndex], RandomSkillGenerator, Player.Position.Defender, team));
                    sb.AppendLine($"{playerNumber,-5} | {NamesPool[RandomNameIndex],-25} | {Player.Position.Defender,-15} | {RandomSkillGenerator,-5}");
                }

                NamesPool.Remove(NamesPool[RandomNameIndex]);
                playerNumber++;
            }

            return sb.ToString();
        }
    }
}
