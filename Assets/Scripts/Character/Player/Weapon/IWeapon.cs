using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IC;
using IS;

public abstract class IWeapon {
    protected float attack;
    protected float fireRate;
    protected float fireRange;
    protected Player owner;
    protected Texture gunTexture;

    public IWeapon(float attack,float fireRate,float fireRange)
    {
        SetAttack(attack);
        SetFireRange(fireRange);
        SetFireRate(fireRate);
    }

    public void SetAttack(float attack)
    {
        this.attack = attack;
    }
    public float GetAttack()
    {
        return attack;
    }

    public void SetFireRate(float fireRate)
    {
        this.fireRate = fireRate;
    }
    public float getFireRate()
    {
        return fireRate;
    }

    public void SetFireRange(float fireRange)
    {
        this.fireRange = fireRange;
    }
    public float GetFireRange()
    {
        return fireRange;
    }

    public void SetOwner(Player owner)
    {
        this.owner = owner;
    }
    public Player GetOwner()
    {
        return owner;
    }

    public void SetTexture(Texture myTexture)
    {
        this.gunTexture = myTexture;
    }
    public Texture GetTexture()
    {
        return gunTexture;
    }

    public virtual void Attack()
    {
        Debug.Log("攻击");
    }
}
