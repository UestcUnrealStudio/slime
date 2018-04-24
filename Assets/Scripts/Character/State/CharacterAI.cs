using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IC;

namespace IS
{
    public abstract class CharacterAI
    {
        private IState myState = null;
        public virtual void SetState(IState state)
        {
            myState = state;
            myState.SetCharacterAI(this);
        }
        public IState getState()
        {
            return myState;
        }

        private ICharacter myCharacter = null;
        public ICharacter getCharacter()
        {
            return myCharacter;
        }
        public void setCharacter(ICharacter c)
        {
            myCharacter = c;
        }

        public CharacterAI()
        {
           
        }

        public virtual void Init(IState state) {
            SetState(state);
        }
        
        public virtual void UpdateAI() {
            myState.Update();
        }
    }
}