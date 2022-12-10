using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class girdManager : MonoBehaviour
{

    

    [SerializeField] Tilemap _refab;
    [SerializeField] Transform _overlay;
    [SerializeField] overlayTile _refabBase;
     private static girdManager _instances;
     public static girdManager Instances => _instances;

    private Dictionary<Vector2Int, overlayTile> map = new Dictionary<Vector2Int, overlayTile>();
    public Dictionary<Vector2Int, overlayTile> Map => Instances.map;


    private void Awake()
    {
        _instances = this;
    }
    private void Start()
    {
        BoundsInt area = _refab.cellBounds;


        foreach (var item in area.allPositionsWithin)
        {


            var overlay =  Instantiate(_refabBase, item, Quaternion.identity, _overlay.transform);
            var celposition = _refab.GetCellCenterWorld(item);
            overlay.gridLocation = item;
            overlay.transform.position = celposition;
            map.Add(new Vector2Int( item.x , item.y ),overlay);
          

        }

        
    }

  
}
