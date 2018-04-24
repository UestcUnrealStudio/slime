using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IC;
using IS;

public class Skill3State_FireSlimeBoss : Sequence
{
    public override void Enter()
    {
        base.Enter();
        FireSlimeBossAI fireSlimeBossAI = (FireSlimeBossAI)GetAI();
;
        if (childrenStates.Count == 0)
        {
            ConditionCoolTime_FireSlimeBoss conditionCoolTime = new ConditionCoolTime_FireSlimeBoss(2);
            RepeatDecoratorNode repeatDecoratorNode = new RepeatDecoratorNode(3);
            RepeatGuideMagma_FireSlimeBoss repeatGuideMagma = new RepeatGuideMagma_FireSlimeBoss();
            conditionCoolTime.SetCharacterAI(GetAI());
            repeatDecoratorNode.SetCharacterAI(GetAI());
            repeatGuideMagma.SetCharacterAI(GetAI());
            repeatDecoratorNode.AddChild(repeatGuideMagma);

            AddChild(conditionCoolTime);
            AddChild(repeatDecoratorNode);
        }
        Debug.Log("判断skill3");
    }

    public override State Update()
    { 
        return base.Update();
    }
}
