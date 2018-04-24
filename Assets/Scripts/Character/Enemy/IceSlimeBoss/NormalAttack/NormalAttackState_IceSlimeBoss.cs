using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;

public class NormalAttackState_IceSlimeBoss : Sequence
{
    public override void Enter()
    {
        base.Enter();
        if (childrenStates.Count == 0)
        {
            ConditionHaveEnemy_IceSlimeBoss conditionHaveEnemy = new ConditionHaveEnemy_IceSlimeBoss();
            DistanceCondition_IceSlimeBoss distanceCondition = new DistanceCondition_IceSlimeBoss();
            ConditionCoolTime_IceSlimeBoss conditionCoolTime = new ConditionCoolTime_IceSlimeBoss(4);
            NormalAttack_IceSlimeBoss normalAttack = new NormalAttack_IceSlimeBoss();
            conditionCoolTime.SetCharacterAI(GetAI());
            conditionHaveEnemy.SetCharacterAI(GetAI());
            distanceCondition.SetCharacterAI(GetAI());
            normalAttack.SetCharacterAI(GetAI());

            AddChild(conditionCoolTime);
            AddChild(conditionHaveEnemy);
            AddChild(distanceCondition);
            AddChild(normalAttack);
        }
        Debug.Log("进入普通攻击");
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
