using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class constructionFull : MonoBehaviour
{

    [SerializeField] UnitHP _unitHp;
    float time = 4;

    [field: SerializeField] public construction_bearing _construction_bearing { private set; get; }
    [field: SerializeField] public constructionWithUnit _construction_with_unit { private set; get; }
    [field: SerializeField] public BoundsInt  Area { private set; get; }


    private void Update()
    {

        if (!_unitHp.checkHealthBar())
            return;

        if (time >0 )
        {

            time = time - Time.deltaTime;
            return;

        }


       
        _unitHp.offOnHealth(false);

    }

    public void ConstructionReset(int maxHP)
    {
        // set origontail unit 

      
        _unitHp.setMaxHP( maxHP);


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
           if (!collision.collider.CompareTag(CONSTANT.arrow))
                return;
        _unitHp.offOnHealth(true);
        time = 4;
        _unitHp.getHP(collision.collider.GetComponent<arrowFulls>().Damage);

    
      
        collision.gameObject.SetActive(false);

        if (_unitHp.getHP(0)==0)
        {

            this.gameObject.SetActive(false);
            gameManager.Instances.checkConstruction();
        }


    }






    public void setArea(BoundsInt area)
    {

        Area = area;

    }

}
