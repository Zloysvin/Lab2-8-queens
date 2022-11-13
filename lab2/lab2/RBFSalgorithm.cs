using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public static class RBFSalgorithm
    {
        public static State Execute(State root)
        {
            DateTime dt = DateTime.Now;
            State result =  RBFS(root,  Int32.MaxValue, 0, 0);
            Console.WriteLine("Time: " + (DateTime.Now - dt).TotalSeconds + " s");
            return result;
        }

        private static State RBFS(State node, int limit, int depth, int move)
        {
            //State result = new State();
            if (node.F1() == 0)
            {
                return node;
            }

            if (depth >= limit)
                return null;

            State[] children = node.ExpandState();
            foreach (State child in children)
            {
                child.f_coef = move + 1 + child.F1();
            }

            while (true)
            {
                int bestIndex = 0;
                int altIndex = 0;
                FindBestAndAlternative(children, ref bestIndex, ref altIndex);
                if (children[bestIndex].f_coef > limit)
                {
                    limit = children[bestIndex].f_coef;
                    return null;
                }

                State result = RBFS(children[bestIndex], Math.Min(limit, children[altIndex].f_coef), depth + 1, move + 1);

                if (result != null)
                {
                    //children[bestIndex].f_coef = result.f_coef - result.F1();
                    return result;
                }
            }
            /*while (result == null || result.F1() != 0)
            {
                int best = 0;
                int alternative = 0;
                FindBestAndAlternative(children, ref best, ref alternative);
                if (children[best].f_coef > f_limit)
                {
                    f_limit = children[best].f_coef;
                    return null;
                }

                f_limit = children[alternative].f_coef;
                result = RBFS(children[best], ref f_limit, move+1);
                children[best].f_coef = f_limit;
            }*/

        }

        private static void FindBestAndAlternative(State[] states, ref int best, ref int alternative)
        {
            best = 0;
            for (int i = 0; i < 56; i++)
            {
                if (states[best].f_coef >= states[i].f_coef)
                {
                    alternative = best;
                    best = i;
                }
            }
        }
    }
}
