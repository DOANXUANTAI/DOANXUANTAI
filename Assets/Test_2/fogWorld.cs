using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class fogWorld : MonoBehaviour
{

    public static fogWorld _currentGridSystem;
    [SerializeField] GridLayout _gridLayout;
    [SerializeField] Tilemap _mainTile; 
    private static Dictionary<tileStyle, TileBase> listTileBase = new Dictionary<tileStyle, TileBase>();


    private void Awake()
    {

        _currentGridSystem = this;

        if (listTileBase.Count == 0)
        {

            listTileBase.Add(tileStyle.Empty, null);
            listTileBase.Add(tileStyle.Black, Resources.Load<TileBase>("black 1"));
  


        }


    }


    public GridLayout getLayOut ()
    {

        return _gridLayout;

    }    

    public void followBuilding(BoundsInt area)
    {


        TileBase[] baseArray = getTileBlock(area, _mainTile);

        int size = baseArray.Length;
        TileBase[] tileArray = new TileBase[size];
       

        FillBlock(tileArray,tileStyle.Empty);
      _mainTile.SetTilesBlock(area, tileArray);


    }


    public static TileBase[] getTileBlock(BoundsInt area, Tilemap tilemap)
    {
        TileBase[] arr = new TileBase[area.size.x * area.size.y * area.size.z];
        int count = 0;
        foreach (var x in area.allPositionsWithin)
        {
            Vector3Int pos = new Vector3Int(x.x, x.y, 0);
            arr[count] = tilemap.GetTile(pos);
            count = count + 1;
        }


        return arr;
    }

    public static void FillBlock(TileBase[] arr, tileStyle type)
    {

        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = listTileBase[type];
        }


    }

    public static void SetTilesBlocks(BoundsInt area, tileStyle type, Tilemap tileMap)
    {
        int size = area.size.x * area.size.y * area.size.z;
        TileBase[] tileArray = new TileBase[size];
        FillBlock(tileArray, type);

        tileMap.SetTilesBlock(area, tileArray);


    }


    public void clear(BoundsInt preveArea)
    {
        int size = preveArea.size.x * preveArea.size.y * preveArea.size.z;
        TileBase[] toClear = new TileBase[size];
        FillBlock(toClear, tileStyle.Black);
        _mainTile.SetTilesBlock(preveArea, toClear);


    }

}
