using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;

public class LaunchIceBulletState_IceSlime1 : Sequence
{
    public override void Enter()
    {
        base.Enter();
        IceSlime1AI iceSlime1AI = (IceSlime1AI)GetAI();
        if (childrenStates.Count == 0)
        {
            AddChild(iceSlime1AI.GetConditionHavaEnemy());
            iceSlime1AI.GetConditionHavaEnemy().currentState = State.NONE;
            AddChild(iceSlime1AI.GetDistanceCondition());
            iceSlime1AI.GetDistanceCondition().currentState = State.NONE;
            AddChild(iceSlime1AI.GetLaunchIceBullet());
            iceSlime1AI.GetLaunchIceBullet().currentState = State.NONE;
        }
    }

    public override State Update()
    {
        return base.Update();
    }
}
