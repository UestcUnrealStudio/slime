using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;
using IC;

public class MoveState_FireSlime : Selector {

    public MoveState_FireSlime()
    {
        currentState = State.NONE;
    }

    public override void Enter()
    {
        base.Enter();
        FireSlimeAI fireSlimeAI = (FireSlimeAI)GetAI();
        FireSlime fireSlime = (FireSlime)fireSlimeAI.getCharacter();
        GameObject myBody = fireSlime.GetGameObject();

        if (childrenStates.Count == 0)
        {
            MoveToEnemyState_FireSlime moveToEnemyState = fireSlimeAI.GetMoveToEnemyState();
            childrenStates.Add(moveToEnemyState);
        }
    }

    public override State Update()
    {
        return base.Update();
    }
}
