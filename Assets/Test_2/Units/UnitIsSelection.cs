using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitIsSelection : MonoBehaviour
{
    [SerializeField] SpriteRenderer _render;




    public void isSelect(bool val)
    {

        // to show is selection

        _render.enabled = val;

    }    
    
}
