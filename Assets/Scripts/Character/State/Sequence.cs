using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IC;
using IS;

namespace IS {
    //顺序器
    public class Sequence : IState
    {
        public Sequence()
        {
            currentState = State.NONE;
        }

        public override void Enter()
        {
            currentChild = 0;
        }
        private int currentChild = 0;
        public override State Update()
        {
            if (currentChild >= childrenStates.Count)
            {
                return State.SUCESSED;
            }

            State state = childrenStates[currentChild].Tick();
            if(state == State.FAILED)
            {
                return State.FAILED;
            }

            if (state == State.SUCESSED)
            {
                currentChild++;
            }

            return State.RUNNING;
        }
    }
}
