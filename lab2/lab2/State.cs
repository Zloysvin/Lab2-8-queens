using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public class State
    {
        public Queen[] Board{get; private set; }

        public int f_coef = 0;

        public State()
        {
            Board = new Queen[8];
        }
        public State(Queen[] board)
        {
            Board = new Queen[8];
            for (int i = 0; i < 8; i++)
            {
                Board[i] = board[i];
            }
        }

        public bool QueensHits()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = i; j < 8; j++)
                {
                    if (i != j)
                    {
                        if (Board[i].y == Board[j].y || j-i == Board[j].y - Board[i].y || j - i == -(Board[j].y - Board[i].y))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        
        public int F1()
        {
            int pairs = 0;
            bool[] paired = new bool[8];
            for (int i = 0; i < 8; i++)
            {
                paired[i] = false;
            }
            for (int i = 0; i < 8; i++)
            {
                for (int j = i; j < 8; j++)
                {
                    if (i != j && !paired[i] && !paired[j])
                    {
                        if (Board[i].y == Board[j].y || j - i == Board[j].y - Board[i].y || j - i == -(Board[j].y - Board[i].y))
                        {
                            paired[j] = true;
                            pairs++;
                            break;
                        }
                    }
                }
            }

            return pairs;
        }

        public State[] ExpandState()
        {
            List<State> expandedStates = new List<State>();
            for (int i = 0; i < 8; i++)
            {
                int y = Board[i].y;
                for (int j = 0; j < 7; j++)
                {
                    State tempState = new State(Board);
                    if (y <= j)
                    {
                        tempState.Board[i].y = j+1;
                    }
                    else
                    {
                        tempState.Board[i].y = j;
                    }
                    expandedStates.Add(tempState);
                }
            }
            return expandedStates.ToArray();
        }

        public void WriteState()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Board[j].y == 7-i)
                    {
                        Console.Write("&");
                    }
                    else
                    {
                        Console.Write("#");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
