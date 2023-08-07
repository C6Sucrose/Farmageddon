using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    private int intVariable;

    private void Update()
    {
        intVariable = CurrencyHandler.currentCurrency;
        // Update the text value with the int variable value
        textMeshPro.text = intVariable.ToString();
    }
}