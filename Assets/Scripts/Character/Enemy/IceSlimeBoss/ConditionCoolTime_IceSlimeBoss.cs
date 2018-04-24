using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;

public class ConditionCoolTime_IceSlimeBoss : ConditionNode
{
    private int index;

    public ConditionCoolTime_IceSlimeBoss(int index)
    {
        this.index = index;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override State Update()
    {

        GameObject myBody = GetAI().getCharacter().GetGameObject();
        bool isReady = myBody.GetComponent<SkillUnit>().IsSkillReady(index);

        if (isReady)
        {
            return State.SUCESSED;
        }
        return State.FAILED;
    }
}
