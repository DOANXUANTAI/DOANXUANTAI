using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelection : MonoBehaviour
{
    [field : SerializeField] public List<UnitFull> listUnitSelection { private set; get; }
  




    public void selectUnit(UnitFull unitAdd)
    {
        // select UnitFulls 




      if (listUnitSelection.Contains(unitAdd))
        {
            deSelectAll();
            return;
        }


        unitAdd.UnitSelection.isSelect(true);
        listUnitSelection.Add(unitAdd);


    }    



    public void deSelectAll()
    {
        // to remove all list


        for (int i = 0; i < listUnitSelection.Count; i++)
        {


            listUnitSelection[i].UnitSelection.isSelect(false);
        }
         listUnitSelection.Clear();

    }

    public void setState(UnitState.unitState states)
    {


        // thiet lap sate cho UnitFulls 
        foreach (var item in listUnitSelection)
        {
            item.UnitState.setStates(states);

        }

    }

    public void setTarget(Vector2 position)
    {
        // thiet lap  position cho UnitFulls 
        foreach (var item in listUnitSelection)
        {
            item.Move.setTarget(position);

        }
    }


    public void setSource(sourcesFull _source)
    {

        foreach (var item in listUnitSelection)
        {

            item.getSources.setSources(_source);

        }

    }    

    public void setFrame(ConstructionFrame construction)
    {
        foreach (var item in listUnitSelection)
        {

            item.UnitBuild.setFrame(construction);

        }



    }

}
