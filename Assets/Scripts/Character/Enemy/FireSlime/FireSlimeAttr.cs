using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IC;
using IS;
public class FireSlimeAttr : ICharacterAttr
{
    public FireSlimeAttr(float maxHealth, float attack, float moveSpeed, float fireRate, float attackRange, ICharacterAttrStrategy theAttrStrategy) : base(maxHealth, attack, moveSpeed, fireRate, attackRange, theAttrStrategy)
    {

    }
}


