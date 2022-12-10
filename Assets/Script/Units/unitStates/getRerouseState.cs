using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getRerouseState : stateBase
{
    UnitMove move;
    unitAnimator animator;
    Vector2 target;
    UnitState sate;
    float time = 0;
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


        if (units.getSources.Source != null)
        {

            if (!units.getSources.Source.gameObject.activeSelf)
            {

                units.UnitState.setStates(UnitState.unitState.idle);

            }
            else
            {


                units.Move.setTarget(units.getSources.Source.transform.position);
                target = units.Move.Target;
            }

     
        }
      
         
         
        

        if (units.getSources.isCapacity >0)
        {

            units.UnitState.setStates(UnitState.unitState.returnResources);

        }

        mask = LayerMask.GetMask(CONSTANT.theSources);
        time = 0;
        number = 0;

    }

    public override void UpdateState(UnitFull units)
    {
       
         if (units.UnitState.getStates() != UnitState.unitState.getResources)
            {
                EndState(units);
                return;

            }



         if (!move.isMoveTarget(target,0.8f))
        {

            animator.parameter = unitAnimator.Parameter.isMove;
            animator.changeAnimation();
            return;
        }

         if (units.getSources.material == null)
        {
            Collider2D col = Physics2D.OverlapCircle(units.transform.position, 1.5f, mask);
            sourcesFull source = col.transform.gameObject.GetComponent<sourcesFull>();
            units.getSources.setSources(source);
            units.getSources.setMaterial(source._matrial);
            if (source._unitHP._HP > units.getSources.Capacity)
            {
                number = units.getSources.Capacity;

            }   
            else
            {
                number = source._unitHP._HP;

            }
          

        }


       

   

        if (time < number)
        {

            time = time + Time.deltaTime;

           

            animator.parameter = unitAnimator.Parameter.isUseExe;
            animator.changeAnimation();

            return;

        }

        units.getSources.addMaterial(number);
        units.getSources.Source._unitHP.getHP(number);

        units.UnitState.setStates(UnitState.unitState.returnResources);







        

    }
}
