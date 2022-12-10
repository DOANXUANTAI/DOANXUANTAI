using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class tooltipTrigger : MonoBehaviour, IPointerClickHandler
{

    [SerializeField] SpriteRenderer _target;

    private string _header = "";
    private string _content;
    public void OnPointerClick(PointerEventData eventData)
    {
       // toolTipSystem.show(_header, _content);
        if (_target == null)
            return;
        if (_target.enabled)
        {

            _target.enabled = false;
            return;

        }
        _target.enabled = true;
        return;
    }

    public void setInformaton(string header ="" , string tempt="")
    {
         // to set up the information
        _header = header;
        _content = tempt;
    }

    public  void setTempContent(string tempt = "")
    {
        _content = tempt;



    }

}
