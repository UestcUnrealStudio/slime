using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IC;
using IS;

public class AttackState_IceSlime2 : Selector {

    public override void Enter()
    {
        base.Enter();
        if (childrenStates.Count == 0)
        {
            IceSlime2AI iceSlime2AI = (IceSlime2AI)GetAI();
            childrenStates.Add(iceSlime2AI.GetLaunchIceLaserState());
            iceSlime2AI.GetLaunchIceLaserState().currentState = State.NONE;
        }
    }
  
    public override State Update()
    {
        return base.Update();
    }
}
