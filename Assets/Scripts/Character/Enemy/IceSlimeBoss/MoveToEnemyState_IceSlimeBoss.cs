using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IC;
using IS;

public class MoveToEnemyState_IceSlimeBoss : Sequence
{
    public override void Enter()
    {
        base.Enter();
        if (childrenStates.Count == 0)
        {
            ConditionHaveEnemy_IceSlimeBoss conditionHaveEnemy = new ConditionHaveEnemy_IceSlimeBoss();
            conditionHaveEnemy.SetCharacterAI(GetAI());
            AddChild(conditionHaveEnemy);
            MoveToEnemy_IceSlimeBoss moveToEnemyState = new MoveToEnemy_IceSlimeBoss();
            moveToEnemyState.SetCharacterAI(GetAI());
            AddChild(moveToEnemyState);
        }
    }

    public override State Update()
    {
        return base.Update();
    }
}
