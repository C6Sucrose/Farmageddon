using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectionManager : MonoBehaviour
{
    public int totalLevels = 0;
    public int levelsUnlocked = 1;
    public GameObject nextButton;
    public GameObject prevButton;

    private LevelButtonConfig levelButton;
    private int level = 1;

    void OnEnable()
    {
        levelButton = GetComponentInChildren<LevelButtonConfig>();
    }

    void Start()
    {
        ChangePage();
    }

    public void ChangePage()
    {
        if (level <= totalLevels)
        {
            levelButton.gameObject.SetActive(true);
            levelButton.InitializeButton(level, level <= levelsUnlocked);
        }
        else
        {
            levelButton.gameObject.SetActive(false);
        }

        ActivateNextPrevButtons();
    }

    public void GoToNextPage()
    {
        level++;
        ChangePage();
    }

    public void GoToPrevPage()
    {
        level--;
        ChangePage();
    }

    public void ActivateNextPrevButtons()
    {
        prevButton.SetActive(level > 1);
        nextButton.SetActive(level < totalLevels);
    }

    public void StartLevel(int level)
    {
        if (level == levelsUnlocked)
        {
            levelsUnlocked++;
            ChangePage();
        }
    }

}
