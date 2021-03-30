using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    private static bool isSpawned = false;
    // Start is called before the first frame update
    private void Awake()
    {
        if (!isSpawned)
        {
            isSpawned = true;
        DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            DestroyImmediate(this.gameObject);
        }
}
}
