using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;

public class RandomSelectorNode : IState
{
    private int theNumber;

    public override void Enter()
    {
        base.Enter();
        //CalTheNumber();
        theNumber = Random.Range(0, childrenStates.Count); 
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override State Update()
    {
        State state = childrenStates[theNumber].Tick();
        if (state == State.SUCESSED)
        {
            return State.SUCESSED;
        }
        if (state ==State.FAILED)
        {
            return State.FAILED;
        }
        return State.RUNNING;
    }

    //计算总权重
    void CalTheNumber()
    {
        for (int i = 0; i <childrenStates.Count ; i++)
        {
            theNumber += (10 - i * 2);
        }
    }
}
