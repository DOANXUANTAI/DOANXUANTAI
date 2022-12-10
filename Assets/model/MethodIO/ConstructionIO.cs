using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Menu/Construction", fileName = "ConstructionIO")]
public class ConstructionIO : ScriptableObject
{
    [field: SerializeField]
    public Sprite Construction_IMG { get; set; }
    [field: SerializeField]
    public string Constrution_Name { get; set; }
    [field: SerializeField]
    [field : TextArea]

    public string Discription { get; set; }
    [field: SerializeField]
    public List<MaterialIO> ListMaterial { get; set; }
    [field: SerializeField]
    public List<int> listMaterial_Number { get; set; }


    [field: SerializeField]
    public bool isUnit { get; set; } = false;

    [field: SerializeField]
    public bool isStorage { get; set; } = false;


    [field: SerializeField]
    public int MaxHP { get; set; } = 0;

}
