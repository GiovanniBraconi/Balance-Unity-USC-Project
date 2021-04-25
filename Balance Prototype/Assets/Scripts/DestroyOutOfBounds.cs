using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 18;
    

    

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y> topBound)
        {
            
            Destroy(gameObject);

        }
    }
  
}
