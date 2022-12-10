using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAttack : MonoBehaviour
{
    [SerializeField] Transform _hitPoint;
    [SerializeField] float _atkSpeed;
    [SerializeField] weapon _weapon;


    public bool toAttack()
    {

        if (_atkSpeed <=0)
        {

            return true;

        }



        _atkSpeed = _atkSpeed - Time.deltaTime;
        return false;

    }

    public void atk(Vector2 target)
    {
        // to attack

        if (!toAttack())
            return;
        _weapon.fire(target,_hitPoint , gameObject.GetComponent<UnitsCheckAround>()._layerMask);
        _atkSpeed = 3f;

    }

}
