using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{


    [SerializeField] UnitSelection _unitSelection;

    float time = 0.5f;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            makeState(OnClick(position));
        }
        
    }



    public void makeState(RaycastHit2D hit)
    {

        // to change and have something command about unit 
        if ( hit.collider == null)
        {
            if (_unitSelection.listUnitSelection.Count==0)
                return;

            _unitSelection.setState(UnitState.unitState.move);
            Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _unitSelection.setTarget(newPosition);
   
       

        }


        if (hit.collider != null)
        {
            if (hit.collider.CompareTag(CONSTANT.unit))
            {


                _unitSelection.selectUnit(hit.collider.gameObject.GetComponent<UnitFull>());
               
                return;
            }

            if (_unitSelection.listUnitSelection.Count == 0)
                return;
            if(hit.collider.CompareTag(CONSTANT.sources))
            {


            

                // doan nay la lay tai nguy 
                _unitSelection.setTarget((Vector2)hit.collider.transform.position);
                _unitSelection.setState(UnitState.unitState.getResources);
                _unitSelection.setSource(hit.collider.gameObject.GetComponent<sourcesFull>());

             
             


        

                _unitSelection.deSelectAll();   
                return;
            }

            if (hit.collider.CompareTag(CONSTANT.enemy))
            {




                // doan nay la lay tai nguy 
                _unitSelection.setTarget((Vector2)hit.collider.transform.position);
                _unitSelection.setState(UnitState.unitState.atk);
              
                _unitSelection.deSelectAll();
                return;
            }


            if (hit.collider.CompareTag(CONSTANT.construction))
            {

                //  dieu khien dan xay


              

                if (hit.collider.gameObject.GetComponent<ConstructionFrame>()!= null)
                {
                    ConstructionFrame frame = hit.collider.gameObject.GetComponent<ConstructionFrame>();


                    _unitSelection.setTarget(frame.FrameConstructionBuildP.buildInPoint.transform.position);
                    _unitSelection.setFrame(frame);
                    _unitSelection.setState(UnitState.unitState.building);
                    _unitSelection.deSelectAll();

                    return;

                }



                _unitSelection.deSelectAll();
                return;
            }


        }    
     



    }    

    public RaycastHit2D OnClick(Vector2 mousePosition)
    {

        // kiem tra khi an xuong 
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.up,0.1f);




        return hit;



    }    

}
