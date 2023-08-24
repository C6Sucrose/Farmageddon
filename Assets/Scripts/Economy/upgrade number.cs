using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeNumber : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    private int intVariable;

    private void Update()
    {
        if(UpgradeScene.weapon1UpgradeLevel == 0){
            intVariable = 2500;
        }
        else if(UpgradeScene.weapon1UpgradeLevel == 1){
            intVariable = 8000;
        }
        // Update the text value with the int variable value
        textMeshPro.text = "Required: " +  intVariable.ToString();
    }
}