using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public static class IDSalgorithm
    {
        private static int deadends = 0;
        public static State Execute(State root)
        {
            DateTime dt = DateTime.Now;
            State result = root;
            int depth = 0;
            int iterations = 0;
            deadends = 0;
            while (result == null || result.QueensHits())
            {
                bool remaning = false;
                result = DLS(root, depth, ref remaning);
                deadends = 0;
                iterations++;
                if (result != null)
                {
                    break;
                }
                else if(!remaning)
                {
                    result = null;
                    break;
                }
                depth++;
            }
            Console.WriteLine("Time: " + (DateTime.Now-dt).TotalSeconds + " s");
            return result;
        }

        private static State DLS(State node, int depth, ref bool remaning)
        {
            if (depth == 0)
            {
                if (!node.QueensHits())
                {
                    remaning = true;
                    return node;
                }
                else
                {
                    remaning = true;
                    return null;
                }
            }
            else
            {
                bool any_remaning = false;
                bool req_remaning = false;
                foreach (var child in node.ExpandState())
                {
                    State found = DLS(child, depth - 1, ref req_remaning);
                    if (found != null)
                    {
                        remaning = true;
                        return found;
                    }

                    if (req_remaning)
                    {
                        any_remaning = true;
                    }
                }

                remaning = any_remaning;
                return null;
            }
        }
    }
}
