using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IC;
using IS;

public class AttackState_FireSlimeBoss : RandomSelectorNode
{

    public override void Enter()
    {
        FireSlimeBossAI fireSlimeBossAI = (FireSlimeBossAI)GetAI();
        FireSlimeBoss fireSlimeBoss = (FireSlimeBoss)fireSlimeBossAI.getCharacter();
        GameObject myBody = fireSlimeBoss.GetGameObject();

        if (childrenStates.Count==0)
        {
           
            Skill1State_FireSlimeBoss skill1State = new Skill1State_FireSlimeBoss();
            Skill2State_FireSlimeBoss skill2State = new Skill2State_FireSlimeBoss();
            Skill3State_FireSlimeBoss skill3State = new Skill3State_FireSlimeBoss();
            NormalAttackState_FireSlimeBoss normalAttackState = new NormalAttackState_FireSlimeBoss();

            skill1State.SetCharacterAI(GetAI());
            skill2State.SetCharacterAI(GetAI());
            skill3State.SetCharacterAI(GetAI());
            normalAttackState.SetCharacterAI(GetAI());

            AddChild(skill3State);
            AddChild(skill2State);
            AddChild(skill1State);
            AddChild(normalAttackState);
        }
        Debug.Log("进入攻击状态");
        base.Enter();
    }

    public override State Update()
    {
        return base.Update();
    }
}
