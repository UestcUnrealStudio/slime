using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IC;
using IS;

public class IceSlimeBossAI : CharacterAI {

    #region 所有状态
    private AttackState_IceSlimeBoss attackState;
    public void SetAttackState(AttackState_IceSlimeBoss attackState)
    {
        this.attackState = attackState;
    }
    public AttackState_IceSlimeBoss GetAttackState()
    {
        return attackState;
    }

    private MoveState_IceSlimeBoss moveState;
    public void SetMoveState(MoveState_IceSlimeBoss moveState)
    {
        this.moveState = moveState;
    }
    public MoveState_IceSlimeBoss GetMoveState()
    {
        return moveState;
    }

    private PassiveSkillState_IceSlimeBoss passiveSkillState;
    public void SetPassiveSkillState(PassiveSkillState_IceSlimeBoss passiveSkillState)
    {
        this.passiveSkillState = passiveSkillState;
    }
    public PassiveSkillState_IceSlimeBoss GetPassiveSkillState()
    {
        return passiveSkillState;
    }
    #endregion

    private Selector root_Node;
    public IceSlimeBossAI() : base()
    {
        SetAttackState(new AttackState_IceSlimeBoss());
        attackState.SetCharacterAI(this);
        SetMoveState(new MoveState_IceSlimeBoss());
        moveState.SetCharacterAI(this);
        SetPassiveSkillState(new PassiveSkillState_IceSlimeBoss());
        passiveSkillState.SetCharacterAI(this);

        root_Node = new Selector();
       // root_Node.AddChild(passiveSkillState);
        root_Node.AddChild(attackState);
        root_Node.AddChild(moveState);
    }

    public override void UpdateAI()
    {
        root_Node.Tick();
    }
}
