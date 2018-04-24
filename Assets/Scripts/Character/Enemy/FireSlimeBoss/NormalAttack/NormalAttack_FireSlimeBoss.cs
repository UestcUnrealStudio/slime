using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;

public class NormalAttack_FireSlimeBoss : IState
{

    private GameObject fireBomb;

    private float fireSpeed = 300;

    private float prepareTime = 0.5f;
    private float recoverTime = 0.3f;
    public override void Enter()
    {
        base.Enter();
        FireSlimeBossAI fireSlimeBossAI = (FireSlimeBossAI)GetAI();
        FireSlimeBoss fireSlimeBoss = (FireSlimeBoss)fireSlimeBossAI.getCharacter();
        GameObject myBody = fireSlimeBoss.GetGameObject();
        fireBomb = fireSlimeBoss.GetFireBall();
        isFire = false;
        currentPreperaTime = 0;
        currentRecoverTime = 0;
        Debug.Log("普攻");
    }

    public override void Exit()
    {
        base.Exit();
        GetAI().getCharacter().GetGameObject().GetComponent<SkillUnit>().ReSetCurrentSkillTime(0);
    }

    private float currentPreperaTime = 0;
    private float currentRecoverTime = 0;
    private bool isFire = false;
    public override State Update()
    { 
        FireSlimeBossAI fireSlimeBossAI = (FireSlimeBossAI)GetAI();
        FireSlimeBoss fireSlimeBoss = (FireSlimeBoss)fireSlimeBossAI.getCharacter();
        GameObject myBody = fireSlimeBoss.GetGameObject();

        if (currentPreperaTime < prepareTime)
        {
            currentPreperaTime += Time.deltaTime;
        }
        else
        {
            if (!isFire)
            {
                GameObject iFireBomb = Object.Instantiate(fireBomb, myBody.transform.position, Quaternion.identity);
                Vector3 dir = (fireSlimeBoss.currentTarget.transform.position - myBody.transform.position).normalized;
                Debug.DrawLine(myBody.transform.position, fireSlimeBoss.currentTarget.transform.position);
                iFireBomb.GetComponent<Rigidbody2D>().velocity = dir * fireSpeed * Time.deltaTime;
                isFire = true;
            }
            else
            {
                if (currentRecoverTime < recoverTime)
                {
                    currentRecoverTime += Time.deltaTime;
                }
                else
                {
                    return State.SUCESSED;
                }
            }
        }
        return State.RUNNING;
    }
}
