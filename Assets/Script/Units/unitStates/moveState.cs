using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveState : stateBase
{
    UnitMove move;
    unitAnimator animator;
    Vector2 target;
    UnitState sate;
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

        if (units.UnitState.getStates() != UnitState.unitState.move)
        {
            EndState(units);
            return;


        }
        
        if (target!= units.Move.Target)
        {

            EndState(units);
            return;

        }


        if (!move.isMoveTarget(target))
        {
            animator.parameter = unitAnimator.Parameter.isMove;
            animator.changeAnimation();

            return;
        }


        sate.setStates(UnitState.unitState.idle);

    }
}
