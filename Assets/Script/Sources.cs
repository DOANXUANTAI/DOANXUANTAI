using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sources : MonoBehaviour
{
    [SerializeField] BoundsInt area;
    [SerializeField] MaterialIO _materialIO;
    [field: SerializeField] public int numberMaterial { private set; get; } = 120;
    private void Awake()
    {
        StartCoroutine(waitToTakeUnit());
        StartCoroutine(waitoDestroy());
    }


    public MaterialIO returnMaterial()
    {

        return _materialIO;

    }    



    public int returnMaterial( int material )
    {


        // tra material ve
        if (numberMaterial < material)
        {

            int again = numberMaterial;
            numberMaterial = numberMaterial - again;

            return again;

        }

        numberMaterial = numberMaterial - material;
        return material;
    
    }


    // to take area on the 
    IEnumerator waitToTakeUnit()
    {

        yield return new WaitUntil(() => gridSystem._currentGridSystem != null);


        Vector3Int cellTouch = gridSystem._currentGridSystem.getLayOut().LocalToCell(this.transform.position);
        this.transform.localPosition = gridSystem._currentGridSystem.getLayOut().CellToLocalInterpolated(cellTouch);
        area.position = gridSystem._currentGridSystem.getLayOut().WorldToCell(this.transform.position -new Vector3(0,0.5f,0));
        gridSystem._currentGridSystem.takeArea(area);

    }

    IEnumerator waitoDestroy()
    {

        yield return new WaitUntil(()=>numberMaterial <=0);
        this.gameObject.SetActive(false);


    }    
}
