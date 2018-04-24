using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;
using IC;

public class Skill2State_FireSlimeBoss : Sequence
{
    public override void Enter()
    {
        base.Enter();
        if (childrenStates.Count == 0)
        {
            ConditionCoolTime_FireSlimeBoss conditionCoolTime = new ConditionCoolTime_FireSlimeBoss(1);
            GuideMagma_FireSlimeBoss guideMagma = new GuideMagma_FireSlimeBoss();
        
            guideMagma.SetCharacterAI(GetAI());
            conditionCoolTime.SetCharacterAI(GetAI());

            AddChild(conditionCoolTime);
            AddChild(guideMagma);
        }
        Debug.Log("判断skill2");
    }

    public override State Update()
    {
        return base.Update();
    }

}
