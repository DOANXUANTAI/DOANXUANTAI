using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBuild : MonoBehaviour
{


    [field: SerializeField] public ConstructionFrame Frames { private set; get; }
    [field: SerializeField ] public float process { private set; get; }



    public void setFrame(ConstructionFrame Frame)
    {

        // set frame construction

        Frames = Frame;

    }


}
