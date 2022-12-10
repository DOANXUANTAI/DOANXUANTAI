using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class constructionPooling : MonoBehaviour
{
    
 

    private static constructionPooling _instance;
    public static constructionPooling Instance => _instance;


    [SerializeField] constructionFull _ConstructionRefab;


    [SerializeField] List<constructionFull> listConstruction = new List<constructionFull>();
    [SerializeField] List<constructionFull> theStorage = new List<constructionFull>();
    [field: SerializeField] public List<constructionFull> theHourse = new List<constructionFull>();

    [SerializeField]
    private ConstructionIO _ConstructionIO;
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





    public constructionFull child_bearing_unit( )
    {


    

        if (listConstruction.Count == 0)
        {

           

            constructionFull newUnit = Instantiate(_ConstructionRefab, this.transform);



            //newUnit.ConstructionReset();
          //  newUnit._construction_bearing.construction_child(_ConstructionIO);
        




            return newUnit;
        }

        foreach (var item in listConstruction)
        {

            if (item.gameObject.activeSelf)
                continue;

            item.gameObject.SetActive(true);
           // item.ConstructionReset();
            //item._construction_bearing.construction_child(_ConstructionIO);

           _ConstructionIO = null;
            return item;


        }

        constructionFull newUnit2 = Instantiate(_ConstructionRefab, this.transform);


  
       // newUnit2._construction_bearing.construction_child(_ConstructionIO);
       // newUnit2.ConstructionReset();
        listConstruction.Add(newUnit2);
        if (_ConstructionIO.isStorage && !_ConstructionIO.isUnit)
        {

            theStorage.Add(newUnit2);

        }
        else if(_ConstructionIO.isUnit && !_ConstructionIO.isStorage)


        {

            theHourse.Add(newUnit2);
        }
        _ConstructionIO = null;
        return newUnit2;

    }

   


    public constructionFull returnNearestStorage(Vector2 postion)
    {

        // tra ve vi tri cua kho co  khoang cach gan nhat
        if (theStorage.Count == 0)
            return null;
        float min = Vector2.Distance(theStorage[0].transform.position , postion );
        constructionFull newStorage = theStorage[0];


        for (int i = 0; i < theStorage.Count; i++)
        {
            if (Vector2.Distance(theStorage[i].transform.position, postion) < min)
            {
                min = Vector2.Distance(theStorage[i].transform.position, postion);
                newStorage = theStorage[i]; 
            }
        }

        return newStorage;
    }


    public void setConstructionIO(ConstructionIO construction)
    {


        _ConstructionIO = construction;
    }


    public List<constructionFull> reuturnListConstruction()
    {

        return listConstruction;

    }



    public void addConstructionToStorage(constructionFull construction)
    {

        // add the storage
        theStorage.Add(construction);

    }


    public void addHourse(constructionFull construction)
    {
        // add the hourse
        theHourse.Add(construction);



    }



    public constructionFull checkHourse()
    {

        // kiem tra xem nha nao con cho trong khong 


        if (theHourse.Count  <=0)
            return null;

        for (int i = 0; i < theHourse.Count; i++)
        {
           
            if (theHourse[i]._construction_with_unit.Is_Capacity < theHourse[i]._construction_with_unit.Capacity)
            {

                return theHourse[i];

            }

        }


        return null;

 

    }


    public void removeTheUnit(UnitFull units)
    {
        foreach (var hourse in theHourse)
        {

            hourse._construction_with_unit.removeTotheBuild(units);

        }


    }    
}
