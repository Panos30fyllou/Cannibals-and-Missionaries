using System;
using System.Collections.Generic;

namespace CannibalsMissionaries
{
    class Program
    {
        static void Main(string[] args)
        {
            string selection;

            Console.WriteLine("Choose search algorithm (BFS/DFS)");

            do
            {
                selection = Console.ReadLine();

                if (selection.Equals("BFS"))
                {
                    List<State> result = BFS.searchUsingBFS(new State(3, 0, 3, 0, "Left"));
                    print(result);
                    Console.WriteLine(Environment.NewLine + "Choose an other search algorithm (BFS/DFS) or type 'EXIT' to close the program");
                }
                else if (selection.Equals("DFS"))
                {
                    List<State> result = DFS.searchUsingDFS(new State(3, 0, 3, 0, "Left"));
                    print(result);
                    Console.WriteLine(Environment.NewLine + "Choose search algorithm (BFS/DFS) or type 'EXIT' to close the program");
                }
                else if(!selection.Equals("EXIT"))
                {
                    Console.WriteLine("Please type 'BFS' or 'DFS'");
                }
                else 
                {
                    break;
                }

            } while (true);
        }

        private static void print(List<State> result)
        {
            Console.WriteLine(Environment.NewLine + "No. CL, CR, ML, MR, BP");
            int i = 1;
            string position = "Left";
            foreach (State state in result)
            {
                if (state.boatPosition.Equals(position))
                {
                    Console.WriteLine(i.ToString() + ".  " + state.canLeft.ToString() + ",  " + state.canRight + ",  " + state.misLeft + ",  " + state.misRight + ",  " + state.boatPosition);

                    if (position.Equals("Left"))
                    {
                        position = "Right";
                    }
                    else
                    {
                        position = "Left";
                    }

                    i++;
                }
            }
        }
    }
}
