using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelLoader : MonoBehaviour
{



    [SerializeField] Slider slider;
    public void loadLevel(int indext)
    {

        this.gameObject.SetActive(true);
        StartCoroutine(loadScene(indext));
    }

    IEnumerator loadScene (int index)
    {
        AsyncOperation operators = SceneManager.LoadSceneAsync(index);
        while (!operators.isDone)
        {

            float progress = Mathf.Clamp01(operators.progress/.9f);
            slider.value = progress;
         
            yield return null;
        }

    }

    public void quitGame()
    {
        Application.Quit();

    }

}
