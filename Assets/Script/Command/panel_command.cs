using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panel_command : IAction
{
    Transform panel;
    public panel_command (Transform Panel)
    {


        this.panel = Panel;

    }
    public void ExcutionCommand()
    {
       
        panel.gameObject.SetActive(true);
    }

    public void UndoCommand()
    {
        panel.gameObject.SetActive(false);
    }
}
