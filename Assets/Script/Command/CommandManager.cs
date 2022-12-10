using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour
{    
    public Stack<IAction> historyAction = new Stack<IAction>();

    public Stack<IAction> undoCommand = new Stack<IAction>();
  


    public void OnExcuteCommand(IAction action)
    {
  
            for (int i = 0; i < historyAction.Count; i++)
            {
            historyAction.Pop().UndoCommand();

            }

       

       
        action.ExcutionCommand();
        historyAction.Push(action);

    }    

    public void UndoCommand()
    {

        if (historyAction.Count >0)
        {

            undoCommand.Push(historyAction.Peek());
            historyAction.Pop().UndoCommand();
        }    
    }    
}
