using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalInput;
    private float speed = 20.0f;
   
    private GameManager gameManager;
    
   
   
    void Start()
    
    {
        
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();




    }

    void Movement()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
    }

    
   
   
   
    void Update()
    {
        if (gameManager.isGameActive)
        {
            
           

            Movement();
            

        }
       
    }
    }
   
   
 
   
    
    
    
   
    



            


