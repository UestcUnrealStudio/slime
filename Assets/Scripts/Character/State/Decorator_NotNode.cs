using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IC;

namespace IS
{
    public class Decorator_NotNode : DecoratorNode
    {
        private int currentChild = 0;

        public override void Enter()
        {
            currentChild = 0;
        }

        public override void Exit()
        {
     
        }

        public override State Update()
        {
            State state = childrenStates[0].Tick();
            if (state == State.FAILED)
            {
                return State.SUCESSED;
            }
            else if (state == State.SUCESSED)
            {
                return State.FAILED;
            }
            return State.RUNNING;
        }
    }
}
