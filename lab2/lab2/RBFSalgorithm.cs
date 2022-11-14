using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public static class RBFSalgorithm
    {
        private static int limit = 10;
        public static State Execute(State root)
        {
            DateTime dt = DateTime.Now;
            State result =  RBFS(root,  30, 0);
            Console.WriteLine("Time: " + (DateTime.Now - dt).TotalSeconds + " s");
            return result;
        }

        private static State RBFS(State node, int f_limit, int depth)
        {
            if (isSolved(node))
            {
                return node;
            }

            if (depth >= limit)
            {
                return null;
            }

            List<State> childStates = node.ExpandState().ToList();
            List<int> f = new List<int>();
            foreach (var child in childStates)
            {
                f.Add(child.F1());
            }

            while (true)
            {
                int bestValue = f.Min();
                int bestIndex = f.IndexOf(bestValue);
                State bestState = childStates[bestIndex];

                if (bestValue > f_limit)
                {
                    return null;
                }

                childStates.Remove(bestState);
                f.Remove(bestValue);

                int altValue = f.Min();
                State result = RBFS(bestState, Math.Min(f_limit, altValue), depth + 1);

                if (result != null)
                {
                    return result;
                }
            }
        }

        private static bool isSolved(State state)
        {
            for (int i = 0; i < state.Board.Length; ++i)
            {
                for (int j = 0; j < state.Board.Length; ++j)
                {
                    if (i == j) continue;
                    if (state.Board[i] == state.Board[j] || i + state.Board[i] == j + state.Board[j] || i - state.Board[i] == j - state.Board[j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
