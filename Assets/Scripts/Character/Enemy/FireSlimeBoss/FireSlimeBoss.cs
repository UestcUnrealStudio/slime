using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IC;
using IS;

public class FireSlimeBoss : ICharacter
{
    private GameObject fire;//普通攻击的火焰
    public void SetFire(GameObject fire)
    {
        this.fire = fire;
    }
    public GameObject GetFire()
    {
        return fire;
    }

    private GameObject shield;//被动的护盾
    public void SetShield(GameObject shield)
    {
        this.shield = shield;
    }
    public GameObject GetShield()
    {
        return shield;
    }

    private GameObject fireBall;//技能一的火球
    public void SetFireBall(GameObject fireBall)
    {
        this.fireBall = fireBall;
    }
    public GameObject GetFireBall()
    {
        return fireBall;
    }

    private GameObject moltenLava;//残留的熔浆
    public void SetMoltenLava(GameObject moltenLava)
    {
        this.moltenLava = moltenLava;
    }
    public GameObject GetMoltenLava()
    {
        return moltenLava;
    }

    private GameObject theEjectedMagma;//喷出来的熔浆
    public void SetTheEjectedMagma(GameObject theEjectedMagma)
    {
        this.theEjectedMagma = theEjectedMagma;
    }
    public GameObject GetTheEjectedMagma()
    {
        return theEjectedMagma;
    }

    private GameObject meltedBomb;
    public void SetMeltedBomb(GameObject meltedBomb)
    {
        this.meltedBomb = meltedBomb;
    }
    public GameObject GetMeltedBomb()
    {
        return meltedBomb;
    }

    public GameObject fusedLaserBall;

    public GameObject target;
    //冷却时间
    private float shieldCoolTime = 5;//护盾冷却时间
    private float shieldLastTime = 5;//护盾持续时间

    public float[] coolTimes = new float[3] { 5, 10, 10 };
    public float[] currentCoolTimes = new float[3] { 0, 0, 0};

    public Collider2D[] targets;
    public Collider2D currentTarget;//所要攻击的目标

    public FireSlimeBoss(GameObject myBody, CharacterAI AI, ICharacterAttr attr) : base(myBody, AI, attr)
    {
        myBody.GetComponent<FSlimeBossBody>().SetCharacter(this);
    }

    public override void Update()
    {
        base.Update();
        Debug.Log("生命:" + getAttr().getHealth());
        UpdateFireShield();
        UpdateSkillTime();
        if (currentTarget != null && GetGameObject() != null)
        {
            Vector3 dir = (currentTarget.transform.position - GetGameObject().transform.position).normalized;
            if (dir.x > 0)
            {
                GetGameObject().GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                GetGameObject().GetComponent<SpriteRenderer>().flipX = false;
            }
        }
    }

    public override void UnderAttack(Player player)
    {
        base.UnderAttack(player);
    }

    private float currentShieldCoolTime = 0;
    private float currentShieldLastTime = 0;
    private void UpdateFireShield()
    {
        if (shield == null)
        {
            return;
        }
        if (currentShieldCoolTime < shieldCoolTime)
        {
            currentShieldCoolTime += Time.deltaTime;
            shield.SetActive(false);
        }
        else
        {
            if (currentShieldLastTime < shieldLastTime && shield.GetComponent<FireShield>().GetHealth() > 0)
            {
                shield.SetActive(true);
            }
            else
            {
                shield.SetActive(false);
                currentShieldCoolTime = 0;
                currentShieldLastTime = 0;
            }
        }
    }

    void UpdateSkillTime()
    {
        for (int i = 0; i < coolTimes.Length; i++)
        {
            if (currentCoolTimes[i] < coolTimes[i])
            {
                currentCoolTimes[i] += Time.deltaTime;
            }
            else
            {
                currentCoolTimes[i] = coolTimes[i];
            }
        }
    }

    public void ResetSkillTime(int skillNumber)
    {
        currentCoolTimes[skillNumber] = 0;
    }

    public bool CheckSkillTime(int skillNumber)
    {
        if (currentCoolTimes[skillNumber] < coolTimes[skillNumber])
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
