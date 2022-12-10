using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetResources : MonoBehaviour
{

   [field:  SerializeField] public sourcesFull Source { private set; get; }

   public int Capacity => 6;
    [field: SerializeField] public int isCapacity { private set; get; } = 0;
    [field: SerializeField] public MaterialIO material { private set; get; }





    public void setSources(sourcesFull sources)
    {

        // set up sources

        Source = sources;
       

    }    


    public void setMaterial(MaterialIO Material)
    {
        material = Material;


    }
    public void addMaterial(int number)
    {
      

            isCapacity = number;
  


    }

    public void ResetMaterial()
    {

        // reset material
        isCapacity = 0;

    }


    public void returnMaterial()
    {

        gameManager.Instances.storage.addMaterial(isCapacity,material);
        foreach (var item in gameManager.Instances.storage.returnList())
        {


            menuController.Instance.Head.changeValues(item.Key, item.Value.ToString());


        }

        isCapacity = 0; material = null;
    }

}
