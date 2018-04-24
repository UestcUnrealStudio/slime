using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IC;
using IS;

public class IceSlime1Attr : ICharacterAttr
{
    private float minDistance;
    public void SetMinDistance(float minDistance)
    {
        this.minDistance = minDistance;
    }
    public float GetMinDistance()
    {
        return minDistance;
    }
    public IceSlime1Attr(float maxHealth, float attack, float moveSpeed, float fireRate, float attackRange,float minDistance, ICharacterAttrStrategy theAttrStrategy) : base(maxHealth, attack, moveSpeed, fireRate, attackRange, theAttrStrategy)
    {
        SetMinDistance(minDistance);
    }
}
