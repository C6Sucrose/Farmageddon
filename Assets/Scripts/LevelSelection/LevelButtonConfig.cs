using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelButtonConfig : MonoBehaviour
{
    public Sprite lockedLevelSprite;
    public Sprite unlockedLevelSprite;
    public TextMeshProUGUI levelNumber;
    public LevelSelectionManager managerLevel;

    private Button button;
    private Image image;
    private int level = 0;
    private bool isUnlocked = false;

    void OnEnable()
    {
        button = GetComponent<Button>();
        image = GetComponent<Image>();
    }

    public void InitializeButton(int level, bool isUnlocked)
    {
        this.level = level;
        this.isUnlocked = isUnlocked;
        levelNumber.text = level.ToString();
        if (isUnlocked)
        {
            image.sprite = unlockedLevelSprite;
            button.enabled = true;
            levelNumber.gameObject.SetActive(true);
        }
        else
        {
            image.sprite = lockedLevelSprite;
            button.enabled = false;
            levelNumber.gameObject.SetActive(false);
        }
    }

    public void OnClick()
    {
        managerLevel.StartLevel(level);
        if (isUnlocked)
        {
            SceneManager.LoadScene("Level_" + level.ToString());
        }  
    }
}
