using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btn_function : MonoBehaviour
{

    [SerializeField] Text _functionName;
    [SerializeField] Image _image;

    [SerializeField] Button _btn;
    [field: SerializeField]
    public string StyleFunction { private set; get; }
  


    public void setTextInfomation(string Function_Name , Sprite img =null )
    {

        if (img == null)
        {

            _image.enabled = false;
        }
        else
        {
            _image.enabled = true;
            _image.sprite = img;
            

        }
        // set infomation mation for unit
        _functionName.text = Function_Name;
       

    }


    public void addFunction(UnityEngine.Events.UnityAction events)
    {


        // add fuction
        _btn.onClick.AddListener(events);

    }


    public void setFunctionName(string name )
    {

        // set name forfunction
        StyleFunction = name;

    }


}
