using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IC;
using IS;

public class AttackState_IceSlime1 : Selector
{
    public override void Enter()
    {
        base.Enter();
        if (childrenStates.Count == 0)
        {
            IceSlime1AI iceSlime1AI = (IceSlime1AI)GetAI();
            childrenStates.Add(iceSlime1AI.GetLaunchIceBulletState());
            iceSlime1AI.GetLaunchIceBulletState().currentState = State.NONE;
        }
    }
   
    public override State Update()
    {
        return base.Update();
    }
}
