using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class stateBase 
{

  
    public abstract void EnterState(UnitFull units);
    public abstract void UpdateState(UnitFull units);
    public abstract void EndState(UnitFull units);


}
