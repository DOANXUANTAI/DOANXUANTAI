using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    float time = 0.5f;


    private void Awake()
    {

        time = 0.5f;
    
    }

    // Update is called once per frame
    void Update()
    {

        if (time  >0)
        {
            time = time - Time.deltaTime;
            return;

        }
        this.gameObject.SetActive(false);
      
        
    }
}
