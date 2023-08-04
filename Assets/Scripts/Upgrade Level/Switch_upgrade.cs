using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_upgrade : MonoBehaviour
{
    public UpgradeScene us;

    public int w1ul;
    public int w2ul;

    void Awake(){
        w1ul = UpgradeScene.weapon1UpgradeLevel;
        w2ul = UpgradeScene.weapon2UpgradeLevel;
    }
    
}
