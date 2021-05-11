using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatWood : MonoBehaviour
{
    public Vector3 startPos;
    private float topBound = 34.54f;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
       
        

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > topBound)
        {
            transform.position = startPos;
        }
    }
}
