using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// public class UpgradeScene : MonoBehaviour
// {
    
//     //public GameObject weaponimg;
//     public Button weaponUpgradeButton;
//     //public SwitchWeapons switchweapons;
    
//     private int upgrade_level;
    
//     public const int maxUpgrades = 2;
    
//     private void Start()
//     {
//         upgrade_level = 1;
//         UpdateUpgradeButtons();
//     }
    
//     public void UpgradeWeapon()
//     {
//         if (upgrade_level < maxUpgrades)
//         {
//             upgrade_level++;
//             UpdateUpgradeButtons();
//         }
//         else
//         {
//             Debug.Log("Not Upgradable anymore");
//         }
//     }
    
//     private void UpdateUpgradeButtons()
//     {
//         // Update weapon image
        
//         // Update fire rate upgrade button
//         if (upgrade_level < maxUpgrades)
//         {
//             //switchweapons = GameObject.Find("WeaponSpawnPoint").GetComponent<SwitchWeapons>();
//             //switchweapons.ReplaceWeapon(upgrade_level, upgrade_level);
            
//             //weaponimg.GetComponent<SpriteRenderer>().sprite = switchweapons.weapons[upgrade_level].GetComponent<SpriteRenderer>().sprite;
//             weaponUpgradeButton.interactable = true;
        
//             Debug.Log("upgraded");
//         }
//         else
//         {
//             weaponUpgradeButton.interactable = false;
//             Debug.Log("Not Upgradable anymore");
//         }

//         //SceneManager.UnloadSceneAsync(level);
//     }
// }



// public class UpgradeScene : MonoBehaviour
// {
//     public Button weaponUpgradeButton;


//     public int weapon1UpgradeLevel;
//     public int weapon2UpgradeLevel;
//     public Sprite[] spriteArray;

//     public const int maxUpgrades = 2;

//     private void Start()
//     {
//         weapon1UpgradeLevel = 0;
//         weapon2UpgradeLevel = 0;
//         UpdateUpgradeButtons();
//     }

//     public void UpgradeWeapon1()
//     {
//         if (weapon1UpgradeLevel < maxUpgrades)
//         {
//             weapon1UpgradeLevel++;
//             UpdateUpgradeButtons();
//         }
//         else
//         {
//             Debug.Log("Weapon 1: Not Upgradable anymore");
//         }
//     }

//     public void UpgradeWeapon2()
//     {
//         if (weapon2UpgradeLevel < maxUpgrades)
//         {
//             weapon2UpgradeLevel++;
//             UpdateUpgradeButtons();
//         }
//         else
//         {
//             Debug.Log("Weapon 2: Not Upgradable anymore");
//         }
//     }

//     private void UpdateUpgradeButtons()
//     {
//         if (weapon1UpgradeLevel < maxUpgrades)
//         {
//             weaponUpgradeButton.interactable = true;
//             Debug.Log("Weapon : Upgraded");
//         }
//         else
//         {
//             weaponUpgradeButton.interactable = false;
//             Debug.Log("Weapon : Not Upgradable anymore");
//         }

        

        
//     }
// }


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
        currentIndex = weapon1UpgradeLevel;

        spriteObject = new GameObject();
        spriteObject.transform.position = new Vector2(0f, 0f);

        spriteRenderer = spriteObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = spriteArray[currentIndex];

        Button changeSpriteButton = weaponUpgradeButton.GetComponent<Button>();
        changeSpriteButton.onClick.AddListener(ChangeSprite);
        Debug.Log(weapon1UpgradeLevel);
    }

    public void UpgradeWeapon1()
    {
        if (weapon1UpgradeLevel < maxUpgrades)
        {
            weapon1UpgradeLevel++;
            UpdateUpgradeButtons();
        }
        else
        {
            Debug.Log("Weapon 1: Not Upgradable anymore");
        }
    }

    public void UpgradeWeapon2()
    {
        if (weapon2UpgradeLevel < maxUpgrades)
        {
            weapon2UpgradeLevel++;
            UpdateUpgradeButtons();
        }
        else
        {
            Debug.Log("Weapon 2: Not Upgradable anymore");
        }
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
        if(currentIndex < 2)
        {
            currentIndex++;
        }
        
        if (currentIndex >= spriteArray.Length)
        {
            currentIndex = weapon1UpgradeLevel;
        }
        spriteRenderer.sprite = spriteArray[currentIndex];
    }
}