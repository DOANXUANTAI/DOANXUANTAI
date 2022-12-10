using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frameConstructionPooling : MonoBehaviour
{

    private static  frameConstructionPooling  _instance;
    public static  frameConstructionPooling  Instance => _instance;


    [SerializeField] ConstructionFrame _ConstructionRefab;


    [SerializeField] List<ConstructionFrame> listConstruction = new List<ConstructionFrame>();


    [SerializeField]

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

    }





 
   


    public ConstructionFrame child_bearing_unit()
    {
       



        if (listConstruction.Count == 0)
        {



            ConstructionFrame newUnit = Instantiate(_ConstructionRefab, this.transform);

            listConstruction.Add(newUnit);



          //  _ConstructionIO = null;

            return newUnit;
        }

        foreach (var item in listConstruction)
        {

            if (item.gameObject.activeSelf)
                continue;

            item.gameObject.SetActive(true);
            item.resetFrames();
            //item._construction_bearing.construction_child(_ConstructionIO);


            return item;


        }

        ConstructionFrame newUnit2 = Instantiate(_ConstructionRefab, this.transform);


        listConstruction.Add(newUnit2);

        // newUnit2._construction_bearing.construction_child(_ConstructionIO);
        // newUnit2.ConstructionReset();


        //_ConstructionIO = null;
        return newUnit2;

    }



}
