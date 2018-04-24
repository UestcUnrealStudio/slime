using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IS;

namespace IC
{
    public abstract class ICharacter {
        private ICharacterAttr myAttr = null;
        private CharacterAI myAI = null;
        private GameObject myBody = null;

        public ICharacter(GameObject myBody,CharacterAI AI,ICharacterAttr attr) {
            AI.setCharacter(this);
            attr.setCharacter(this);
            SetGameObject(myBody);
            setAttr(attr);
            SetAI(AI);
        }

        public GameObject GetGameObject()
        {
            return myBody;
        }
        public void SetGameObject(GameObject gameObject)
        {
            myBody = gameObject;
        }

        public virtual void Update()
        {
            if (myBody == null || myBody.activeInHierarchy == false)
            {
                return;
            }
            UpdateAI();
        }
        public void SetAI(CharacterAI ai) {
            myAI = ai;
        }
        public CharacterAI getAI() {
            return myAI;
        }

        public ICharacterAttr getAttr()
        {
            return myAttr;
        }
        public void setAttr(ICharacterAttr characterAttr)
        {
            myAttr = characterAttr;
        }


        public void UpdateAI() {
            myAI.UpdateAI();
        }
        public virtual float GetAtkValue() {
            return 0;
        }

        public virtual void UnderAttack(Player player)
        {
            getAttr().GetAttrStrategy().BeAttacked(player);
        }

    }
} 