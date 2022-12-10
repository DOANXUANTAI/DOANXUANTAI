using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unit : MonoBehaviour
{



    [SerializeField] float moveSpeed;
    [SerializeField] Vector2 target;
    [SerializeField] Collider2D col;
    [SerializeField] animator _animation;
    [SerializeField] LayerMask _mask;
    [field: SerializeField] public  Sources sources { private set; get; }

    [field: SerializeField] public UnitState units { get; private set; }
    [SerializeField] public MaterialIO _materialCarry { get; private set; }
    [SerializeField] UnitIO _unitIO;
    [SerializeField] weapon _weapon;
    [SerializeField] int _HP;
    [SerializeField] healthBar _health;

 
 
}
