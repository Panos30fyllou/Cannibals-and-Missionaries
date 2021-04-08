using System.Collections.Generic;
using System.Linq;

namespace CannibalsMissionaries
{
    class BFS
    {
        //The List 'Search' contains the states that are next in line to be examined.
        //The List 'Checked' contains the states that have already been examined.
        //The List 'Microscope' contains the states that lead to the final state.
        //The List 'ChildrenStates' contains the children states of the state that is being examined.

        static List<State> Search = new List<State>();
        static List<State> Checked = new List<State>();
        static List<State> Microscope = new List<State>();
        static List<State> ChildrenStates;

        ///         BFS ALGORITHM           ///
        //The method 'searchUsingBFS' is used to produce and return a List of the valid states that lead to the final state.
        //First, the initial state is added to the List 'Search', and the List 'Microscope'
        //Then the program enters a 'while' loop and checks if the last state of the Microscope is the final one.
        //If it's final, the method exits the loop and returns the List 'Microscope'
        //With each loop the List 'ChildrenStates' contains the children of the state that is being examined.
        //Then, the last element of the Microscope is removed from the List 'Search'.
        //For each of the children in the List 'ChildrenStates', if it already exists in the List 'Checked' or 'Searched', then it is not added to the List 'Search'.
        //If it doesn't exist, it is added to the end of the List 'Search'
        //Last the state that is being examined, is added to the List 'Checked' and the first element of the List 'Search' is added to the Microscope.
        //The method returns the result when the final state is found.

        public static List<State> searchUsingBFS(State initialState)
        {
           
            Search.Add(initialState);
            Microscope.Add(initialState);
            while (true)
            {

                if (Microscope[Microscope.Count()-1].isStateFinal())
                {
                    return Microscope;
                }

                ChildrenStates = new List<State>();
                ChildrenStates = Microscope[Microscope.Count() - 1].getChildren();
                Search.Remove(Microscope[Microscope.Count() - 1]);

                foreach(State state in ChildrenStates)
                {
                    
                    bool exists = false;
                    foreach (State checkedState in Checked)
                    {
                        if (state.canLeft.Equals(checkedState.canLeft) && state.canRight.Equals(checkedState.canRight) && state.misLeft.Equals(checkedState.misLeft) && state.misRight.Equals(checkedState.misRight) && state.boatPosition.Equals(checkedState.boatPosition))
                        {
                            exists = true;
                            break;
                        }
                    }

                    foreach (State searchedState in Search)
                    {
                        if (state.canLeft.Equals(searchedState.canLeft) && state.canRight.Equals(searchedState.canRight) && state.misLeft.Equals(searchedState.misLeft) && state.misRight.Equals(searchedState.misRight) && state.boatPosition.Equals(searchedState.boatPosition))
                        {
                            exists = true;
                            break;
                        }
                    }

                    if (!exists)
                    {
                        Search.Add(state);
                    }

                }

                Checked.Add(Microscope[Microscope.Count() - 1]);
                Microscope.Add(Search[0]);

            }
        }
    }
}
