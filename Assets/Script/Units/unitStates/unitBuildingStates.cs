using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unitBuildingStates : stateBase
{

    UnitMove move;
    unitAnimator animator;
    Vector2 target;
    UnitState sate;
  // UnitBuild build;
   // LayerMask mask;
    float number;
    ConstructionFrame frames;
    bool isOut;
    int time;
    float buildSpeed;
    public override void EndState(UnitFull units)
    {
        if (menuController.Instance._notificationPanel)
        {
            menuController.Instance.notification(false);


        }
        frames.FrameConstructionBuildP.popUnit(units);
        frames.buildDone();
        units.UnitBuild.setFrame(null);
        units.Machine.enterSates(units);
    }

    public override void EnterState(UnitFull units)
    {
        move = units.Move;
        animator = units.UnitAnimator;
        target = units.Move.Target;
        sate = units.UnitState;
        frames = units.UnitBuild.Frames;
        isOut = true;
        number = 0;
        time = 0;
        buildSpeed =1.5f;

        //  mask = LayerMask.GetMask(CONSTANT.construction);
    }

    public override void UpdateState(UnitFull units)
    {
        if (units.UnitState.getStates() != UnitState.unitState.building)
        {
            EndState(units);
            return;

        }

       

        if ( isOut)
        {
            if (!move.isMoveTarget(target, 0))
            {


                animator.parameter = unitAnimator.Parameter.isMove;
                animator.changeAnimation();
                    return;
               
            }
            if (time != 0)
            {


                sate.setStates(UnitState.unitState.idle);

                return;
            }

            if (!frames.FrameConstructionBuildP.fullFillConstruction(units))
            {

                sate.setStates(UnitState.unitState.idle);

                return;


            }
           // frames.FrameConstructionBuildP.fullFillConstruction(units);


                isOut = false;
           
         
        }
        if (!move.isMoveTarget(frames.transform.position, 0.3f))
        {
            animator.parameter = unitAnimator.Parameter.isMove;
            animator.changeAnimation();
            return;


        }

        if (!frames.controllerTakeMaterial())
        {
            animator.parameter = unitAnimator.Parameter.isIdle;
            animator.changeAnimation();
            if (!menuController.Instance._notificationPanel.activeSelf)
            {
                menuController.Instance.notification(true);


            }
            return;

        }

        if (menuController.Instance._notificationPanel)
        {
            menuController.Instance.notification(false);


        }


        if (number <1)
        {

            animator.parameter = unitAnimator.Parameter.isMining;
       
            animator.changeAnimation();
            number = number + Time.deltaTime * buildSpeed;
            return;


        }

        if (frames.addHP((int)number))
        {

            gameManager.Instances.updateStorage(frames._constructionIO.ListMaterial , frames._constructionIO.listMaterial_Number);
            isOut = true;
            time = 1;
            return;
        }
        number = 0;

    }
}
