using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MouseFollowMethod : MonoBehaviour
{

    [SerializeField] SpriteRenderer _constructrionIMG;
    [SerializeField] Button _right;
    [SerializeField] BoundsInt area;
    [SerializeField]
    private ConstructionIO _construction;
  


    public void moveMouse(Vector2 newPosition)
    {
        // di chuyen vi tri con tro chuot


        if (Vector2.Distance(this.transform.position, newPosition) < 1.9f)
            return;

        Vector3Int cellTouch = gridSystem._currentGridSystem.getLayOut().LocalToCell(newPosition);
        Debug.Log(cellTouch);
        this.transform.localPosition = gridSystem._currentGridSystem.getLayOut().CellToLocalInterpolated(cellTouch);





    }


    public void setMouseFollowerData(ConstructionIO construction)
    {



        _constructrionIMG.sprite = construction.Construction_IMG;
        _construction = construction;
        _right.onClick.AddListener(()=> buildingConstruction());

    
       

    }



    public void buildingConstruction()
    {




        // thuc hien hanh dong xay dung khi click vao button tick
        if (!gridSystem._currentGridSystem.checkBuild(area))

            return;
        
        constructionPooling.Instance.setConstructionIO(_construction);
        ConstructionFrame newConstruction = frameConstructionPooling.Instance.child_bearing_unit();
        constructionFull newConstructionFull = constructionPooling.Instance.child_bearing_unit();
        
        newConstructionFull.setArea(area);
        newConstruction.transform.position = this.transform.position;
        newConstructionFull.transform.position = this.transform.position;
        if(_construction.isStorage)
        {
            constructionPooling.Instance.addConstructionToStorage(newConstructionFull);

        }
        
           
        newConstructionFull.gameObject.SetActive(false);
        newConstruction.pushConstructionIO(_construction, newConstructionFull);

     

        gridSystem._currentGridSystem.takeArea(area);

        this.gameObject.SetActive(false);

    }


    public void setArea()
    {
        //  thiet lap  dien tich cho mouse follwer
        area.position = gridSystem._currentGridSystem.getLayOut().WorldToCell(this.transform.position);

    }

    public BoundsInt getArea()
    {
        // tra vef dien tich cua mouse follower
        return area;

    }




    public void turnOff()
    {
        this.gameObject.SetActive(false);


    }    
   




    public void buildBuilding()
    {
        constructionPooling.Instance.setConstructionIO(_construction);
     
    }


    private void OnDisable()
    {


        _right.onClick.RemoveAllListeners();

    }
}
