    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelDIscription : MonoBehaviour
{

    [SerializeField] Text _title;
    [SerializeField] Text _Discritpion;
    [SerializeField] Image _IMG;

    [SerializeField] Transform _parrent;
    [SerializeField] Box_solution _boxSolution;

    [SerializeField] List<Box_solution> listBoxSolution = new List<Box_solution>();
    [SerializeField] Button _tick;

    [SerializeField] MouseFollowMethod _mouse;



    public void setUnitDiscritpion(UnitIO unitIO)
    {


        // to set up the infomation of unit and add the function for button
        _title.text = unitIO.Name;
        _Discritpion.text = unitIO.Discription;
        _IMG.sprite = unitIO.IMG;

        if (listBoxSolution.Count ==0)
        {
            onReady(unitIO.ListMaterial, unitIO.List_Material_Number);

      

        }
        for (int i = 0; i < unitIO.ListMaterial.Count; i++)
        {
            changeValues(unitIO.ListMaterial[i], unitIO.List_Material_Number[i].ToString());
        }

        addLisenter(()=> {


            if (!gameManager.Instances.storage.checkMaterial(unitIO.ListMaterial, unitIO.List_Material_Number))
                return;








            constructionFull newConstruction = constructionPooling.Instance.checkHourse();
            if (newConstruction == null)
                return;















            UnitFull newUnit = UnitPooling.Instance.child_bearing_unit();

            newUnit.transform.position = newConstruction._construction_with_unit.UnitChild.position;
            gameManager.Instances.storage.returnMaterial(unitIO.ListMaterial, unitIO.List_Material_Number);
            newConstruction._construction_with_unit.addUnit(newUnit);
            foreach (var item in gameManager.Instances.storage.returnList())
            {
                menuController.Instance.Head.changeValues(item.Key,item.Value.ToString());
            }
          
           
        
        
        });

    addLisenter(() => this.gameObject.SetActive(false));
    }


    public void setConstructionDiscritpion(ConstructionIO CostructionIO)
    {
        _title.text = CostructionIO.Constrution_Name;
        _Discritpion.text = CostructionIO.Discription;
        _IMG.sprite = CostructionIO.Construction_IMG;

        _mouse.setMouseFollowerData(CostructionIO);
        if (listBoxSolution.Count == 0)
        {
            onReady(CostructionIO.ListMaterial, CostructionIO.listMaterial_Number);

    

        }
        for (int i = 0; i < CostructionIO.ListMaterial.Count; i++)
        {
            changeValues(CostructionIO.ListMaterial[i], CostructionIO.listMaterial_Number[i].ToString());
        }




        addLisenter(()=>this.gameObject.SetActive(false));
        addLisenter(()=> _mouse.gameObject.SetActive(true) );


    }


    public void onReady(List<MaterialIO> listMaterial , List<int> listNnumber)
    {

        for (int i = 0; i < listMaterial.Count; i++)
        {

            Box_solution newBox = Instantiate(_boxSolution, _parrent);
            newBox.setBoxInfomtaion(listMaterial[i].IMG, "X ", listMaterial[i].material.Style.ToString());
            listBoxSolution.Add(newBox);
        }



    }


    public void changeValues(MaterialIO material, string number)
    {

        // change values of box



        for (int i = 0; i < listBoxSolution.Count; i++)
        {

            if (listBoxSolution[i].Box_Name == material.material.Style.ToString())
            {
                listBoxSolution[i].ChangeBoxValues(number);


            }

        }

    }


    public void addLisenter(UnityEngine.Events.UnityAction call)
    {
        _tick.onClick.AddListener(call);


    }



    private void OnDisable()
    {

        _tick.onClick.RemoveAllListeners();
    }
}
