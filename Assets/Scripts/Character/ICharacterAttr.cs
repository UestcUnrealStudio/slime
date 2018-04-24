using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IC
{
    public abstract class ICharacterAttr
    {
        private float health;
        private float maxHealth;
        private float attack;
        private float moveSpeed;
        private float attackRate;
        private float attackRange;
        private ICharacterAttrStrategy myAttrStrategy = null;
        private ICharacter myCharacter = null;

        public ICharacterAttr(float maxHealth, float attack, float moveSpeed, float fireRate,float attackRange, ICharacterAttrStrategy theAttrStrategy)
        {
            setAttack(attack);
            SetAttrStrategy(theAttrStrategy);
            setAttackRate(fireRate);
            setMaxHealth(maxHealth);
            setSpeed(moveSpeed);
            setAttackRange(attackRange);

            myAttrStrategy.InitAttr(this);
            FullHp();
        }

        public void SetAttrStrategy(ICharacterAttrStrategy theAttrStrategy)
        {
            myAttrStrategy = theAttrStrategy;
        }
        public ICharacterAttrStrategy GetAttrStrategy() {
            return myAttrStrategy;
        }

        public void setCharacter(ICharacter c) {
            myCharacter = c;
        }
        public ICharacter getCharacter()
        {
            return myCharacter;
        }
        public float getHealth()
        {
            return health;
        }
        public void setHealth(float health)
        {
            this.health = health;
        }
        public float getMaxHealth()
        {
            return maxHealth;
        }
        public void setMaxHealth(float maxHealth)
        {
            this.maxHealth = maxHealth;
        }
        public float getAttack()
        {
            return attack;
        }
        public void setAttack(float attack)
        {
            this.attack = attack;
        }

        public float getSpeed()
        {
            return moveSpeed;
        }
        public void setSpeed(float moveSpeed)
        {
            this.moveSpeed = moveSpeed;
        }

        public float getAttackRate()
        {
            return attackRate;
        }
        public void setAttackRate(float fireRate)
        {
            this.attackRate = fireRate;
        }

        public float getAttackRange() {
            return this.attackRange;
        }
        public void setAttackRange(float attackRange) {
            this.attackRange = attackRange;
        }

        //计算受到的伤害量
        public void CalDmgValue(ICharacter Attacker)
        {
            float AtkValue = Attacker.GetAtkValue();
            health -= AtkValue;
        }

        //补满血
        public void FullHp()
        {
            health = maxHealth;
        }

        //改变血量
        public void changHealth(float extraHealth)
        {
            health += extraHealth;
        }
    }
}