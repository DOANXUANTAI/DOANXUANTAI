using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class gridSystem : MonoBehaviour
{

    public static gridSystem _currentGridSystem;
    [SerializeField] GridLayout _gridLayout;
    [SerializeField] Tilemap _tempTile;
    [SerializeField] Tilemap _mainTile;
    private static Dictionary<tileStyle, TileBase> listTileBase = new Dictionary<tileStyle, TileBase>();
   
 
    

    void Start()
    {


        if (listTileBase.Count ==0)
        {
            listTileBase.Add(tileStyle.Empty, null);
            listTileBase.Add(tileStyle.White, Resources.Load<TileBase>("white"));
            listTileBase.Add(tileStyle.Red, Resources.Load<TileBase>("red"));
            listTileBase.Add(tileStyle.Green, Resources.Load<TileBase>("green"));
            _currentGridSystem = this;

        }
       
   
        this.gameObject.SetActive(false);
        
    }


    public static TileBase[] getTileBlock(BoundsInt area , Tilemap tilemap)
    {
        TileBase[] arr = new TileBase[area.size.x * area.size.y * area.size.z];
        int count = 0;
        foreach (var x in area.allPositionsWithin)
        {
            Vector3Int pos = new Vector3Int(x.x,x.y,0);
            arr[count] = tilemap.GetTile(pos);
            count = count + 1;
        }


        return arr;
    }

    public static void FillBlock(TileBase[] arr , tileStyle type )
    {

        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = listTileBase[type];
        }


    }

    public static void SetTilesBlocks(BoundsInt area, tileStyle type , Tilemap tileMap)
    {
        int size = area.size.x * area.size.y * area.size.z;
        TileBase[] tileArray = new TileBase[size];
        FillBlock(tileArray,type);

        tileMap.SetTilesBlock(area,tileArray);


    }


    public void clear(BoundsInt preveArea)
    {   
        int size = preveArea.size.x * preveArea.size.y * preveArea.size.z;
        TileBase[] toClear = new TileBase[size] ;
        FillBlock(toClear,tileStyle.Empty);
        _tempTile.SetTilesBlock(preveArea, toClear);


    }    
    

    public void followBuilding(BoundsInt area)
    {

      
        TileBase[] baseArray = getTileBlock(area, _mainTile);
        
        int size = baseArray.Length;
        TileBase[] tileArray = new TileBase[size];
        for (int i = 0; i < baseArray.Length; i++)
        {

          

            if (baseArray[i] ==listTileBase[tileStyle.White])
            {


                tileArray[i] = listTileBase[tileStyle.Green];
              
            }
            else
            {
             

                FillBlock(tileArray,tileStyle.Red);

            }
        }
        _tempTile.SetTilesBlock(area,tileArray);


    }    


    public GridLayout getLayOut()
    {

        // layout

        return _gridLayout;

    }


    public bool checkBuild(BoundsInt area)
    {

        TileBase[] arr = getTileBlock(area,_mainTile);


        foreach (var tile in arr)
        {

            if (tile != listTileBase[tileStyle.White])
                return false;

        }


        return true;

    }


    public void takeArea(BoundsInt area)
    {
        SetTilesBlocks(area,tileStyle.Green,_mainTile);
        SetTilesBlocks(area,tileStyle.Empty,_tempTile);


    }

  
}


public enum tileStyle
{
    Empty , 
    White ,
    Green ,
    Red,
    Black,



}
