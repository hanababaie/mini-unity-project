using UnityEngine;

public abstract class  pickups : MonoBehaviour
{
    public float moveSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     transform.Translate(Vector2.down * Time.deltaTime * moveSpeed);

     if (transform.position.y <= -10)
     {
         Destroy(gameObject);
     }
    }
    
    public abstract void Pickupit();// we have to write in health and life pickup

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Pickupit();
        }
    }
}
