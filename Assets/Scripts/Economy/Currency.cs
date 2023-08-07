using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyHandler : MonoBehaviour
{
    public static int currentCurrency;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("Currency")){//if currency exists
            currentCurrency = PlayerPrefs.GetInt("Currency");
        }
        else
        {
            currentCurrency = 0;
        }
    }
}