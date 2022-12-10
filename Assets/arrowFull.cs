using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowFull : MonoBehaviour
{
    [field: SerializeField] public float MoveSpeed { private set; get; }
    [field : SerializeField] public int Damge { private set; get; }
    [field : SerializeField] private float timeLife;



    private void Update()
    {
        
        if (timeLife > 0)
        {
            timeLife = timeLife - Time.deltaTime;
            return;

        }

        this.gameObject.SetActive(false);
    }


    public void arrowReset( Vector2 dir)
    {
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(dir * MoveSpeed * Time.deltaTime);

        timeLife = 5;

    }    




}
