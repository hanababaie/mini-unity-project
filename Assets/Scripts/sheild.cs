using UnityEngine;

public class sheild : MonoBehaviour
{
    private int health;
    public GameObject sheildprefab;
    void Start()
    {
        health = 4;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject); //destroy the bomb
        health--;


        if (health <= 0)
        {
          Destroy(gameObject); 
        }
    }

}
