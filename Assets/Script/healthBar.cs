using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{

    [SerializeField] Slider _slider;
    public Gradient _gradian;
    public Image fill;

    public void setMaxHealth(int health )
    {


        // set max value health
        _slider.maxValue = health;
        _slider.value = health;
        fill.color = _gradian.Evaluate(1f);


    }    

    public void setMax(int health)
    {
        // set max healt and not set value
        _slider.maxValue = health;



    }    
public void setHealth(int health)
  {


        // set the health   
        _slider.value = health;

        fill.color = _gradian.Evaluate(_slider.normalizedValue);


    }
}
