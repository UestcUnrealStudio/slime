using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;

public class VertigoState_FireSlime2 : Sequence
{
    public override void Enter()
    {
        base.Enter();

        FireSlime2AI fireSlime2AI = (FireSlime2AI)GetAI();
        FireSlime2 fireSlime2 = (FireSlime2)fireSlime2AI.getCharacter();

        if (childrenStates.Count == 0)
        {
            AddChild(fireSlime2AI.GetConditionHaveBumpIntoTheWall());
            fireSlime2AI.GetConditionHaveBumpIntoTheWall().currentState = State.NONE;
            AddChild(fireSlime2AI.GetVertigo());
            fireSlime2AI.GetVertigo().currentState = State.NONE;
        }
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
