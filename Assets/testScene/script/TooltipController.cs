using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipController : MonoBehaviour
{


    public static TooltipController current;
    public ToolTIp toolTip;
    private void Awake()
    {
        current = this;
    }


    public static void show(string content , string header = "")
    {

        current.toolTip.setText(content,header);
        current.toolTip.gameObject.SetActive(true);


    }
    public static void hide()
    {
        current.toolTip.gameObject.SetActive(false);


    }
}
