using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Reload_Text : MonoBehaviour
{
    public TextMeshProUGUI displayText;
    public float variable;
    public float updateInterval = 1f;
    private float timer = 0f;
    public AmmoSystem ammo_sys;
    public void Update()
    {
        timer += Time.deltaTime;
        if(timer >= updateInterval)
        {
            UpdateText();
            timer = 0f;
        }    
    }

    public void SetVariable()
    {   
        variable = ammo_sys.currentRefillTime;
        UpdateText();
    }

    private void UpdateText()
    {
        if(ammo_sys.currentAmmo == ammo_sys.maxAmmo)
        {
            displayText.text = "Reloaded";
            return;
        }
        displayText.text = "Reloading: " + variable.ToString();
    }
}
