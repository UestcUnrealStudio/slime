using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IC;
using IS;

public class Skill1State_FireSlimeBoss : Sequence
{
    public override void Enter()
    {
        base.Enter();
        FireSlimeBossAI fireSlimeBossAI = (FireSlimeBossAI)GetAI();
        FireSlimeBoss fireSlimeBoss = (FireSlimeBoss)fireSlimeBossAI.getCharacter();
        if (childrenStates.Count==0)
        {
            ConditionCoolTime_FireSlimeBoss conditionCoolTime = new ConditionCoolTime_FireSlimeBoss(0);
            ConditionHaveEnemy_FireSlimeBoss conditionHaveEnemy = new ConditionHaveEnemy_FireSlimeBoss();
            RepeatDecoratorNode repeatDecoratorNode = new RepeatDecoratorNode(5);
            LaunchFireBomb_FireSlimeBoss launchFireBomb = new LaunchFireBomb_FireSlimeBoss();
            conditionCoolTime.SetCharacterAI(GetAI());
            conditionHaveEnemy.SetCharacterAI(GetAI());
            repeatDecoratorNode.SetCharacterAI(GetAI());
            launchFireBomb.SetCharacterAI(GetAI());

            repeatDecoratorNode.AddChild(launchFireBomb);
            AddChild(conditionCoolTime);
            AddChild(conditionHaveEnemy);
            AddChild(repeatDecoratorNode);
        }
        Debug.Log("判断skill1");
    }

    public override State Update()
    {
        return base.Update();
    }
}
