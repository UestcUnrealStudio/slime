using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;

public class LaunchFireBomb_FireSlimeBoss : IState
{
    private GameObject FireBomb;

    private float prepareTime = 0.1f;
    private float recoverTime = 0.5f;
    private float FireBombSpeed = 450;

    public override void Enter()
    {
        base.Enter();
        FireSlimeBossAI fireSlimeBossAI = (FireSlimeBossAI)GetAI();
        FireSlimeBoss fireSlimeBoss = (FireSlimeBoss)fireSlimeBossAI.getCharacter();

        FireBomb = fireSlimeBoss.GetFireBall();
        currentPrepareTime = 0;
        currentRecoverTime = 0;
        isFire = false;
        Debug.Log("进入skill1");
    }

    public override void Exit()
    {
        base.Exit();
        GetAI().getCharacter().GetGameObject().GetComponent<SkillUnit>().ReSetCurrentSkillTime(3);
    }

    private float currentPrepareTime = 0;
    private float currentRecoverTime = 0;
    private bool isFire = false;
    public override State Update()
    {
        FireSlimeBossAI fireSlimeBossAI = (FireSlimeBossAI)GetAI();
        FireSlimeBoss fireSlimeBoss = (FireSlimeBoss)fireSlimeBossAI.getCharacter();
        if (currentPrepareTime < prepareTime)
        {
            currentPrepareTime += Time.deltaTime;
            currentState = State.RUNNING;
        }
        else
        {
            if (!isFire)
            {
                Fire();
                currentState = State.RUNNING;
                isFire = true;
            }
            else
            {
                if (currentRecoverTime < recoverTime)
                {
                    currentRecoverTime += Time.deltaTime;
                    currentState = State.RUNNING;
                }
                else
                {
                    return State.SUCESSED;
                }
            }
        }
        return currentState;
    }

    private void Fire()
    {
        FireSlimeBossAI fireSlimeBossAI = (FireSlimeBossAI)GetAI();
        FireSlimeBoss fireSlimeBoss = (FireSlimeBoss)fireSlimeBossAI.getCharacter();
        GameObject myBody = fireSlimeBoss.GetGameObject();

        GameObject iFireBomb = GameObject.Instantiate(FireBomb, myBody.transform.position, Quaternion.identity);
        Vector3 dir = (fireSlimeBoss.currentTarget.transform.position - myBody.transform.position).normalized;
        iFireBomb.GetComponent<Rigidbody2D>().velocity = dir * FireBombSpeed * Time.deltaTime;
    }
}
