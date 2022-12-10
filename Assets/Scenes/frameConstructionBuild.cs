using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class frameConstructionBuild : MonoBehaviour
{
    [field : SerializeField] public List<Image> listImg { private set; get; }
    [field : SerializeField] public Transform buildInPoint { private set; get; }
    [field : SerializeField] public Transform BuidPoint { private set; get; }
    [field : SerializeField] public GameObject Exclamation { private set; get; }
    [field : SerializeField] public List<UnitFull>ListUnit { private set; get; }



    // cho unit vo  lay unit ra bat tat cham than
   

    public bool fullFillConstruction(UnitFull unitAdd)
    {
        // add unit vao trong list
        if (ListUnit.Count == listImg.Count)
            return false;

        ListUnit.Add(unitAdd);

        for (int i = 0; i < ListUnit.Count; i++)
        {
            listImg[i].color = Color.red;
        }
        onOffExclamation(false);
        return true;
    }

    public bool popUnit(UnitFull unitAdd)
    {



        // add unit vao trong list
     
        if (!ListUnit.Contains(unitAdd)|| ListUnit.Count == 0)
            return false;
        int indext = ListUnit.IndexOf(unitAdd);
        ListUnit.Remove(unitAdd);

        listImg[indext].color = Color.black;
        if (ListUnit.Count ==0)
        {
            onOffExclamation(true);

        }
        return true;

    }


    

    private void onOffExclamation(bool val)
    {

        // bat tat cham than
        Exclamation.SetActive(val);


    }









}
