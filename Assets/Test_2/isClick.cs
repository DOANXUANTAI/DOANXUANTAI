using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class isClick : MonoBehaviour ,IPointerClickHandler , IPointerExitHandler
{
    [SerializeField] SpriteRenderer _render;

    public void OnPointerClick(PointerEventData eventData)
    {
        _render.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _render.enabled = false;
    }
}
