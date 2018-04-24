using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IC;

namespace IS
{
    public enum State
    {
        SUCESSED,
        RUNNING,
        FAILED,
        NONE
    }

    public abstract class IState
    {
        private CharacterAI myAI = null;
        protected IState pNode;
        protected List<IState> childrenStates = new List<IState>();

        public void SetCharacterAI(CharacterAI characterAI)
        {
            myAI = characterAI;
        }
        public CharacterAI GetAI()
        {
            return myAI;
        }

        public State currentState;

        public IState()
        {
            currentState = State.NONE;
        }

        public virtual void Enter()
        {
            
        }
        public virtual void Exit()
        {
          
        }
        public virtual State Update() {
            return State.SUCESSED;
        }

        public State Tick()
        {
            if (currentState == State.NONE)
            {
                Enter();
                currentState = State.RUNNING;
            }
            State state = Update();
           
            if (state != State.RUNNING)
            {
                Exit();
                currentState = State.NONE;
            }
            return state;
        }

        public void AddChild(IState childState)
        {
            childrenStates.Add(childState);
        }
        public void RemoveChild(int index)
        {
            childrenStates.Remove(childrenStates[index]);
        }
    }
}
