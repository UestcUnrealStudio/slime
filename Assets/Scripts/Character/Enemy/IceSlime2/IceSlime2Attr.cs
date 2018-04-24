using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IC;
using IS;

public class IceSlime2Attr : ICharacterAttr {

    private float minDistance = 5;//最近攻击距离
    public void SetMinDistance(float minDistance)
    {
        this.minDistance = minDistance;
    }
    public float GetMinDistance()
    {
        return minDistance;
    }

    public IceSlime2Attr(float maxHealth, float attack, float moveSpeed, float fireRate, float attackRange, ICharacterAttrStrategy theAttrStrategy) : base(maxHealth, attack, moveSpeed, fireRate, attackRange, theAttrStrategy)
    {

    }
}
