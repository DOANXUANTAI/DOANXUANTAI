using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{


    public void fire(Vector2 target , Transform hitPoint , LayerMask layer)
    {
        Vector2 dir = target - (Vector2)this.transform.position;
        dir.Normalize();
        // GameObject arrow = arrowPooling.Instance.child_bearing_unit();
        //arrow.gameObject.SetActive(true);

        arrowFulls arrow = arrowPooling.Instance.child_bearing_arrow();

        arrow.gameObject.SetActive(true);
        arrow.arrowReset();
        arrow.gameObject.transform.position = hitPoint.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
      

           arrow.transform.rotation = Quaternion.Euler(0f, 0f, angle);
        //   float speed = arrow.gameObject.GetComponent<arrow>().moveSpeed;
        //    arrow.GetComponent<Rigidbody2D>().velocity = dir *speed *Time.deltaTime ;


 
            float power = arrow.getSpeed() ;



     
     
        if (layer == LayerMask.GetMask(CONSTANT.unit))
        {

            int LayerIgnoreRaycast = LayerMask.NameToLayer(CONSTANT.enemyArrow);
            arrow.gameObject.layer = LayerIgnoreRaycast;

        }    
        else
        {

            int LayerIgnoreRaycast = LayerMask.NameToLayer(CONSTANT.unitArrow);
            arrow.gameObject.layer = LayerIgnoreRaycast;


        }    
      
       arrow.GetComponent<Rigidbody2D>().velocity = new Vector2 (dir.x , dir.y) *power;
       
       

        

    }
}
