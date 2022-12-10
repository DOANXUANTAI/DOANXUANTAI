using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class overlayTile : MonoBehaviour
{
    public int G;
    public int H;
    public int F => G+H;
    public bool isBlocked;
    public overlayTile previous;
    public Vector3Int gridLocation;




}
