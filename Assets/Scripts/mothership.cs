using UnityEngine;

public class mothership : MonoBehaviour
{
    public int score = 300;
    private const float maxleft = -280;
    private float speed = 200;


    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed); //it move to left
        if(transform.position.x <= maxleft)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "missle")
        {
            rr.updatescore(score);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            
        }
    }
}
