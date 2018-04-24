using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;

public class RepeatGuideMagma_FireSlimeBoss : IState
{

    private GameObject fusedLaserBall;

    private float prepareTime = 1;
    private float range = 10;

    private float recoverTime = 0.5f;
    private float currentRecoverTime = 0;
    public override void Enter()
    {
        base.Enter();
        FireSlimeBossAI fireSlimeBossAI = (FireSlimeBossAI)GetAI();
        FireSlimeBoss fireSlimeBoss = (FireSlimeBoss)fireSlimeBossAI.getCharacter();
        fusedLaserBall = fireSlimeBoss.fusedLaserBall;
        currentRecoverTime = 0;
        currentPrepareTime = 0;
        isFire = false;
    }


    public override void Exit()
    {
        base.Exit();
        GetAI().getCharacter().GetGameObject().GetComponent<SkillUnit>().ReSetCurrentSkillTime(2);
    }

    private float currentPrepareTime = 0;
    private bool isFire = false;
    public override State Update()
    {
        if (currentPrepareTime < prepareTime)
        {
            currentPrepareTime += Time.deltaTime;
        }
        else
        {
            if (!isFire)
            {
                CreateFusedLaserBall();
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

    private void CreateFusedLaserBall()
    {
        float dx = 0;
        float dy = 0;
        GameObject iTarget;
        Vector3 pos = new Vector3();
        dx = Random.Range(-range, range);
        dy = Random.Range(-Mathf.Pow(range * range - dx * dx, 0.5f), Mathf.Pow(range * range - dx * dx, 0.5f));
        FireSlimeBossAI fireSlimeBossAI = (FireSlimeBossAI)GetAI();
        FireSlimeBoss fireSlimeBoss = (FireSlimeBoss)fireSlimeBossAI.getCharacter();
        GameObject myBody = fireSlimeBoss.GetGameObject();
        pos = myBody.transform.position + new Vector3(dx, dy);
        while (Physics2D.OverlapCircle(pos, 1, LayerMask.GetMask("FusedLaserBall")) != null)
        {
            dx = Random.Range(-range, range);
            dy = Random.Range(-Mathf.Pow(range * range - dx * dx, 0.5f), Mathf.Pow(range * range - dx * dx, 0.5f));
            pos = myBody.transform.position + new Vector3(dx, dy);
        }
        GameObject iFuserLaserBall = Object.Instantiate(fusedLaserBall, pos, Quaternion.identity);
    }
}
