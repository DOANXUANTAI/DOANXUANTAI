using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHP : MonoBehaviour
{
    [field: SerializeField] public  int _HP { private set; get; }

    [SerializeField] healthBar _healthBar;



        
    public void recoverHP(int number)
    {

        // recover the hp
        _healthBar.setHealth(number);

    }    

    public void offOnHealth(bool val)
    {
        // bat tat thanh mau
        _healthBar.gameObject.SetActive(val);

    }

    public bool checkHealthBar()
    { 
        // kiem tra xem thanh mau co hien hay khong 
        return _healthBar.gameObject.activeSelf;

    }

   
    public void setMax(int maxHP)
    {
        // set max values but no have values
        _healthBar.setMax(maxHP);
        _HP = maxHP;
    }    
    

    public void setMaxHP(int maxHP)
    {

        // set max Hp
        _HP = maxHP;

        if (_healthBar == null)
            return;

        _healthBar.setMaxHealth(maxHP);

    }

    public int getHP( int hp)
    {

        // get HP Unit
        if (hp > _HP)
        {

            _HP = 0;

              _healthBar.setHealth(_HP);
            return _HP;

        }

        _HP = _HP - hp;
        _healthBar.setHealth(_HP);
        return _HP;

    }    
}
