using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;

public class PrepareState_IceSlimeBoss : IState {
    private float prepareTime;

    public PrepareState_IceSlimeBoss(float prepareTime)
    {
        this.prepareTime = prepareTime;
    }

    public override void Enter()
    {
        base.Enter();
        currentPrepareTime = 0;
    }

    public override void Exit()
    {
        base.Exit();
    }

    private float currentPrepareTime = 0;
    public override State Update()
    {
        if (currentPrepareTime < prepareTime)
        {
            currentPrepareTime += Time.deltaTime;
        }
        else
        {
            return State.SUCESSED;
        }
        return State.RUNNING;
    }
}
