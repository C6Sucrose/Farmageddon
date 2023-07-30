using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukeTest : MonoBehaviour
{
    public GameObject nuke;
    public Transform nukeSpawn;

    public void LaunchNukeTest()                         // Just a test script to debug nukes
    {
        GameObject Destroyer = Instantiate(nuke, nukeSpawn.position, nukeSpawn.rotation);
    }
}
