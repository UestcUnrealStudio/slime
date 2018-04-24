using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;
using IC;

namespace IS
{
    public class ConditionNode : IState
    {
        public ConditionNode()
        {
            currentState = State.NONE;
        }

        public override void Enter()
        {
            base.Enter();
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