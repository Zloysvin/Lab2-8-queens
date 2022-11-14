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
        public int[] Board{get; private set; }

        public int f_coef = 0;

        public State()
        {
            Board = new int[8];
        }
        public State(int[] board)
        {
            Board = new int[8];
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
                        if (Board[i] == Board[j] || j-i == Board[j] - Board[i] || j - i == -(Board[j] - Board[i]))
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
                        if (Board[i] == Board[j] || j - i == Board[j] - Board[i] || j - i == -(Board[j] - Board[i]))
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
                int y = Board[i];
                for (int j = 0; j < 7; j++)
                {
                    State tempState = new State(Board);
                    if (y <= j)
                    {
                        tempState.Board[i] = j+1;
                    }
                    else
                    {
                        tempState.Board[i] = j;
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
                    if (Board[j] == 7-i)
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
