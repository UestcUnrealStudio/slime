using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;
using IC;

public class FireSlime2Attr : ICharacterAttr
{
    public FireSlime2Attr(float maxHealth, float attack, float moveSpeed, float fireRate, float attackRange, ICharacterAttrStrategy theAttrStrategy) : base(maxHealth, attack, moveSpeed, fireRate, attackRange, theAttrStrategy)
    {
    }
}
