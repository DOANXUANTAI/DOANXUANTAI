using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiscritionMethod : MonoBehaviour
{

    [SerializeField] Text _title;
    [SerializeField] Text _discription;
    [SerializeField] Image _imgItem;
    [SerializeField] Transform _listMaterial;
    [SerializeField] Button _right, _left;
    [SerializeField] boxInformationMethod _box;
    [SerializeField] List<boxInformationMethod> listBox;


    public void setDiscriptionInformation_build(ConstructionIO constructionIO)
    {
        // tai thong tin cho discrition nếu thông tin được đưa vào là construction
        _title.text = constructionIO.Constrution_Name;
        _discription.text = constructionIO.Discription;
        _imgItem.sprite = constructionIO.Construction_IMG;
        // creat box 
        if (listBox.Count ==0  )
        { // khi chua có  cái méo gì bên trong 
            for (int i = 0; i < constructionIO.ListMaterial.Count; i++)
            {
                boxInformationMethod newBox = Instantiate(_box, _listMaterial);
                newBox.setBoxInformation(constructionIO.ListMaterial[i], constructionIO.listMaterial_Number[i].ToString());
                listBox.Add(newBox);
            }

            return;

        }

     
       
        for (int i = 0; i < constructionIO.ListMaterial.Count; i++)
        {

            listBox[i].setBoxInformation(constructionIO.ListMaterial[i], constructionIO.listMaterial_Number[i].ToString());

        }






    }    

    public void setDiscritpionInformation_Citizent(UnitIO UnitIO)
    {

        // tai thong tin cho discrition nếu thông tin được đưa vào là unit
        _title.text = UnitIO.Name;
        _discription.text = UnitIO.Discription;
        _imgItem.sprite = UnitIO.IMG;
        // creat box 
        if (listBox.Count == 0)
        { // khi chua có  cái méo gì bên trong 
            for (int i = 0; i < UnitIO.ListMaterial.Count; i++)
            {
                boxInformationMethod newBox = Instantiate(_box, _listMaterial);
                newBox.setBoxInformation(UnitIO.ListMaterial[i], UnitIO.List_Material_Number[i].ToString());
                listBox.Add(newBox);
            }

            return;

        }



        for (int i = 0; i < UnitIO.ListMaterial.Count; i++)
        {

            listBox[i].setBoxInformation(UnitIO.ListMaterial[i], UnitIO.List_Material_Number[i].ToString());

        }



    }
    public void setAction(UnityEngine.Events.UnityAction right , UnityEngine.Events.UnityAction left )
    {

        // set upfunction for button
   
        _right.onClick.AddListener(right);
        _left.onClick.AddListener(left);

     




    }

    private void OnDisable()
    {
        _right.onClick.RemoveAllListeners();
        _left.onClick.RemoveAllListeners();
    }
 

}
