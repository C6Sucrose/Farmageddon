using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class corn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

public void decreasescale()
    {
        transform.position= new Vector2(transform.position.x-1f,transform.position.y);
    }
}
