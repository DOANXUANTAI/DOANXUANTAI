using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class constructionEnemy : MonoBehaviour
{


    [field: SerializeField]  List<constructionFull> theHourse = new List<constructionFull>();




    
    public  void createEnemy()
    {
        for (int i = 0; i < transform.childCount; i++)
        {

            theHourse.Add(transform.GetChild(i).gameObject.GetComponent<constructionFull>());
        }

        StartCoroutine(delay());
    }


    public int getNumber()
    {
  

        for (int i = 0; i < theHourse.Count; i++)
        {
            if (theHourse[i].gameObject.activeSelf)
                return 1;
        }

        return 0;
    }
    IEnumerator delay()
    {
        yield return new WaitUntil(()=> theEnemyPooling.Instance != null);


        
        for (int i = 0; i < theHourse.Count; i++)
        {
            if (theHourse[i]._construction_with_unit.checkUnit())
            {
                UnitFull enemy = theEnemyPooling.Instance.child_bearing_unit();
                enemy.transform.position = theHourse[i]._construction_with_unit.UnitChild.transform.position;
            }
        }

    }
}
