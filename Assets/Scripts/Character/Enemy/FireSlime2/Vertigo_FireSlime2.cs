using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;

public class Vertigo_FireSlime2 : IState
{

    private float VertigoTime = 0.5f;

    public override void Enter()
    {
        base.Enter();
        currentVertigoTime = 0;
    }

    public override void Exit()
    {
        base.Exit();
    }

    private float currentVertigoTime = 0;
    public override State Update()
    {
        if(currentVertigoTime > VertigoTime)
        {
            Debug.Log("眩晕恢复");
            FireSlime2AI fireSlime2AI = (FireSlime2AI)GetAI();
            fireSlime2AI.SetHaveBumpIntoTheWall(false);
            return State.SUCESSED;
        }
        Debug.Log("眩晕中");
        GameObject myBody = GetAI().getCharacter().GetGameObject();
        myBody.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        currentVertigoTime += Time.deltaTime;
        return State.RUNNING;
    }
}
