using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuController : MonoBehaviour
{


    private static menuController _instance;
    public static menuController Instance => _instance;
    [SerializeField] CommandManager _command;
    [SerializeField] MainMenuUI _menu;
    [SerializeField] PanelDIscription _panelDiscription;
    [field: SerializeField] public HeaderControll Head;
    [SerializeField] List<UnitIO> listUnitIO;
    [SerializeField] List<ConstructionIO> listConstructionIO;
    [field: SerializeField] public GameObject _notificationPanel { private set; get; }


    private void Awake()
    {

        if (_instance != this && _instance != null)
        {

            Destroy(this);

        }    else
        {
            _instance = this;

        }    

   


    }

   public void MenuCreate()
    {
        _menu.MainMenu("Xây dựng");
        _menu.addFunction(0, () =>
        {


            _menu.resetMenu("BuildMenu");


        });
        _menu.MainMenu("Dân");
        _menu.addFunction(1, () =>
        {


            _menu.resetMenu("UnitMenu");


        });


        _menu.UnitMenu("Vô danh");
        _menu.addFunction(2, () =>
        {


            _command.OnExcuteCommand(new panel_command(_panelDiscription.transform));
            _panelDiscription.setUnitDiscritpion(listUnitIO[0]);

        });


        _menu.BuildMenu("Nhà dân");
        _menu.addFunction(3, () =>
        {


            _command.OnExcuteCommand(new panel_command(_panelDiscription.transform));
            _panelDiscription.setConstructionDiscritpion(listConstructionIO[0]);


        });
        _menu.BuildMenu("Nhà kho");

        _menu.addFunction(4, () =>
        {


            _command.OnExcuteCommand(new panel_command(_panelDiscription.transform));
            _panelDiscription.setConstructionDiscritpion(listConstructionIO[1]);

        });
    }

    public void resetMenu(string menuName)
    {

       

        _menu.resetMenu(menuName);
    }    







    public void PanelOnOff(Transform panel)
    {
        if (panel.gameObject.activeSelf)
        {
            _command.UndoCommand();

            return;
        }

        _command.OnExcuteCommand(new panel_command(panel));


    }

     

    
   

    public void quitGame()
    {

        Application.Quit();

    }


    public void notification(bool val)
    {

        // bat tat thong bao
        _notificationPanel.gameObject.SetActive(val);

    }    
}
