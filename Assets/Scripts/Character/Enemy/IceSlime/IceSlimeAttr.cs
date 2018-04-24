using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;
using IC;

public class IceSlimeAttr : ICharacterAttr {

    public IceSlimeAttr(float maxHealth, float attack, float moveSpeed, float fireRate, float attackRange, ICharacterAttrStrategy theAttrStrategy) : base(maxHealth, attack, moveSpeed, fireRate, attackRange, theAttrStrategy)
    {

    }
}
