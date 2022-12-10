using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleState : stateBase
{
    public override void EndState(UnitFull units)
    {

        units.Machine.enterSates(units);
    }

    public override void EnterState(UnitFull units)
    {
        units.UnitAnimator.parameter = unitAnimator.Parameter.isIdle;
        units.UnitAnimator.changeAnimation();
    }

    public override void UpdateState(UnitFull units)
    {
        if (units.UnitState.getStates()!= UnitState.unitState.idle)
        {
            EndState(units);
            return;

        }

        if (units._checkAround.checkAround() == null)
            return;

        units.Move.setTarget(units._checkAround.checkAround().gameObject.transform.position);

        units.UnitState.setStates(UnitState.unitState.atk);

        
    }
}
