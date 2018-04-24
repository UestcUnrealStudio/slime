using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IC;
using IS;

public class LaunchIceLaserState_IceSlime2 : Sequence
{
    public override void Enter()
    {
        base.Enter();
        IceSlime2AI iceSlime2AI = (IceSlime2AI)GetAI();
        if (childrenStates.Count==0)
        {
            AddChild(iceSlime2AI.GetConditionHavaEnemy());
            AddChild(iceSlime2AI.GetDistanceCondition());
            AddChild(iceSlime2AI.GetLaunchIceLaser());
            iceSlime2AI.GetConditionHavaEnemy().currentState = State.NONE;
            iceSlime2AI.GetDistanceCondition().currentState = State.NONE;
            iceSlime2AI.GetLaunchIceLaser().currentState = State.NONE;
        }
    }

    public override State Update()
    {
        return base.Update();
    }
}
