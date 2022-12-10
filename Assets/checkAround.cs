using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkAround : MonoBehaviour
{
    [SerializeField] float _radious;
    [SerializeField] LayerMask _layerMask;





    public Collider2D check()
    {
        Collider2D col = Physics2D.OverlapCircle(this.transform.position,_radious,_layerMask);

        return col;

    }
}
