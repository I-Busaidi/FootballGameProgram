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

        private float PowerLevel;
        public enum Position
        {
            Forward, MidFielder, Defender, GoalKeeper
        }
        public Position position { get; private set; }
        public Team team { get; private set; }

        public Player(int playerNumber, string name, float powerLevel, Position position, Team team)
        {
            PlayerNumber = playerNumber;
            PowerLevel = powerLevel;
            Name = name;
            this.position = position;
            this.team = team;
        }

        public float GetPowerLevel()
        {
            return PowerLevel;
        }
        public abstract string[] GetPlayerInfo();
    }
}
