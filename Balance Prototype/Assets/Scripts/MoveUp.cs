using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour
{
     private GameManager gameManager;

    [SerializeField] private float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Move()
    {
        gameObject.transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive || this.gameObject.tag=="Flames")
        {
            Move();
        }
    }
}
