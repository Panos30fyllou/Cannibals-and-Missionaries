using System.Collections.Generic;

namespace CannibalsMissionaries
{
    class State
    {
        public int canLeft, canRight, misLeft, misRight;
        public string boatPosition;

        public State(int canLeft, int canRight, int misLeft, int misRight, string boatPosition)
        {
            this.canLeft = canLeft;
            this.canRight = canRight;
            this.misLeft = misLeft;
            this.misRight = misRight;
            this.boatPosition = boatPosition;
        }

        public List<State> getchildren()
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