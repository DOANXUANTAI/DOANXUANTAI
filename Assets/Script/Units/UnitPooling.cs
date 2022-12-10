using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPooling : MonoBehaviour
{

    private static UnitPooling _instance;
    public static UnitPooling Instance => _instance;


    [SerializeField] UnitFull  _unitRefab;


    [SerializeField] List<UnitFull > listUnit = new List<UnitFull >();
    private Vector2 startPosition = Vector2.zero;
    [SerializeField]
    private UnitIO _unitIO;
    private void Awake()
    {
        
        if (_instance != null && _instance != this)
        {
            Destroy(this);

        }
        else
        {

            _instance = this;

        }

        if (transform.childCount !=0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {

                 // load chid
                listUnit.Add(transform.GetChild(i).GetComponent<UnitFull>());

            }

        }

    }



    #region unit method 

    public UnitFull  child_bearing_unit()
    {
        if (listUnit.Count == 0)
        {

            UnitFull  newUnit = Instantiate(_unitRefab, this.transform);
            newUnit.transform.position = startPosition;

     
            listUnit.Add(newUnit);

        
            return newUnit;
        }

        foreach (var item in listUnit)
        {

         //   if (item.activeSelf)
         
        }

        UnitFull  newUnit2 = Instantiate(_unitRefab, this.transform);
        newUnit2.transform.position = startPosition;

        listUnit.Add(newUnit2);
        return newUnit2;

    }    






    
    #endregion
   
}
