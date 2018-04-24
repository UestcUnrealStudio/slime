using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;
using IC;

public class MoveToEnemyState_FireSlime : Sequence
{
    public MoveToEnemyState_FireSlime()
    {
        currentState = State.NONE;
    }

    public override void Enter()
    {
        base.Enter();
        FireSlimeAI fireSlimeAI = (FireSlimeAI)GetAI();
        if (childrenStates.Count == 0)
        {
            childrenStates.Add(fireSlimeAI.GetConditionHasEnemy());
            fireSlimeAI.GetConditionHasEnemy().currentState = State.NONE;
            childrenStates.Add(fireSlimeAI.GetMoveToEnemy());
            fireSlimeAI.GetMoveToEnemy().currentState = State.NONE;
        }
    }

    public override State Update()
    {
        return base.Update(); 
    }
}
