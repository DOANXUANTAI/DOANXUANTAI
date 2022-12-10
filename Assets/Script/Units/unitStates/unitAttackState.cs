using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unitAttackState : stateBase
{
    UnitMove move;
    unitAnimator animator;
    Vector2 target;
    UnitState sate;

    LayerMask mask;
    //int number;
    public override void EndState(UnitFull units)
    {
        units.Machine.enterSates(units);
    }

    public override void EnterState(UnitFull units)
    {
        move = units.Move;
        animator = units.UnitAnimator;
        target = units.Move.Target;
        sate = units.UnitState;

       



    }

    public override void UpdateState(UnitFull units)
    {
        if (units.UnitState.getStates() != UnitState.unitState.atk)
        {
            EndState(units);
            return;

        }

        if (!move.isMoveTarget(target, 6f))
        {
            animator.parameter = unitAnimator.Parameter.isMove;
            animator.changeAnimation();
            return;


        }
        if (units._checkAround.checkAround()==null)
        {

            sate.setStates(UnitState.unitState.idle);
            return;

        }



        if (!units._unitAttack.toAttack())
        {
            animator.parameter = unitAnimator.Parameter.isIdle;
            animator.changeAnimation();
            return;
        }

        Vector2 newTarget = units._checkAround.checkAround().transform.position;

        animator.parameter = unitAnimator.Parameter.isAttack;
        animator.changeAnimation();
        units._unitAttack.atk(newTarget);

    
    }
}
