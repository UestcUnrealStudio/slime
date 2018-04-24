using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;
using IC;

public class AttackState_IceSlime : Selector
{
    public override void Enter()
    {
        base.Enter();
        if (childrenStates.Count == 0)
        {
            IceSlimeAI iceSlimeAI = (IceSlimeAI)GetAI();
            childrenStates.Add(iceSlimeAI.GetLaunchIceState());
            iceSlimeAI.GetLaunchIceState().currentState = State.NONE;
        }
    }
    
    public override State Update()
    {
        return base.Update();
    }
}
