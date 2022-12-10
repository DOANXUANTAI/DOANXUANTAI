using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[ExecuteInEditMode()]

public class ToolTIp : MonoBehaviour
{

    [SerializeField] Text _header;
    [SerializeField] Text _discritpion;
    [SerializeField] LayoutElement _toolTip;
    [SerializeField] int cheractorLimit;
    [SerializeField] RectTransform rectranform;




    public void setText(string content , string header = "")
    {
        if (string.IsNullOrEmpty(header))
        {
            _header.gameObject.SetActive(false);

        }
        else
        {

            _header.gameObject.SetActive(true);
            _header.text = header;
        }
        _discritpion.text = content;
        int headerLength = _header.text.Length;
        int contentLength = _discritpion.text.Length;
        _toolTip.enabled = (headerLength > cheractorLimit || contentLength > cheractorLimit) ? true : false;


    }
    private void Update()
    {
        if (Application.isEditor)
        {
            int headerLength = _header.text.Length;
            int contentLength = _discritpion.text.Length;
            _toolTip.enabled = (headerLength > cheractorLimit || contentLength > cheractorLimit) ? true : false;

        }

        Vector2 position = Input.mousePosition;
        float pivotx = position.x / Screen.width;
        float pivotY = position.x / Screen.height;

        rectranform.pivot = new Vector2(pivotx,pivotY);
        transform.position = position;
    }
}
