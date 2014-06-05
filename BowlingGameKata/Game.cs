using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGameKata
{
    public class Game
    {

        private int[] rolls;
        private int rollCounter;

        public Game()
        {

           rolls = new int[20];
           rollCounter = 0; 
        }

        public void Roll(int pins)
        {
            rolls[rollCounter] += pins;
            rollCounter++;
        }

        public int Score()
        {
            var score = 0;
            var rollFrameIndex = 0;

            for (var frame = 0; frame < 10; frame = frame +1 )
            {

                if (IsStrike(rollFrameIndex))
                {
                    score += ( 10 + rolls[rollFrameIndex + 1] + rolls[rollFrameIndex + 2] );
                    rollFrameIndex = rollFrameIndex + 1;
                }
                else if (IsSpare(rollFrameIndex))
                {
                    score += 10 + rolls[rollFrameIndex + 2];
                    rollFrameIndex = rollFrameIndex + 2;
                }
                else
                {
                    score += rolls[rollFrameIndex] + rolls[rollFrameIndex + 1];
                    rollFrameIndex = rollFrameIndex + 2; 
                }

            }

        return  score;

        }

        private bool IsSpare(int rollFrameIndex)
        {
            return rolls[rollFrameIndex] + rolls[rollFrameIndex + 1] == 10;
        }

        private bool IsStrike(int rollFrameIndex)
        {
            return rolls[rollFrameIndex] == 10;
        }

    }
}
