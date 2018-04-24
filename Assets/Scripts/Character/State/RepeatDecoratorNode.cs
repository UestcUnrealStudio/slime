using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;

public class RepeatDecoratorNode : DecoratorNode
{
    private int repeatTime;

    public RepeatDecoratorNode(int repeatTime)
    {
        this.repeatTime = repeatTime;
    }

    public override void Enter()
    {
        base.Enter();
        currentRepeatTime = repeatTime;
        Debug.Log("开始执行重复装饰器");
    }

    public override void Exit()
    {
        base.Exit();
    }

    private int currentRepeatTime = 0;
    public override State Update()
    {
        Debug.Log("更新重复装饰器");
        if (currentRepeatTime <= 0)
        {
            Debug.Log("重复装饰器执行成功");
            return State.SUCESSED;
        }

        State state = childrenStates[0].Tick();
        Debug.Log(state);
        if (state == State.SUCESSED)
        {
            currentRepeatTime--;
        }
        else if (state == State.FAILED)
        {
            return State.FAILED;
        }
        return State.RUNNING;
    }
}
