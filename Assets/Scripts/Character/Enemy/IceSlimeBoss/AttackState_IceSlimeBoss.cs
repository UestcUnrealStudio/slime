using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IC;
using IS;

public class AttackState_IceSlimeBoss : RandomSelectorNode
{
    public override void Enter()
    {
        if (childrenStates.Count == 0)
        {
            Skill4State_IceSlimeBoss skill4State = new Skill4State_IceSlimeBoss();
            Skill3State_IceSlimeBoss skill3State = new Skill3State_IceSlimeBoss();
            Skill2State_IceSlimeBoss skill2State = new Skill2State_IceSlimeBoss();
            Skill1State_IceSlimeBoss skill1State = new Skill1State_IceSlimeBoss();
            NormalAttackState_IceSlimeBoss normalAttackState = new NormalAttackState_IceSlimeBoss();
            skill4State.SetCharacterAI(GetAI());
            skill3State.SetCharacterAI(GetAI());
            skill2State.SetCharacterAI(GetAI());
            skill1State.SetCharacterAI(GetAI());
            normalAttackState.SetCharacterAI(GetAI());
            AddChild(skill4State);
            //AddChild(skill3State);
            AddChild(skill2State);
            //AddChild(skill1State);
            AddChild(normalAttackState);
        }
        base.Enter();
    }

    public override State Update()
    {
        return base.Update();
    }
}
