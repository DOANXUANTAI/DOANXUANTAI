using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowPooling : MonoBehaviour
{

    [SerializeField] arrowFulls _arrow;


    private static arrowPooling _instance;
    public static arrowPooling Instance => _instance;




    [SerializeField] List<arrowFulls> _arrowlist = new List<arrowFulls>();


    private void Awake()
    {

        if (_instance != null && _instance != this)
        {
            Destroy(this);

        }
        else
        {

            _instance = this;

        }

    }



    #region unit method 


    public arrowFulls child_bearing_arrow()
    {
        arrowFulls arrow;


        // chill arrows
        if (_arrowlist.Count==0)
        {


            arrow = Instantiate(_arrow,transform);
        
            _arrowlist.Add(arrow);

            return arrow;
        }
        foreach (var item in _arrowlist)
        {

            if (item.gameObject.activeSelf)
                continue;

           
            return item;


        }



        arrow = Instantiate(_arrow, transform);
        arrow.arrowReset();
      
        return arrow;


    }
  

    


    #endregion
}

