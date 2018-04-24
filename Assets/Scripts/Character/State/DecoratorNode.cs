using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IC;

namespace IS
{
    public class DecoratorNode : IState
    {
        private int currentChild = 0;

        public DecoratorNode()
        {
            currentState = State.NONE;
        }

        public override void Enter()
        {
            currentChild = 0; 
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override State Update()
        {
            return base.Update();
        }
    }
}
