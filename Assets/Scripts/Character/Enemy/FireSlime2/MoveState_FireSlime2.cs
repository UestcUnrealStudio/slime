using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IC;
using IS;

public class MoveState_FireSlime2 : Selector
{
    public override void Enter()
    {

        base.Enter();
        FireSlime2AI fireSlime2AI = (FireSlime2AI)GetAI();
        FireSlime2 fireSlime2 = (FireSlime2)fireSlime2AI.getCharacter();
        GameObject myBody = fireSlime2.GetGameObject();

        if (childrenStates.Count == 0)
        {
            childrenStates.Add(fireSlime2AI.GetRushState());
            fireSlime2AI.GetRushState().currentState = State.NONE;
        }
    }


    public override State Update()
    {
        return base.Update();
    }
}
