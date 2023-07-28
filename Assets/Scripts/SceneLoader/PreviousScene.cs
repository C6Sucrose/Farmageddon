using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreviousScene : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GoToPreviousScene();
        }
    }

    private void GoToPreviousScene()
    {
        if (SceneManager.sceneCount > 0)
        {
            
            SceneManager.LoadScene("Menu");
        }
        else
        {
            Debug.Log("There is no previous scene to go back to.");
        }
    }
}