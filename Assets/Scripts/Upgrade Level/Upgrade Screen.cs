using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UpgradeScene : MonoBehaviour
{
    public Button weaponUpgradeButton;
    public static int weapon1UpgradeLevel;
    public static int weapon2UpgradeLevel;
    public Sprite[] spriteArray;
    public const int maxUpgrades = 2;
    public int currentIndex;
    private GameObject spriteObject;
    private SpriteRenderer spriteRenderer;
    

    private void Start()
    {
        UpdateUpgradeButtons();
        
        PlayerPrefs.DeleteKey("weapon1UpgradeLevel");
        if(PlayerPrefs.HasKey("weapon1UpgradeLevel")){//if upgrades exist
            weapon1UpgradeLevel = PlayerPrefs.GetInt("weapon1UpgradeLevel"); 
        }
        else
        {
            weapon1UpgradeLevel = 0;

        }
        currentIndex = weapon1UpgradeLevel;
        weapon2UpgradeLevel = weapon1UpgradeLevel;
        spriteObject = new GameObject();
        spriteObject.transform.position = new Vector2(0f, 0f);

        spriteRenderer = spriteObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = spriteArray[currentIndex];

        Button changeSpriteButton = weaponUpgradeButton.GetComponent<Button>();
        changeSpriteButton.onClick.AddListener(ChangeSprite);
        Debug.Log(weapon1UpgradeLevel);
    }

    private void UpdateUpgradeButtons()
    {
        
        if (weapon1UpgradeLevel < maxUpgrades)
        {
            weaponUpgradeButton.interactable = true;
            Debug.Log("Weapon : Upgraded");
        }
        else
        {
            weaponUpgradeButton.interactable = false;
            Debug.Log("Weapon : Not Upgradable anymore");
        }
    }

    private void ChangeSprite()
    {
        if(weapon1UpgradeLevel < maxUpgrades)
        {
            
            switch (CurrencyHandler.currentCurrency)
            {
                case var x when x >= 8000:
                    // Code to handle the case where currencyValue is greater than or equal to 8000
                    Debug.Log("Currency value is greater than or equal to 8000");
                    if(weapon1UpgradeLevel == 0)
                    {
                        weapon1UpgradeLevel += 2;
                        weapon2UpgradeLevel += 2;
                        CurrencyHandler.currentCurrency -= 8000;          
                        // Save the updated upgrade value to PlayerPrefs
                        PlayerPrefs.SetInt("weapon1UpgradeLevel", weapon1UpgradeLevel);
                        PlayerPrefs.Save();        
                    }
                    else
                    {
                        weapon1UpgradeLevel++;
                        weapon2UpgradeLevel++;
                        CurrencyHandler.currentCurrency -= 8000;
                        // Save the updated upgrade value to PlayerPrefs
                        PlayerPrefs.SetInt("weapon1UpgradeLevel", weapon1UpgradeLevel);
                        PlayerPrefs.Save();                 
                    }
                    currentIndex = weapon1UpgradeLevel;
                    spriteRenderer.sprite = spriteArray[currentIndex];
                    break;

                case var x when x >= 2500 && x < 8000:
                    // Code to handle the case where currencyValue is greater than or equal to 2500 and less than 8000
                    Debug.Log("Currency value is greater than or equal to 2500 and less than 8000");
                    if(weapon1UpgradeLevel == 0)
                    {
                        weapon1UpgradeLevel++;
                        weapon2UpgradeLevel++;
                        CurrencyHandler.currentCurrency -= 2500;
                        currentIndex = weapon1UpgradeLevel;
                        // Save the updated upgrade value to PlayerPrefs
                        PlayerPrefs.SetInt("weapon1UpgradeLevel", weapon1UpgradeLevel);
                        PlayerPrefs.Save(); 
                    }

                    spriteRenderer.sprite = spriteArray[currentIndex];
                    break;

                default:
                    // Code to handle the default case (when currencyValue is less than 2500)
                    Debug.Log("Currency value is less than 2500");
                    break;
            }
        
            
        }
    }
}