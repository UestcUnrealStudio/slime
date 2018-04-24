using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IC;
using IS;

public class FireSlimeBossAI : CharacterAI
{
    #region 所有状态
    private ConditionHaveEnemy_FireSlimeBoss conditionHaveEnemy;
    public void SetConditionHaveEnemy(ConditionHaveEnemy_FireSlimeBoss conditionHaveEnemy)
    {
        this.conditionHaveEnemy = conditionHaveEnemy;
    }
    public ConditionHaveEnemy_FireSlimeBoss GetConditionHaveEnemy()
    {
        return conditionHaveEnemy;
    }

    private DistanceCondition_FireSlimeBoss distanceCondition;
    public void SetDistanceCondition(DistanceCondition_FireSlimeBoss distanceCondition)
    {
        this.distanceCondition = distanceCondition;
    }
    public DistanceCondition_FireSlimeBoss GetDistanceCondition()
    {
        return distanceCondition;
    }

    private MoveState_FireSlimeBoss moveState;
    public void SetMoveState(MoveState_FireSlimeBoss moveState)
    {
        this.moveState = moveState;
    }
    public MoveState_FireSlimeBoss GetMoveState()
    {
        return moveState;
    }

    private MoveToEnemyState_FireSlimeBoss moveToEnemyState;
    public void SetMoveToEnemyState(MoveToEnemyState_FireSlimeBoss moveToEnemyState)
    {
        this.moveToEnemyState = moveToEnemyState;
    }
    public MoveToEnemyState_FireSlimeBoss GetMoveToEnemyState()
    {
        return moveToEnemyState;
    }

    private MoveToEnemy_FireSlimeBoss moveToEnemy;
    public void SetMoveToEnemy(MoveToEnemy_FireSlimeBoss moveToEnemy)
    {
        this.moveToEnemy = moveToEnemy;
    }
    public MoveToEnemy_FireSlimeBoss GetMoveToEnemy()
    {
        return moveToEnemy;
    }

    private AttackState_FireSlimeBoss attackState;
    public void SetAttackState(AttackState_FireSlimeBoss attackState)
    {
        this.attackState = attackState;
    }
    public AttackState_FireSlimeBoss GetAttackState()
    {
        return attackState;
    }

    public NormalAttackState_FireSlimeBoss normalAttackState;
    public void SetNormalAttackState(NormalAttackState_FireSlimeBoss normalAttackState)
    {
        this.normalAttackState = normalAttackState;
    }
    public NormalAttackState_FireSlimeBoss GetNormalAttackState()
    {
        return normalAttackState;
    }

    private Skill1State_FireSlimeBoss skill1State;
    public void SetSkill1State(Skill1State_FireSlimeBoss skill1State)
    {
        this.skill1State = skill1State;
    }
    public Skill1State_FireSlimeBoss GetSkill1State()
    {
        return skill1State;
    }

    private Skill2State_FireSlimeBoss skill2State;
    public void SetSkill2State(Skill2State_FireSlimeBoss skill2State)
    {
        this.skill2State = skill2State;
    }
    public Skill2State_FireSlimeBoss GetSkill2State()
    {
        return skill2State;
    }

    private Skill3State_FireSlimeBoss skill3State;
    public void SetSkill3State(Skill3State_FireSlimeBoss skill3State)
    {
        this.skill3State = skill3State;
    }
    public Skill3State_FireSlimeBoss GetSkill3State()
    {
        return skill3State;
    }
    #endregion

    private Selector root_Node;
    private List<IState> childrenState = new List<IState>();
    public FireSlimeBossAI() : base()
    {
        SetConditionHaveEnemy(new ConditionHaveEnemy_FireSlimeBoss());
        conditionHaveEnemy.SetCharacterAI(this);

        SetDistanceCondition(new DistanceCondition_FireSlimeBoss());
        distanceCondition.SetCharacterAI(this);

        SetMoveState(new MoveState_FireSlimeBoss());
        moveState.SetCharacterAI(this);

        SetMoveToEnemyState(new MoveToEnemyState_FireSlimeBoss());
        moveToEnemyState.SetCharacterAI(this);

        SetMoveToEnemy(new MoveToEnemy_FireSlimeBoss());
        moveToEnemy.SetCharacterAI(this);

        SetAttackState(new AttackState_FireSlimeBoss());
        attackState.SetCharacterAI(this);

        SetSkill1State(new Skill1State_FireSlimeBoss());
        skill1State.SetCharacterAI(this);

        SetSkill2State(new Skill2State_FireSlimeBoss());
        skill2State.SetCharacterAI(this);

        SetSkill3State(new Skill3State_FireSlimeBoss());
        skill3State.SetCharacterAI(this);

        SetNormalAttackState(new NormalAttackState_FireSlimeBoss());
        normalAttackState.SetCharacterAI(this);

        root_Node = new Selector();
        root_Node.AddChild(attackState);
        root_Node.AddChild(moveState);
        root_Node.currentState = State.NONE;
    }

    public override void UpdateAI()
    {
        root_Node.Tick();
    }
}
