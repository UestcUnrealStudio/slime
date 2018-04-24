using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IC;
using IS;

public class Skill4State_IceSlimeBoss : Sequence
{
    public override void Enter()
    {
        base.Enter();
        if (childrenStates.Count==0)
        {
            ConditionCoolTime_IceSlimeBoss conditionCoolTime = new ConditionCoolTime_IceSlimeBoss(3);
            conditionCoolTime.SetCharacterAI(GetAI());
            AddChild(conditionCoolTime);
            Skill4_IceSlimeBoss skill4 = new Skill4_IceSlimeBoss();
            skill4.SetCharacterAI(GetAI());
            AddChild(skill4);
        }
    }

    public override State Update()
    {
        return base.Update();
    }
}
