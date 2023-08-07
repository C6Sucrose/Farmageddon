using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NukeButtonDisable : MonoBehaviour
{
    public Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        
        if (button != null)
        {
            button.onClick.AddListener(DisableButton);
        }
        else
        {
            Debug.LogError("DisableButtonOnClick script requires a Button component!");
        }
    }

    private void DisableButton()
    {
        button.interactable = false;
    }
}
