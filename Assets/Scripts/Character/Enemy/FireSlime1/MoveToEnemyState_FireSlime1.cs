using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;
using IC;

public class MoveToEnemyState_FireSlime1 : Sequence {
    public override void Enter()
    {
        base.Enter();
        FireSlime1AI fireSlime1AI = (FireSlime1AI)GetAI();
        FireSlime1 fireSlime1 = (FireSlime1)fireSlime1AI.getCharacter();
        GameObject myBody = fireSlime1.GetGameObject();

        if (childrenStates.Count == 0)
        {
            childrenStates.Add(fireSlime1AI.GetConditionHaveEnemy());
            fireSlime1AI.GetConditionHaveEnemy().currentState = State.NONE;
            childrenStates.Add(fireSlime1AI.GetMoveToEnemy());
            fireSlime1AI.GetMoveToEnemy().currentState = State.NONE;
        }
    }

    public override State Update()
    {
        return base.Update();
    }
}

