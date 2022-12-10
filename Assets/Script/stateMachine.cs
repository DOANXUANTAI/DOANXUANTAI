using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stateMachine : MonoBehaviour
{
    [field: SerializeField]
    stateBase _currentStates;
    idleState idle = new idleState() ;
    moveState move = new moveState() ;
    getRerouseState getResources = new getRerouseState();
    returnResource returnResource = new returnResource();
    unitAttackState atk = new unitAttackState();
    unitDieStates die = new unitDieStates();
    unitBuildingStates build = new unitBuildingStates();




    public void enterSates(UnitFull unit)
    {
        UnitState.unitState unitStates = unit.UnitState.getStates();
        // to enter or exit state
        switch (unitStates)
        {
            case UnitState.unitState.idle:
                _currentStates = idle;

                break;
            case UnitState.unitState.move:
                _currentStates = move;

                break;
            case UnitState.unitState.atk:
                _currentStates =atk;
                break;
            case UnitState.unitState.getResources:
                _currentStates = getResources;
                break;
            case UnitState.unitState.returnResources:
                _currentStates = returnResource;
                break;

            case UnitState.unitState.building:
                _currentStates = build ;
                break;
            default:
                _currentStates = die;
                break;

        }

        _currentStates.EnterState(unit);


    }    





    public void UpdateMachine(UnitFull units)
    {

        _currentStates.UpdateState(units);

    }


}
