using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowpool : MonoBehaviour
{


    private static arrowpool _instance;
    public static arrowpool Instance => _instance;

    [SerializeField] arrowFull _refabArrow;
    [SerializeField] List<arrowFull> _listArrow =  new List<arrowFull>();




    private void Awake()
    {
  
        if (_instance != this && _instance != null)
        {
            Destroy(this);

        }
        else
        {

            _instance = this;
        }

    }

    // Update is called once per frame



    public arrowFull child_bearing_arrow()
    {

        // bearing arrow

        if (_listArrow.Count ==0)
        {

            arrowFull arrow = Instantiate(_refabArrow, this.transform);
            _listArrow.Add(arrow);
            return arrow;

        }



        foreach (var item in _listArrow)
        {
            if (item.gameObject.activeSelf)
                continue;


            return item;
        }

        arrowFull arrow_1 = Instantiate(_refabArrow, this.transform);
        _listArrow.Add(arrow_1);
        return arrow_1;


    }


}
