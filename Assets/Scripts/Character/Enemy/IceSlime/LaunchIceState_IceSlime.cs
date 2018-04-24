using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;

public class LaunchIceState_IceSlime : Sequence {
 
    public override void Enter()
    {
        base.Enter();
        IceSlimeAI iceSlimeAI = (IceSlimeAI)GetAI();
        IceSlime iceSlime = (IceSlime)iceSlimeAI.getCharacter();
        if (childrenStates.Count==0)
        {
            AddChild(iceSlimeAI.GetConditionHaveEnemy());
            iceSlimeAI.GetConditionHaveEnemy().currentState = State.NONE;
            AddChild(iceSlimeAI.GetDistanceCondition());
            iceSlimeAI.GetDistanceCondition().currentState = State.NONE;
            AddChild(iceSlimeAI.GetLaunchIce());
            iceSlimeAI.GetLaunchIce().currentState = State.NONE;
        }
    }
    public override State Update()
    {
        return base.Update();
    }

}
