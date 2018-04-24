using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;

public class ConditionHaveBumpIntoTheWall_FireSlime2 : ConditionNode
{
    private bool haveBumpIntoTheWall;

    public override void Enter()
    {
        base.Enter();
        haveBumpIntoTheWall = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override State Update()
    {
        FireSlime2AI fireSlime2AI = (FireSlime2AI)GetAI();
        haveBumpIntoTheWall = fireSlime2AI.GetHaveBumpIntoTheWall();
        if (haveBumpIntoTheWall)
        {
            return State.SUCESSED;
        }
        return State.FAILED;
    }
}
