using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unitDieStates : stateBase
{

    UnitMove move;
    unitAnimator animator;
   // Vector2 target;
    UnitState sate;
    float time;
    //LayerMask mask;
    //int number;
    public override void EndState(UnitFull units)
    {


  
    
        units.Machine.enterSates(units);
    }

    public override void EnterState(UnitFull units)
    {

        move = units.Move;
        animator = units.UnitAnimator;
      //  target = units.Move.Target;
        sate = units.UnitState;
        time = 3;
    }

    public override void UpdateState(UnitFull units)
    {
        if (units.UnitState.getStates() != UnitState.unitState.die)
        {
            EndState(units);
            return;

        }

        if (time >0)
        {

            animator.parameter = unitAnimator.Parameter.isDie;
            animator.changeAnimation();
            time = time - Time.deltaTime;
            return;
        }
        constructionPooling.Instance.removeTheUnit(units);

        units.gameObject.SetActive(false);


    }
}
