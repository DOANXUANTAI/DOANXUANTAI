using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionFrame : MonoBehaviour
{

    
    [field : SerializeField] public UnitHP HP { private set; get; }
    [field: SerializeField] public int CurrentHP { private set; get; } = 0;
    [field: SerializeField] public frameConstructionBuild FrameConstructionBuildP { private set; get; }
    [field: SerializeField] public ConstructionIO _constructionIO  {private set; get; }
    [field: SerializeField] public constructionFull ConstructionFull { private set; get; }
   // [field: SerializeField] List<MaterialIO> listMaterial = new List<MaterialIO>();



    public void pushConstructionIO(ConstructionIO constructionIO , constructionFull constructionFull)
    {


        // day cong trinh vao ben trong 
        _constructionIO = constructionIO;
       
        HP.setMax(constructionIO.MaxHP);
        ConstructionFull = constructionFull;
      //  listMaterial = constructionIO.ListMaterial;
   
        
    

    }
    public bool  controllerTakeMaterial()
    {
         // kiem tra xem co the xay duoc hay khong 
        for (int i = 0; i < _constructionIO.ListMaterial.Count; i++)
        {
            if (_constructionIO.listMaterial_Number[i] > gameManager.Instances.storage.returnMaterialNumber(_constructionIO.ListMaterial[i]))
            {

                // ...........

                return false;

            }    
           
        }
        return true;


    }    



    public void  buildDone()
    {

        //to allow build the building and set up the property for constructions

        if (CurrentHP >= _constructionIO.MaxHP && FrameConstructionBuildP.ListUnit.Count ==0)
        {
            ConstructionFull.gameObject.SetActive(true);
            ConstructionFull.ConstructionReset(CurrentHP);
            ConstructionFull._construction_bearing.construction_child(_constructionIO);
            if (_constructionIO.isUnit)
            {
                ConstructionFull._construction_with_unit.itIsUnit(_constructionIO.isUnit);
                ConstructionFull._construction_with_unit.setCappacity(2);
                constructionPooling.Instance.addHourse(ConstructionFull);
            }
         
            resetFrames();

            this.gameObject.SetActive(false);

        }    


    }    
   


    public void resetFrames()
    {

        // recover the HP
        HP.setMax(_constructionIO.MaxHP);
        HP.recoverHP(0);
        CurrentHP = 0;


    }

    public bool addHP(int numnber)
    {
        if (CurrentHP < HP._HP)
        {

            CurrentHP = CurrentHP + numnber;

            HP.recoverHP(CurrentHP);
            return false;

        }

        return true;

    }    






    public bool caculationMaterial()
    {


        return true;


    }    

}
