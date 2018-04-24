using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IC;
using IS;

public class RushState_FireSlime2 : Sequence
{
    public override void Enter()
    {
        base.Enter();
        if (childrenStates.Count == 0)
        {
            FireSlime2AI fireSlime2AI = (FireSlime2AI)GetAI();
            AddChild(fireSlime2AI.GetConditionHaveEnemy());
            fireSlime2AI.GetConditionHaveEnemy().currentState = State.NONE;
            AddChild(fireSlime2AI.GetRush());
            fireSlime2AI.GetRush().currentState = State.NONE;
        }
    }

    public override State Update()
    {
        return base.Update();
    }
}
