using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class construction_bearing : MonoBehaviour
{


    [field: SerializeField] public    ConstructionIO IO_Construction { private set; get; }


    [field: SerializeField] public SpriteRenderer _sprite { private set; get; }




    public void construction_child(ConstructionIO ConstructionIO)
    {
        // to sinh unit and have any action about sinh 
        _sprite.sprite = ConstructionIO.Construction_IMG;




    }


}
