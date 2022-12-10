using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitWithFogWorld : MonoBehaviour
{
    [SerializeField] BoundsInt area;

    private fogWorld _forworld;
    private void Awake()
    {
      //  _forworld = GameObject.FindGameObjectWithTag("Fog").GetComponent<fogWorld>();   
    }




    public void setArea()
    {

        //  thiet lap  dien tich cho mouse follwer
     //   area.position = _forworld.getLayOut().WorldToCell(this.transform.position);
      //  _forworld.followBuilding(area);
        
    }




}
