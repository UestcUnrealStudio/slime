using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;

public class GuideMagma_FireSlimeBoss : IState {

    private GameObject theEjectedMagma;//喷出的岩浆
    private GameObject target;

    private float laveLastTime = 3;
    private float prepareTime = 1;
    private float lastTime = 5;
    private float range = 10;

    public override void Enter()
    {
        base.Enter();
        FireSlimeBossAI fireSlimeBossAI = (FireSlimeBossAI)GetAI();
        FireSlimeBoss fireSlimeBoss = (FireSlimeBoss)fireSlimeBossAI.getCharacter();
        theEjectedMagma = fireSlimeBoss.GetTheEjectedMagma();
        target = fireSlimeBoss.target;
        currentLastTime = 0;
        currentPrepareTime = 0;
        count = 0;
        Debug.Log("进入skill2");
    }

    private float currentLastTime = 0;
    private float currentPrepareTime = 0;
    private float count = 0;
    public override void Exit()
    {
        base.Exit();
        GetAI().getCharacter().GetGameObject().GetComponent<SkillUnit>().ReSetCurrentSkillTime(1);
    }

    public override State Update()
    {
        if (currentPrepareTime < prepareTime)
        {
            currentPrepareTime += Time.deltaTime;
        }
        else
        {
            if (currentLastTime < lastTime)
            {
                JetSlush();
                currentLastTime += Time.deltaTime;
            }
            else
            {
                return State.SUCESSED;
            }
        }
        return State.RUNNING;
    }

    private bool canFire = false;
    private GameObject iTarget;
    private void JetSlush()
    {
        float dx = 0;
        float dy = 0;
        
        Vector3 pos = new Vector3();
        if (!canFire)
        {
            dx = Random.Range(-range, range);
            dy = Random.Range(-Mathf.Pow(range * range - dx * dx, 0.5f), Mathf.Pow(range * range - dx * dx, 0.5f));
            FireSlimeBossAI fireSlimeBossAI = (FireSlimeBossAI)GetAI();
            FireSlimeBoss fireSlimeBoss = (FireSlimeBoss)fireSlimeBossAI.getCharacter();
            GameObject myBody = fireSlimeBoss.GetGameObject();
            pos = myBody.transform.position + new Vector3(dx, dy);
            while (Physics2D.OverlapCircle(pos, 1, LayerMask.GetMask("MoltenLava")) != null || Physics2D.OverlapCircle(pos, 1, LayerMask.GetMask("Magma")) != null)
            {
                dx = Random.Range(-range, range);
                dy = Random.Range(-Mathf.Pow(range * range - dx * dx, 0.5f), Mathf.Pow(range * range - dx * dx, 0.5f));
                pos = myBody.transform.position + new Vector3(dx, dy);
            }
            canFire = true;
        }
        else
        {
            if (count < 1)
            {
                count += Time.deltaTime;
                iTarget = Object.Instantiate(target, new Vector3(dx, dy), Quaternion.identity);
            }
            else
            {
                Object.Destroy(iTarget);
                GameObject iLava = Object.Instantiate(theEjectedMagma, pos, Quaternion.identity);
                count = 0;
                canFire = false;
            }
        }
    }
}
