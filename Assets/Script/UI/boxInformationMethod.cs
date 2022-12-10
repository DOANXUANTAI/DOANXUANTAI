using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boxInformationMethod : MonoBehaviour
{
   
    [SerializeField] Image _boxIMG;
    [SerializeField] Text _boxText;
    private Material.style _boxType;

    public void setBoxInformation(MaterialIO materialIO , string number)
    {

        // set data for box 
        _boxIMG.sprite = materialIO.IMG;
        _boxText.text = "X " + number;
        _boxType = materialIO.material.Style;
    }    

    public Material.style getBoxType()
    {


        // return box type
        return _boxType;

    }
}
