using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;

public class ConditionCoolTime_FireSlimeBoss : ConditionNode
{
    private int index;

    public ConditionCoolTime_FireSlimeBoss(int index)
    {
        this.index = index;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("判断冷却时间");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override State Update()
    {

        GameObject myBody = GetAI().getCharacter().GetGameObject();
        bool isReady = myBody.GetComponent<SkillUnit>().IsSkillReady(index);
        Debug.Log(isReady);
        if (isReady)
        {
            Debug.Log("冷却完毕" + index);
            return State.SUCESSED;
        }
        Debug.Log("正在冷却");
        return State.FAILED;
    }
}
