using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;
using IC;
namespace IS {
    public class Selector : IState {

        public Selector()
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
                currentState = State.FAILED;
                return currentState;
            }

            State state = childrenStates[currentChild].Tick();
            if (state == State.SUCESSED)
            {
                return State.SUCESSED;
            }

            if (state == State.FAILED)
            {
              
                currentChild++;
            }
            return State.RUNNING;
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}