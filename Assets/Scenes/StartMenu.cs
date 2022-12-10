using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
  


    public void loadScene(int indext)
    {

        SceneManager.LoadScene(indext,LoadSceneMode.Single);

    }

    public void quitGame()
    {
        Application.Quit();

    }
}
