using UnityEngine;
using System.Collections;

public class RepeatingBackground : MonoBehaviour
{

         
    private float groundHorizontalLength= 30f;       

    
     void Start()
    {
        
  
        
    }

    
    void Update()
    {
        
        if (transform.position.x < -groundHorizontalLength)
        {
           
            RepositionBackground();
        }
    }

    
     void RepositionBackground()
    {
        
        Vector2 groundOffSet = new Vector2(groundHorizontalLength * 2f, 0);

        
        transform.position = (Vector2)transform.position + groundOffSet;
    }
}