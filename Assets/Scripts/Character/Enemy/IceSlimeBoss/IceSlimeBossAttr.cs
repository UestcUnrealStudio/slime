using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IC;
using IS;

public class IceSlimeBossAttr : ICharacterAttr {

    public IceSlimeBossAttr(float maxHealth, float attack, float moveSpeed, float fireRate, float attackRange, ICharacterAttrStrategy theAttrStrategy) : base(maxHealth, attack, moveSpeed, fireRate, attackRange, theAttrStrategy)
    {

    }
}
