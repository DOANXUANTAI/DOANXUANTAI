using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Header : MonoBehaviour
{

    private List<boxInformationMethod> List_box = new List<boxInformationMethod>();
 

  

    #region phuong thuc khoi tao header
    public void Header_First_Start(boxInformationMethod refabBox , MaterialIO material)
    {

        // set information in the first started
        boxInformationMethod newBox = Instantiate(refabBox,this.transform);
        newBox.setBoxInformation(material,"0");
        List_box.Add(newBox);
      


    }    

    public void Header_Change_Values(MaterialIO material , string Number)
    {

   
        // change values of header
        for(int i =0; i < List_box.Count;i++)
        {
            if (material.material.Style == List_box[i].getBoxType())
            {
                List_box[i].setBoxInformation(material,Number);
                return;

            }
        }
       


    }
    #endregion

    


  

}
