using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;
using IC;

public class Skill2State_IceSlimeBoss : Sequence
{
    public override void Enter()
    {
        base.Enter();
        if (childrenStates.Count == 0)
        {
            ConditionCoolTime_IceSlimeBoss conditionCoolTime = new ConditionCoolTime_IceSlimeBoss(1);
            conditionCoolTime.SetCharacterAI(GetAI());
            AddChild(conditionCoolTime);
            CreateIceField_IceSlimeBoss createIceField = new CreateIceField_IceSlimeBoss();
            createIceField.SetCharacterAI(GetAI());
            AddChild(createIceField);
        }
    }

    public override State Update()
    {
        return base.Update();
    }
}
