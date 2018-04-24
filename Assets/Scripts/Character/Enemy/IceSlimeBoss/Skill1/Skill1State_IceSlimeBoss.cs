using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;

public class Skill1State_IceSlimeBoss : Sequence
{
    public override void Enter()
    {
        base.Enter();
        if (childrenStates.Count == 0)
        {
            ConditionCoolTime_IceSlimeBoss conditionCoolTime = new ConditionCoolTime_IceSlimeBoss(0);
            conditionCoolTime.SetCharacterAI(GetAI());
            AddChild(conditionCoolTime);
            PrepareState_IceSlimeBoss prepareState = new PrepareState_IceSlimeBoss(2);
            SpawnIce_IceSlimeBoss spawnIce = new SpawnIce_IceSlimeBoss();
            spawnIce.SetCharacterAI(GetAI());
            AddChild(spawnIce);
        }
    }

    public override State Update()
    {
        return base.Update();
    }

}
