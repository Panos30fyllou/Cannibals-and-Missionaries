using System;
using System.Collections.Generic;

namespace CannibalsMissionaries
{
    class Program
    {
        static void Main(string[] args)
        {
            ///     DIALOGUE    ///
            string selection;
            Console.WriteLine("Choose search algorithm (BFS/DFS)");

            do
            {
                selection = Console.ReadLine();

                //The user can choose which algorithm he wants to see the solution of.
                //If he types in BFS or DFS, the method 'searchUsingBFS' or 'searchUsingDFS' is called accordingly.
                //The method 'print' is called to print the solution returned from the method of the algorithm.
                //If he types in 'EXIT', the program closes.
                //If he types anything else, the program, will ask for an acceptable input.
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

        //The method 'print' is used to print the results.
        //First, the name of each column is printed.
        //Every element of the List 'result' is printed as long as the boat is not on the same side as the previous state.
        private static void print(List<State> result)
        {
            Console.WriteLine(Environment.NewLine + "No. Cannibals Left, Cannibals Right, Missionaries Left, Missionaries Right, Boat Position");
            int i = 1;
            string position = "Left";
            foreach (State state in result)
            {
                if (state.boatPosition.Equals(position))
                {
                    Console.WriteLine(i.ToString() + ".  " + state.canLeft.ToString() + ",              " + state.canRight + ",               " + state.misLeft + ",                 " + state.misRight + ",                  " + state.boatPosition);

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
