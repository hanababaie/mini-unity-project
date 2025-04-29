using UnityEngine;

public class enemyshooting : MonoBehaviour
{
    public float speed = 100f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * speed);
        if (transform.transform.position.y < -30)
        {
            Destroy(gameObject);
        }
    }
}
