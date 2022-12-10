using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitsCheckAround : MonoBehaviour
{

    [SerializeField] float _radious;
    [field : SerializeField]  public LayerMask _layerMask { private set; get; }
   

    public Collider2D checkAround()
    {

        Collider2D col = Physics2D.OverlapCircle(this.transform.position, _radious, _layerMask);


        return col;

    }

    

  
}
