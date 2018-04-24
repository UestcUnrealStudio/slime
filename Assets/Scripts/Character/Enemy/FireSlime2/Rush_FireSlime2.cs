using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;

public class Rush_FireSlime2 : IState
{
    private GameObject rushFire;

    private float rushSpeed = 400;

    private float rushTime = 10;

    private float rushRecoverTime = 0.5f;

    private SpriteRenderer preSpriteRender;

    public override void Enter()
    {
        base.Enter();
        FireSlime2AI fireSlime2AI = (FireSlime2AI)GetAI();
        FireSlime2 fireSlime2 = (FireSlime2)fireSlime2AI.getCharacter();
        currentRushTime = 0;
        isStart = true;
        preSpeed = Vector3.zero;
    }

    public override void Exit()
    {
        base.Exit();
    }

    private float currentRushTime = 0;
    private bool isStart = true;
    private Vector3 preSpeed;
    public override State Update()
    {
        FireSlime2AI fireSlime2AI = (FireSlime2AI)GetAI();
        FireSlime2 fireSlime2 = (FireSlime2)fireSlime2AI.getCharacter();
        GameObject myBody = fireSlime2.GetGameObject();

        if (currentRushTime < rushTime)
        {
            currentRushTime += Time.deltaTime;
            Vector3 dir = (fireSlime2.currentTarget.transform.position - myBody.transform.position).normalized;
            preSpeed = dir * rushSpeed * Time.deltaTime;
            myBody.GetComponent<Rigidbody2D>().velocity = preSpeed;

            float distance = Vector2.Distance(fireSlime2.currentTarget.transform.position, myBody.transform.position);
            if (distance<0.5f)
            {
                fireSlime2.currentTarget.GetComponent<Player>().UnderAttack(1);
                GameObject.Destroy(myBody);
            }
        }
        else
        {
            currentState = State.SUCESSED;
        }
        return State.RUNNING;
    }
}
