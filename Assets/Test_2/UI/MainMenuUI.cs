using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] btn_function _btn;
    [SerializeField] List<btn_function> _listBtn;
    [SerializeField] Transform _pearent;


     // khoi tao
    public void MainMenu(string functionName)
    {


        // khoi tao MainMenu
        btn_function newBtn = Instantiate(_btn,_pearent);
        newBtn.setFunctionName("MainMenu");
        newBtn.setTextInfomation(functionName);
        newBtn.gameObject.SetActive(false);
        _listBtn.Add(newBtn);




    }


    public void BuildMenu(string functionName)
    {


        // khoi tao MenuBuid
        btn_function newBtn = Instantiate(_btn, _pearent);
        newBtn.setFunctionName("BuildMenu");
        newBtn.setTextInfomation(functionName);
        newBtn.gameObject.SetActive(false);

        _listBtn.Add(newBtn);

    }


    public void UnitMenu(string functionName)
    {


        // khoi tao Menu unit 
        btn_function newBtn = Instantiate(_btn, _pearent);
        newBtn.setFunctionName("UnitMenu");
        newBtn.setTextInfomation(functionName);
        newBtn.gameObject.SetActive(false);
        _listBtn.Add(newBtn);


    }

    // hien thi 
    public void resetMenu(string menuName)
    {
        // bat tat Menu unit
  
        foreach (var btn in _listBtn)
        {
      
             if (btn.StyleFunction.CompareTo(menuName) ==0)
            {
                if (!btn.gameObject.activeSelf)
                {


                    btn.gameObject.SetActive(true);
                }

                continue;
             }

            btn.gameObject.SetActive(false);


        }


    }



   public void addFunction(int indext ,UnityEngine.Events.UnityAction call )
    {

        // set function
        _listBtn[indext].addFunction(call);



    }    

}
