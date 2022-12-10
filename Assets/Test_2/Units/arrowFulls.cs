using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowFulls : MonoBehaviour
{

    [SerializeField] float _moveSpeed;
    [SerializeField] float _timeLife;
    [field: SerializeField] public int  Damage { private set; get; }





    private void Update()
    {
        if (_timeLife > 0)
        {
            _timeLife = _timeLife - Time.deltaTime;
            return;
        }
        this.gameObject.SetActive(false);
    }


    public float getSpeed()
    {

        return _moveSpeed;

    }
    public void  arrowReset()
    {
        _timeLife = 4f;



    }

  

}
