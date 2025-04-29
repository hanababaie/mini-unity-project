using Unity.VisualScripting;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public float moveSpeed;
    public Vector3 moveDirection; //for player it is up and for enemies it is downwaed
    public System.Action destroyed;
    
    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("enemy");     
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    } 
    void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
        if(transform.position.y >= 280){
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "no")
        {
            collision.gameObject.GetComponent<enemy>().killing();
            //when it hit another thing it should get destroyed. 
            Destroy(gameObject);
        }

    }
}
