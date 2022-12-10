using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    [field: SerializeField] public float moveSpeed { private set; get; }
    [field: SerializeField] float timeLife ;
    [field: SerializeField] public float Damge { private set; get; }
  

    private void Update()
    {

        if (timeLife >0)
        {
            timeLife = timeLife - Time.deltaTime;
            return;

        }
        timeLife = 3;
        this.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        timeLife = 3;

    }
}
