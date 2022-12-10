using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceSources : MonoBehaviour
{
    [SerializeField] BoundsInt area;
    public BoundsInt getArea()
    {
        // tra vef dien tich cua mouse follower
        return area;

    }

    public void setArea()
    {
        //  thiet lap  dien tich cho mouse follwer
        area.position = gridSystem._currentGridSystem.getLayOut().WorldToCell(this.transform.position);

    }

    public void placed()
    {

        gridSystem._currentGridSystem.takeArea(area);
    }
}
