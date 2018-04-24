using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IC;
using IS;

public class LaunchFusedLaserState_FireSlime : Sequence
{
    private float attackRange;
    private float attackRate;
    private float recovetTime = 2;
    private float fuseLaserSpeed = 300;

    private GameObject fusedLaser;

    public LaunchFusedLaserState_FireSlime()
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
            childrenStates.Add(fireSlimeAI.GetDistanceCondition());
            fireSlimeAI.GetDistanceCondition().currentState = State.NONE;
            childrenStates.Add(fireSlimeAI.GetLaunchFusedLaser());
            fireSlimeAI.GetConditionHasEnemy().currentState = State.NONE;
        }
    }

    public override State Update()
    {
        return base.Update();
    }

    
}
