using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class returnResource : stateBase
{
    UnitMove move;
    unitAnimator animator;
    Vector2 target;
    UnitState sate;
  
    LayerMask mask;
    int number;
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


        if (constructionPooling.Instance.returnNearestStorage(units.transform.position)==null)
        {

            units.UnitState.setStates(UnitState.unitState.idle);
            
        }
        else
        {
            units.Move.setTarget(constructionPooling.Instance.returnNearestStorage(units.transform.position).transform.position);

            target = units.Move.Target;
           
        }
    }

    public override void UpdateState(UnitFull units)
    {
        if (units.UnitState.getStates() != UnitState.unitState.returnResources)
        {
            EndState(units);
            return;

        }

        if (!units.Move.isMoveTarget(target,0.5f))
        {
            animator.parameter = unitAnimator.Parameter.isMove;
            animator.changeAnimation();
            return;

        }
        units.getSources.returnMaterial();

        units.UnitState.setStates(UnitState.unitState.getResources);
    }
}
