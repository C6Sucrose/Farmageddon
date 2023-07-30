using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauseExplosion : MonoBehaviour
{
    public Transform ExplosionSpawn;
    public GameObject ExplosionAnimation;

    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    void OnDestroy()
    {
        GameObject Explosion = Instantiate(ExplosionAnimation, ExplosionSpawn.position, ExplosionSpawn.rotation);
        Debug.Log("Play Explosion");
    }
}
