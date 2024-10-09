using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballGameProgram
{
    public abstract class Player
    {
        public int PlayerNumber { get; private set; }
        public string Name { get; private set; }
        public int PowerLevel { get; private set; }
        public enum Position
        {
            Forward, MidFielder, Defender, GoalKeeper
        }
        public Position position { get; private set; }
        public Team team { get; private set; }

        public Player(int playerNumber, string name, int powerLevel, Position position, Team team)
        {
            PlayerNumber = playerNumber;
            Name = name;
            PowerLevel = powerLevel;
            this.position = position;
            this.team = team;
        }

        public abstract string GetPlayerInfo();
    }
}
