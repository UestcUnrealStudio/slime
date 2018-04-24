using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;

public class GatherEnergy_IceSlimeBoss : IState
{
    private float prepareTime = 3;
    private float range = 10;

    private GameObject IceBullet;
    private List<GameObject> IceBullets = new List<GameObject>();

    private float outSpeed = 300;

    public override void Enter()
    {
        base.Enter();
        IceSlimeBossAI iceSlimeBossAI = (IceSlimeBossAI)GetAI();
        IceSlimeBoss iceSlimeBoss = (IceSlimeBoss)iceSlimeBossAI.getCharacter();
        IceBullet = iceSlimeBoss.IceBulletSkill3;
        currentPrepareTime = 0;
        count = 0;
    }

    public override void Exit()
    {
        base.Exit();
        GetAI().getCharacter().GetGameObject().GetComponent<SkillUnit>().ReSetCurrentSkillTime(2);
    }
    private float currentPrepareTime = 0;
    private float count = 0;
    public override State Update()
    {
        IceSlimeBossAI iceSlimeBossAI = (IceSlimeBossAI)GetAI();
        IceSlimeBoss iceSlimeBoss = (IceSlimeBoss)iceSlimeBossAI.getCharacter();
        GameObject myBody = iceSlimeBoss.GetGameObject();

        if (currentPrepareTime < prepareTime)
        {
            currentPrepareTime += Time.deltaTime;
            if (count < 0.2f)
            {
                count += Time.deltaTime;
            }
            else
            {
                count = 0;
                CreateParticalIce();
            }
        }
        else
        {
            for (int i = 0; i < IceBullets.Count; i++)
            {
                if (IceBullets[i] == null)
                {
                    break;
                }
                Vector2 dir = -(myBody.transform.position - IceBullets[i].transform.position).normalized;
                IceBullets[i].GetComponent<Rigidbody2D>().velocity = dir * outSpeed * Time.deltaTime;
            }
            return State.SUCESSED;
        }
        return State.RUNNING;
    }

    private void CreateParticalIce()
    {
        IceSlimeBossAI iceSlimeBossAI = (IceSlimeBossAI)GetAI();
        IceSlimeBoss iceSlimeBoss = (IceSlimeBoss)iceSlimeBossAI.getCharacter();
        GameObject myBody = iceSlimeBoss.GetGameObject();

        float x = Random.Range(-range, range);
        float y = Random.Range(-Mathf.Pow(range * range - x * x, 0.5f), Mathf.Pow(range * range - x * x, 0.5f));
        Vector3 dir = new Vector3(x, y);
        GameObject iIceBullet;

        while (dir.magnitude < 3)
        {
            x = Random.Range(-range, range);
            y = Random.Range(-Mathf.Pow(range * range - x * x, 0.5f), Mathf.Pow(range * range - x * x, 0.5f));
            dir = new Vector3(x, y);
        }
        iIceBullet = Object.Instantiate(IceBullet, myBody.transform.position + dir, Quaternion.identity);
        //iIceBullet.GetComponent<IceBullet_IceSlimeBoss>().isBig = false;
        //iIceBullet.GetComponent<IceBullet_IceSlimeBoss>().lifeTime = prepareTime + 5;
        IceBullets.Add(iIceBullet);
    }
}
