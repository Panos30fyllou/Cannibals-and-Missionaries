using System.Collections.Generic;
using System.Linq;

namespace CannibalsMissionaries
{
    class BFS
    {
        static List<State> Search = new List<State>();
        static List<State> Checked = new List<State>();
        static List<State> Microscope = new List<State>();
        static List<State> ChildrenStates;

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
                ChildrenStates = Microscope[Microscope.Count() - 1].getchildren();
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
