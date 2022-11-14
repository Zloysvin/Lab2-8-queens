using System;

namespace lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] beginQueens = new int[8];
            Console.WriteLine("Begin State:");
            for (int i = 0; i < 8; i++)
            {
                beginQueens[i] = Random.Shared.Next(8);
            }
            Console.WriteLine();
            State root = new State(beginQueens);
            root.WriteState();
            Console.WriteLine("IDS:");
            State result = IDSalgorithm.Execute(root);
            if (result == null)
            {
                Console.WriteLine("Can't Find Any Solution");
            }
            else
            {
                result.WriteState();
            }
            Console.WriteLine();
            Console.WriteLine("RBFS:");
            result = RBFSalgorithm.Execute(root);
            if (result == null)
            {
                Console.WriteLine("Can't Find Any Solution");
            }
            else
            {
                result.WriteState();
            }
            Console.WriteLine();
        }
    }
}
