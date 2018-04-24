using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;

public class MoveToEnemyState_FireSlimeBoss : Sequence
{
    public override void Enter()
    {
        base.Enter();
        FireSlimeBossAI fireSlimeBossAI = (FireSlimeBossAI)GetAI();
        if (childrenStates.Count == 0)
        {
            ConditionHaveEnemy_FireSlimeBoss conditionHaveEnemy = new ConditionHaveEnemy_FireSlimeBoss();
            MoveToEnemy_FireSlimeBoss moveToEnemy = new MoveToEnemy_FireSlimeBoss();
            moveToEnemy.SetCharacterAI(GetAI());
            conditionHaveEnemy.SetCharacterAI(GetAI());

            AddChild(conditionHaveEnemy);
            AddChild(moveToEnemy);
        }
        Debug.Log("进入移动向敌人状态");
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
