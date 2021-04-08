using System.Collections.Generic;

namespace CannibalsMissionaries
{
    class State
    {
        public int canLeft, canRight, misLeft, misRight;
        public string boatPosition;

        ///     CONSTRUCTOR STATE     ///
        //The constructor's parameters are the number of cannibals and missionaries on each side, as well as the boat's position.
        public State(int canLeft, int canRight, int misLeft, int misRight, string boatPosition)
        {
            this.canLeft = canLeft;
            this.canRight = canRight;
            this.misLeft = misLeft;
            this.misRight = misRight;
            this.boatPosition = boatPosition;
        }

        //The method 'getChildren' is used to produce the children of each state.
        //The boat's position of the state's children is the opposite of the state's boat's position.
        //Each of the five possible combinations (st1-st5) are created using the State's constructor.
        //If they are valid, then they are added to the List 'children', which is returned by the method.
        public List<State> getChildren()
        {
            List<State> children = new List<State>();
            if (boatPosition.Equals("Left"))
            {
                State st1 = new State(canLeft - 1, canRight + 1, misLeft, misRight, "Right");
                State st2 = new State(canLeft - 2, canRight + 2, misLeft, misRight, "Right");
                State st3 = new State(canLeft - 1, canRight + 1, misLeft-1, misRight + 1, "Right");
                State st4 = new State(canLeft, canRight, misLeft - 1, misRight + 1, "Right");
                State st5 = new State(canLeft, canRight, misLeft - 2, misRight + 2, "Right");

                if (st3.isStateValid())
                {
                    children.Add(st3);
                }
                if (st1.isStateValid())
                {
                    children.Add(st1);
                }
                if (st2.isStateValid())
                {
                    children.Add(st2);
                }
                if (st4.isStateValid())
                {
                    children.Add(st4);
                }
                if (st5.isStateValid())
                {
                    children.Add(st5);
                }

            }
            else
            {
                State st1 = new State(canLeft + 1, canRight - 1, misLeft, misRight, "Left");
                State st2 = new State(canLeft + 2, canRight - 2, misLeft, misRight, "Left");
                State st3 = new State(canLeft + 1, canRight - 1, misLeft + 1, misRight - 1, "Left");
                State st4 = new State(canLeft, canRight, misLeft + 1, misRight - 1, "Left");
                State st5 = new State(canLeft , canRight, misLeft + 2, misRight - 2, "Left");

                if (st1.isStateValid())
                {
                    children.Add(st1);
                }
                if (st2.isStateValid())
                {
                    children.Add(st2);
                }
                if (st3.isStateValid())
                {
                    children.Add(st3);
                }
                if (st4.isStateValid())
                {
                    children.Add(st4);
                }
                if (st5.isStateValid())
                {
                    children.Add(st5);
                }
            }
            return children; 
        }

        //The method 'isStateValid' is used to check if a state is valid according to the game rules.
        //The number of missionaries and cannibals on each side must be greater or equal than zero.
        //If there are both missionaries and cannibals on a side, the number of missionaries must be greater than the number of cannibals on this side.
        //If on one side the number of missionaries is less than the number of cannibals, the method returns false.
        //If the number of missionaries or the number of cannibals on a side is negative, the method returns false.
        public bool isStateValid()
        {
            if (misLeft >= 0 && misRight >= 0 && canLeft >= 0 && canRight >= 0)
            {
                if(misLeft > 0)
                {
                    if (misLeft < canLeft)
                    {
                        return false;
                    }
                }
                if(misRight > 0)
                {
                    if (misRight < canRight)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        //The method 'isStateFinal' is used to check if a state is final, according to the game rules.
        //If both the number of missionaries and cannibals on the right side are equal to 3 and the boat is on the right side, then the state is final and the method returns true; 
        public bool isStateFinal() 
        {
            if(misRight.Equals(3) && canRight.Equals(3) && boatPosition.Equals("Right"))
            {
                return true;
            }
            return false;
        }
    }
}