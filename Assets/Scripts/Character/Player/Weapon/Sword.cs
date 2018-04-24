using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IC;
using IS;

public class Sword : IWeapon
{
    private float currentTime;

    public Sword(float attack, float fireRate, float fireRange) : base(attack, fireRate, fireRange)
    {
        currentTime = fireRate;
    }

    public override void Attack()
    {
        if (currentTime >= fireRate)
        {
            base.Attack();
            currentTime = 0;
        }
        currentTime += Time.deltaTime;
    }
}
