using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class playermovements : MonoBehaviour
{
 
    private float inputs; 
    private Rigidbody2D rb;
    public Vector2 boxsize;
    private bool havingbullet;
    public const float maxleft = 16; // it can go any further
    public const float maxright = 380;

    public gettinghurt sta;
    private Vector2 offscreen = new Vector2(0, -300f);
    private Vector2 startpos = new Vector2(180f, 0f);
    public AudioClip shootingsound;
    
    
    public GameObject bullet;

    void Start()
    {
        sta.currenthealth = sta.maxhealth;
        sta.currenlives = sta.maxlives;
        transform.position = startpos;
        
        rr.updatehealth(sta.currenthealth);
        rr.updatinghlive(sta.currenlives);
    }

    void Update()
    {
        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && transform.position.x > maxleft)
        {
            transform.Translate(Vector3.left * sta.shipspeed* Time.deltaTime); //transform and change the x and go to left
        }

        if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && transform.position.x < maxright) //make sure we cab go further
        {
            transform.Translate(Vector3.right *sta.shipspeed* Time.deltaTime); //going to right
        }

        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.Space))&& !havingbullet)
        {
            StartCoroutine(shooting());
        }
    }

    private IEnumerator shooting()
    {
        havingbullet = true;
        Instantiate(bullet, transform.position, Quaternion.identity); //create a bullet
        musicmanage.playingsound(shootingsound);
        yield return new WaitForSeconds(sta.firepower); //time before we shoot again
        havingbullet = false;
    }




    public void OnCollisionEnter2D(Collision2D other)
    {
            Destroy(other.gameObject); //Destroy bomb
            takehurt();
    }

    private IEnumerator respawn() //after loosing whole lives we back to game after 2 second
    {
        transform.position = offscreen;
        yield return new WaitForSeconds(2);
        sta.currenthealth = sta.maxhealth;
        sta.currenthealth= sta.maxhealth;
        
        transform.position = startpos;
    }
    public void takehurt()
    {
        sta.currenthealth--;
        rr.updatehealth(sta.currenthealth);
        if (sta.currenthealth <= 0)
        {
            sta.currenlives--;
            rr.updatinghlive(sta.currenlives);
            rr.updateactivehealt(sta.maxhealth);

            if (sta.currenlives <= 0)
            {
                savemanager.svaepro();
                menumanager.opengameovermenu();
                 sta.currenlives = sta.maxlives;
            }
            else
            {
               StartCoroutine(respawn());
            }
        }
    }

    public void addlife()
    {
        if (sta.currenlives == sta.maxlives)
        {
            rr.updatescore(50); //if the have max we add score to them
        }
        else
        {
            sta.currenlives++;
            rr.updateactivelife(sta.currenlives);
        }
    }

    public void addhelth()
    {
        if (sta.currenthealth == sta.maxhealth)
        {
            rr.updatescore(20);
        }
        else
        {
            sta.currenthealth++;
            rr.updateactivehealt(sta.currenthealth);
        }
    }
   
    


}