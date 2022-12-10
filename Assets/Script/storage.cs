using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class storage : MonoBehaviour
{

    [SerializeField] ListMaterialIO _listMaterial;
    private static Dictionary<MaterialIO, int> allMaterial = new Dictionary<MaterialIO, int>();
    

   
   public void InitialStorage(int number =10)
    {

        if (allMaterial.Count==0)
        {
            // khoi tao nha kho 
            for (int i = 0; i < _listMaterial.listMaterialIO.Count; i++)
            {

                allMaterial.Add(_listMaterial.listMaterialIO[i], number);
            }

        }
       
    }



    public Dictionary<MaterialIO, int> returnList()
    {
        // lay ra danh sach nguyen lieu 
        return allMaterial;

    }

    public int returnMaterialNumber(MaterialIO materialIO)
    {

       
        // lay ra so luong cua vat lieu cu the 
        return allMaterial[materialIO];


    }

    public void addMaterial(int number , MaterialIO materialIO)
    {

        // the vat lieu 
        allMaterial[materialIO] = allMaterial[materialIO] + number;

    }
    
    public void returnMaterial (List<MaterialIO> listMaterialIO , List<int> ListNumber)
    {




        // to return the material 
        for (int i = 0; i < listMaterialIO.Count; i++)
        {
            if (allMaterial.ContainsKey(listMaterialIO[i]))
            {

                allMaterial[listMaterialIO[i]] = allMaterial[listMaterialIO[i]] - ListNumber[i];


            }
        }

    

    }    



    public bool checkMaterial(List<MaterialIO> listMaterialIO, List<int> ListNumber)
    {
        //  kiem tra xem co du nguyen lieu hay khong 
        for (int i = 0; i < listMaterialIO.Count; i++)
        {
            if (allMaterial.ContainsKey(listMaterialIO[i]))
            {
                if (allMaterial[listMaterialIO[i]] < ListNumber[i])
                {

                    return false;

                }    
     

            }
        }


        return true;
    }    
}
