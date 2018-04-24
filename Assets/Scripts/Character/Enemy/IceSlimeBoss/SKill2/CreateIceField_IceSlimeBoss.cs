using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;

public class CreateIceField_IceSlimeBoss : IState {
    private float range = 6;
    private int damage = 1;
    private float lastTime = 5;

    private GameObject iceBulletSkill2;
    public override void Enter()
    {
        base.Enter();
        IceSlimeBossAI iceSlimeBossAI = (IceSlimeBossAI)GetAI();
        IceSlimeBoss iceSlimeBoss = (IceSlimeBoss)iceSlimeBossAI.getCharacter();
        iceBulletSkill2 = iceSlimeBoss.IceBulletSkill2;
        i = 0;
        currentLastTime = 0;

    }

    public override void Exit()
    {
        base.Exit();
        GetAI().getCharacter().GetGameObject().GetComponent<SkillUnit>().ReSetCurrentSkillTime(1);
    }

    private float currentLastTime = 0;
    private float count = 0;
    private int iceBulletCount = 10;
    private int i = 0;
    public override State Update()
    {
        IceSlimeBossAI iceSlimeBossAI = (IceSlimeBossAI)GetAI();
        IceSlimeBoss iceSlimeBoss = (IceSlimeBoss)iceSlimeBossAI.getCharacter();
        GameObject myBody = iceSlimeBoss.GetGameObject();

        if (currentLastTime < lastTime)
        {
            if (count < 0.5f)
            {
                count += Time.deltaTime;
            }
            else
            {
                float angle = (360 / iceBulletCount) * i;
                float r = (Mathf.PI / 180) * angle;

                Vector2 pre = myBody.transform.up;
                Vector3 d = new Vector2(pre.x * Mathf.Cos(r) + pre.y * Mathf.Sin(r), -pre.x * Mathf.Sin(r) + pre.y * Mathf.Cos(r)).normalized;
                GameObject iceBullet = GameObject.Instantiate(iceBulletSkill2, myBody.transform.position, Quaternion.identity);
                iceBullet.transform.position = d * range + iceBullet.transform.position;
                iceBullet.GetComponent<Skill2IceBullet_IceSlimeBoss>().owner = iceSlimeBoss;
                count = 0;
                i++;
            }
            currentLastTime += Time.deltaTime;
        }
        else
        {
            return State.SUCESSED;
        }
        return State.RUNNING;
    }
}
