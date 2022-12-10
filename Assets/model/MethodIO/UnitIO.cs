using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(menuName = "Menu/Unit", fileName = "UnitIO")]
public class UnitIO : ScriptableObject
{
    [field: SerializeField]
    public Sprite IMG { get; set; }

    [field: SerializeField ]
    public string Name { set; get; }
    [field: SerializeField]
    [field : TextArea]
    public string Discription { set; get; }

    [field: SerializeField]
    public
    List<MaterialIO> ListMaterial { get; set; }


    [field: SerializeField]
    public
    List<int> List_Material_Number { get; set; }
}
