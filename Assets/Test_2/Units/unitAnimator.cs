using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unitAnimator : MonoBehaviour
{

    public enum Parameter { isIdle, isMove, isUseExe, isHurt, isAttack, isDie, isMining , isReturnMaterial }
    public Parameter parameter;
    [SerializeField] Animator _anime;



    public void changeAnimation()
    {

        string[] arr = System.Enum.GetNames(typeof(Parameter));

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i].CompareTo(parameter.ToString()) != 0)
            {

                _anime.SetBool(arr[i], false);
                continue;

            }
            _anime.SetBool(arr[i], true);
        }




    }


}
