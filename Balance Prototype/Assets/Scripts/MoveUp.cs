using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour
{
    public GameManager gameManager;
    [SerializeField] private int speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Move()
    {
        gameObject.transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.name == "Background")
        {
            if (gameManager.isGameActive)
            {
                Move();
            }
        }
        else
        {
            Move();
        }
       
    }
}
