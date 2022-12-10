using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box_solution : MonoBehaviour
{

    [SerializeField] Image _boxIMG;
    [SerializeField] Text _boxText;

    public string Box_Name { private set; get; }

    private void Awake()
    {

        _boxText.text = "X ";
    }


    public void setBoxInfomtaion(Sprite img, string text , string boxName="")
    {

        // set infomation fo box
       

        _boxIMG.sprite = img;
        ChangeBoxValues(text);

        Box_Name = boxName;
    }
  


    public void ChangeBoxValues( string text)
    {
         if (text.Contains("x") || text.Contains("X"))
        {
            text = text.Replace(text.Contains("x") ? "x" : "X", " ");


        }
        _boxText.text = "X " + text;
    }
}
