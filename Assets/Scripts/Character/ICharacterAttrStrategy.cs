using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IC
{
    public abstract class ICharacterAttrStrategy
    {
        private ICharacterAttr myAttr;

        public void InitAttr(ICharacterAttr IAttr)
        {
            setAttr(IAttr);
        }

        public void setAttr(ICharacterAttr characterAttr)
        {
            myAttr = characterAttr;
        }
        public ICharacterAttr getAttr()
        {
            return myAttr;
        }

        //本身的攻击
        public float getAttack() {
            int i = Random.Range(0, 10);
            int Attack = 0;
            if (i <= 2) Attack = 1;
            if (i > 2 && i < 8) Attack = 0;
            if (i >= 8) Attack = -1;
            return getAttr().getAttack()+Attack;
        }

        //本身受到攻击
        public virtual void BeAttacked(Player Hiter)
        {
            if (Hiter != null)
            {
                DesHealth(Hiter.GetWeapon().GetAttack() + (int)AttachAtk());
                /*if (getAttr().getCharacter() is FireSlime)
                    Debug.Log(getAttr().getHealth());*/
            }
        }

        public void DesHealth(float damage)
        {
            getAttr().changHealth(-damage);
        }

        public void AddHealth(float extraHealth)
        {
            getAttr().changHealth(extraHealth);
        }

        //受到的攻击随机成正态分布
        float AttachAtk()
        {
            float i1 = Random.Range(-1, 1);
            float i2 = Random.Range(-1, 1);
            float i3 = Random.Range(-1, 1);
            return (i1 + i2 + i3);
        }
    }
}