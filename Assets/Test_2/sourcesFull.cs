using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sourcesFull : MonoBehaviour
{
   
    [field:SerializeField] public MaterialIO _matrial { private set; get; }
    [field:SerializeField] public UnitHP _unitHP { private set; get; }
    [field:SerializeField] public PlaceSources PlaceSources { private set; get; }




    private void Awake()
    {
        resetSources();
    }




    public void resetSources()
    {
        _unitHP.setMaxHP(200);

        StartCoroutine(takeArean());

    }

    IEnumerator takeArean()
    {


        yield return new WaitUntil(() => gridSystem._currentGridSystem != null);

        PlaceSources.setArea();
        PlaceSources.placed();
            
    }

}
