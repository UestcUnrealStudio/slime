using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IC;
using IS;

public class NormalAttackState_FireSlimeBoss : Sequence {

    public override void Enter()
    {
        base.Enter();
        if (childrenStates.Count==0)
        {
            ConditionCoolTime_FireSlimeBoss conditionCoolTime = new ConditionCoolTime_FireSlimeBoss(3);
            ConditionHaveEnemy_FireSlimeBoss conditionHaveEnemy = new ConditionHaveEnemy_FireSlimeBoss();
            DistanceCondition_FireSlimeBoss distanceCondition = new DistanceCondition_FireSlimeBoss();
            NormalAttack_FireSlimeBoss normalAttack = new NormalAttack_FireSlimeBoss();

            conditionCoolTime.SetCharacterAI(GetAI());
            conditionHaveEnemy.SetCharacterAI(GetAI());
            distanceCondition.SetCharacterAI(GetAI());
            normalAttack.SetCharacterAI(GetAI());

            conditionCoolTime.currentState = State.NONE;
            conditionHaveEnemy.currentState = State.NONE;
            distanceCondition.currentState = State.NONE;
            normalAttack.currentState = State.NONE;

            AddChild(conditionCoolTime);
            AddChild(conditionHaveEnemy);
            AddChild(distanceCondition);
            AddChild(normalAttack);
        }
        Debug.Log("判断普攻");
    }

    public override State Update()
    {
        return base.Update();
    }
}
