using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency_Increment : MonoBehaviour
{
    public int inc;
    
    private void OnDestroy()
    {
        // Increment the currency value

        CurrencyHandler.currentCurrency += inc;
        Debug.Log("Currency Increment: " + CurrencyHandler.currentCurrency);

        // Save the updated currency value to PlayerPrefs
        PlayerPrefs.SetInt("Currency", CurrencyHandler.currentCurrency);
        PlayerPrefs.Save();
    }
}
