using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMove : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    [SerializeField] Transform _transform;
    [field:SerializeField] public Vector2 Target { private set; get; }
    



    public bool isMoveTarget(Vector2 target , float distance = .1f)
    {

        // move target
        Vector2 dir =(Vector2) this.transform.position - target;
        dir.Normalize();
        if (dir.x * _transform.transform.localScale.x >0)
        {
            _transform.transform.localScale = new Vector3(-_transform.transform.localScale.x, _transform.transform.localScale.y, _transform.transform.localScale.z);


        }


        if (Vector2.Distance(this.transform.position , target)>distance)
        {


            this.transform.position = Vector2.MoveTowards(this.transform.position , target , Time.deltaTime * _moveSpeed);
            return false;

        }


        return true;
    }


    public void setTarget(Vector2 target)
    {

        Target = target;
    }

}
