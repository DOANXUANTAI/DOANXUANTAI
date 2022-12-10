using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class constructionWithUnit : MonoBehaviour
{
    [field: SerializeField] public bool IsUnit { private set; get; }
    [field: SerializeField] public int Capacity { private set; get; }
    [field: SerializeField] public int Is_Capacity { private set; get; }
    [field: SerializeField] public Transform UnitChild { private set; get; }
    private List<UnitFull> listUnit = new List<UnitFull>();



    public bool checkUnit()
    {


        //check
        if (!IsUnit || Is_Capacity >= Capacity)
            return false;

        return true;

    }


    public  void itIsUnit(bool val)
    {
        // to set up the construction have unit 
        IsUnit = val;
    }

    public void setCappacity(int number)
    {
        Capacity = number;

    }

    public void addUnit(UnitFull unit)
    {
        // them unit vao trong construction
        listUnit.Add(unit);
        Is_Capacity = Is_Capacity + 1;

    }


    public void removeTotheBuild(UnitFull unit)
    {


        if (listUnit.Contains(unit))
        {

            listUnit.Remove(unit);
            Is_Capacity = Is_Capacity - 1;

        }
    }
}
