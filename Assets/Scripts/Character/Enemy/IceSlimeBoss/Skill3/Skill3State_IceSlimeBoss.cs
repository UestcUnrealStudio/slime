using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;
using IC;

public class Skill3State_IceSlimeBoss : Sequence
{
    public override void Enter()
    {
        base.Enter();
        if (childrenStates.Count == 0)
        {
            ConditionCoolTime_IceSlimeBoss conditionCoolTime = new ConditionCoolTime_IceSlimeBoss(2);
            conditionCoolTime.SetCharacterAI(GetAI());
            AddChild(conditionCoolTime);
            GatherEnergy_IceSlimeBoss gatherEnergy = new GatherEnergy_IceSlimeBoss();
            gatherEnergy.SetCharacterAI(GetAI());
            AddChild(gatherEnergy);
        }
    }

    public override State Update()
    {
        return base.Update();
    }
}
