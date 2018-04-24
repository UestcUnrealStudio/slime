using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IC;
using IS;

public class FireSlime1AI : CharacterAI {

    #region 所有状态
    private AttackState_FireSlime1 attackState;
    public void SetAttackState(AttackState_FireSlime1 attackState)
    {
        this.attackState = attackState;
    }
    public AttackState_FireSlime1 GetAttackState()
    {
        return attackState;
    }

    private ThrowMeltedBombState_FireSlime1 throwMeltedBombState;
    public void SetThrowMeltedBombState(ThrowMeltedBombState_FireSlime1 throwMeltedBombState)
    {
        this.throwMeltedBombState = throwMeltedBombState;
    }
    public ThrowMeltedBombState_FireSlime1 GetThrowMeltedBombState()
    {
        return throwMeltedBombState;
    }

    private ThrowMeltedBomb_FireSlime1 throwMeltedBomb;
    public void SetThrowMeltedBomb(ThrowMeltedBomb_FireSlime1 throwMeltedBomb)
    {
        this.throwMeltedBomb = throwMeltedBomb;
    }
    public ThrowMeltedBomb_FireSlime1 GetThrowMeltedBomb()
    {
        return throwMeltedBomb;
    }

    private MoveState_FireSlime1 moveState;
    public void SetMoveState(MoveState_FireSlime1 moveState)
    {
        this.moveState = moveState;
    }
    public MoveState_FireSlime1 GetMoveState()
    {
        return moveState;
    }

    private MoveToEnemyState_FireSlime1 moveToEnemyState;
    public void SetMoveToEnemyState(MoveToEnemyState_FireSlime1 moveToEnemyState)
    {
        this.moveToEnemyState = moveToEnemyState;
    }
    public MoveToEnemyState_FireSlime1 GetMoveToEnemyState()
    {
        return moveToEnemyState;
    }

    private MoveToEnemy_FireSlime1 moveToEnemy;
    public void SetMoveToEnemy(MoveToEnemy_FireSlime1 moveToEnemy)
    {
        this.moveToEnemy = moveToEnemy;
    }
    public MoveToEnemy_FireSlime1 GetMoveToEnemy()
    {
        return moveToEnemy;
    }

    private ConditionHaveEnemy_FireSlime1 conditionHaveEnemy;
    public void SetConditionHaveEnemy(ConditionHaveEnemy_FireSlime1 conditionHaveEnemy)
    {
        this.conditionHaveEnemy = conditionHaveEnemy;
    }
    public ConditionHaveEnemy_FireSlime1 GetConditionHaveEnemy()
    {
        return conditionHaveEnemy;
    }

    private DistanceCondition_FireSlime1 distanceCondition;
    public void SetDistanceCondition(DistanceCondition_FireSlime1 distanceCondition)
    {
        this.distanceCondition = distanceCondition;
    }
    public DistanceCondition_FireSlime1 GetDistanceCondition()
    {
        return distanceCondition;
    }
    #endregion
    private Selector root_Node;

    public FireSlime1AI():base()
    {
        SetMoveState(new MoveState_FireSlime1());
        moveState.SetCharacterAI(this);

        SetMoveToEnemyState(new MoveToEnemyState_FireSlime1());
        moveToEnemyState.SetCharacterAI(this);

        SetAttackState(new AttackState_FireSlime1());
        attackState.SetCharacterAI(this);

        SetThrowMeltedBombState(new ThrowMeltedBombState_FireSlime1());
        throwMeltedBombState.SetCharacterAI(this);

        SetMoveToEnemy(new MoveToEnemy_FireSlime1());
        moveToEnemy.SetCharacterAI(this);

        SetThrowMeltedBomb(new ThrowMeltedBomb_FireSlime1());
        throwMeltedBomb.SetCharacterAI(this);

        SetConditionHaveEnemy(new ConditionHaveEnemy_FireSlime1());
        conditionHaveEnemy.SetCharacterAI(this);

        SetDistanceCondition(new DistanceCondition_FireSlime1());
        distanceCondition.SetCharacterAI(this);

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
