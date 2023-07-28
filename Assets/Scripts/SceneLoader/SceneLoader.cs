using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransitionButton : MonoBehaviour
{
    // The name of the scene you want to transition to
    [SerializeField]
    private string sceneName;

    void Start()
    {
        Button transitionButton = GetComponent<Button>();
        transitionButton.onClick.AddListener(TransitionToScene);
    }

    void TransitionToScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}