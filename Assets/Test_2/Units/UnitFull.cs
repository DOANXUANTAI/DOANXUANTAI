using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitFull : MonoBehaviour
{


    [field: SerializeField] public  UnitMove Move { private set; get; }
    [field: SerializeField] public UnitHP _unitHp { private set; get; }
    [field: SerializeField] public UnitAttack _unitAttack { private set; get; }
    [field: SerializeField] public UnitsCheckAround _checkAround { private set; get; }

    [field: SerializeField] public  UnitIsSelection UnitSelection { private set; get; }
    [field: SerializeField] public unitAnimator UnitAnimator { private set; get; }
    [field: SerializeField] public UnitState UnitState { private set; get; }

    [field: SerializeField] public stateMachine Machine { private set; get; }
    [field: SerializeField] public GetResources getSources { private set; get; }

    [field: SerializeField] public UnitBuild UnitBuild { private set; get; }
    [field: SerializeField] public UnitWithFogWorld unitWithFogWorld { private set; get; }
    float time = 4;
    [SerializeField] Vector2 _target;
    private void Awake()
    {
        UnitReset();
        
       Machine.enterSates( this);
    }
        


    private void Update()
    {

     
        Machine.UpdateMachine(this);


        if (!_unitHp.checkHealthBar())
            return;

        if (time > 0)
        {

            time = time - Time.deltaTime;
            return;

        }


        _unitHp.offOnHealth(false);


    }

    public void UnitReset()
    {
        // set origontail unit 

        UnitState.setStates(UnitState.unitState.idle);
        _target = this.transform.position;
        _unitHp.setMaxHP(500);
        if (unitWithFogWorld == null)
            return;
        unitWithFogWorld.setArea();

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag(CONSTANT.arrow))
            return;

      
     
        _unitHp.getHP(collision.collider.GetComponent<arrowFulls>().Damage);

        time = 4;
        _unitHp.offOnHealth(true);
        collision.gameObject.SetActive(false);
        if (_unitHp.getHP(0)<=0)
        {

            UnitState.setStates(UnitState.unitState.die);

        }

        

    }
}
