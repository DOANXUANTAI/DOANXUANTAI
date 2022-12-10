using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_bearing : MonoBehaviour
{
    [field: SerializeField] public UnitIO  IO_UNIT{ private set; get; }

    [field: SerializeField] public SpriteRenderer _sprite;




    public void  unit_child(UnitIO untiIO)
    {
        // to sinh unit and have any action about sinh 
        _sprite.sprite = untiIO.IMG;

       


    }
    

}
