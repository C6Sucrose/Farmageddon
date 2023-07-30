using System.Collections;
using System.Collections.Generic;
using UnityEngine;




//For PC
public class Reticle : MonoBehaviour
{
    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition;
    }
}



//For Mobile
// public class Reticle : MonoBehaviour
// {
//     void Update()
//     {
//         if (Input.touchCount > 0)
//         {
//             Touch touch = Input.GetTouch(0);
//             Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
//             transform.position = touchPosition;
//         }
//     }
// }
