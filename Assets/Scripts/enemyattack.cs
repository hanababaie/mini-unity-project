using System;
using UnityEngine;

public class enemyattack : MonoBehaviour
{
    public float speedMove = 20;
    Vector2 direction; //for the direction of the bullet
    private bool isokay; // to know when we can shoot

    public void Awake()
    {
        isokay = false;
    }

    public void setdirection(Vector2 direction)
    {
        this.direction = direction.normalized; //set the direction normalized to get an unit vector
        isokay = true;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isokay)
        {
            Vector2 position = transform.position; //get the bullet current position
            position += direction * speedMove * Time.deltaTime; // to move the bullet
            transform.position = position; //update the position
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
      Destroy(gameObject); 
    }
}
