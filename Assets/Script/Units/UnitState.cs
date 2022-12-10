using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitState : MonoBehaviour
{
   

    public enum unitState {  idle , move ,getResources , returnResources , atk , die  , building}
    public unitState Unit_States;


    public void setStates(unitState states)
    {
        // set state cho unit 
        Unit_States = states;

    }


    public unitState getStates()
    {

        // tra ve trang thai cua unit 
        return  Unit_States;

    }
}
