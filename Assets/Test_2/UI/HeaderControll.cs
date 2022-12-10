using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeaderControll : MonoBehaviour
{

    [SerializeField] Box_solution BoxSolution;
    [SerializeField] Transform _parent;
    [SerializeField] ListMaterialIO _list;
    [SerializeField] List<Box_solution> listBoxSolution = new List<Box_solution>();



    
    public void onReady()
    {

        for (int i = 0; i < _list.listMaterialIO.Count; i++)
        {

            Box_solution newBox = Instantiate(BoxSolution, _parent);
            newBox.setBoxInfomtaion(_list.listMaterialIO[i].IMG, "X ", _list.listMaterialIO[i].material.Style.ToString());
            listBoxSolution.Add(newBox);
        }


      


    }


    public void changeValues(  MaterialIO material, string number)
    {

        // change values of box


   
        for (int i = 0; i < listBoxSolution.Count; i++)
        {

            if (listBoxSolution[i].Box_Name == material.material.Style.ToString())
            {
                listBoxSolution[i].ChangeBoxValues(number);


            }
  
        }

    }

}
