using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class rocketmovements : MonoBehaviour
{
   
    public float moveSpeed = 50f;
    public System.Action kiiledvillan;
    public static List<GameObject> allenemies = new List<GameObject>(); //we make a list of all enemies
    public float shoottimer = 2f;
    public float shoottime = 2;
    public GameObject bulletprefab;
    public GameObject mothershipprefab;
    private Vector3 mothershippos = new Vector3(185,320,0);  //make it appear from here

    private float mothershiptimer = 60;
    private const float mothershipmin = 15; // go arounf in raandom time between max and min
    private const float mothershipmax = 60;

    private bool enter = true;
    private const float startingY = 180; //we to show the set

    void Start()
    {
        foreach(GameObject go in GameObject.FindGameObjectsWithTag("no")) //we will wind all of the game object with this tag and add to list
                         allenemies.Add(go);
    }

    // Update is called once per frame
    void Update()
    {

        if (enter)
        {
            transform.Translate(Vector2.down * Time.deltaTime * 100f);

            if (transform.position.y <= startingY) //if we get to the pos we set it false
            {
                enter = false;
            }
        }
        else
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            if (shoottimer <= 0)
            {
                shoot();
            }

            shoottimer -= Time.deltaTime;

            if (mothershiptimer <= 0)
            {
                movemothership();
            }

            mothershiptimer -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "br") //this means if the enemies hit the boundries they turn back in the opposite deraction
        {

            moveSpeed *= -1f; //this means it backs
            transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z); //this ensure when we hit the boundries it come one unit down
            
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("missle")) //if we collide with missles
        {
            
            this.gameObject.SetActive(false); //this makes it diseaper
        }
    }

    private void shoot()
    {
        Vector2 position = allenemies[Random.Range(0, allenemies.Count)].transform.position;
        
        Instantiate(bulletprefab, position, Quaternion.identity);
        shoottimer = shoottime;
    }

    private void movemothership(){
        Instantiate(mothershipprefab,mothershippos,Quaternion.identity); //showing it
        mothershiptimer = Random.Range(mothershipmax,mothershipmin);
    }

}
