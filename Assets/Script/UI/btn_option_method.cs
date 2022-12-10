using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btn_option_method : MonoBehaviour
{
    [SerializeField] Text _optionText;
    [SerializeField] Button _btn;

    public void setData(string function_name)
    {

        // set data for option button
        _optionText.text = function_name;

    }    

    public void setFunction(UnityEngine.Events.UnityAction call)
    {
        // set action for option button
        _btn.onClick.AddListener(call);

      


    }

   
}
