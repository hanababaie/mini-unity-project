using UnityEngine;

public class enemy : MonoBehaviour{

public GameObject lifepre; //for pickups
public GameObject healthpre;

private const int lifechamce = 1000; //1 in 1000
private const int healthchance = 25; // 1 in 25
    public int scoreperenemy;
    public GameObject exposion;

    public void killing() //kill the enemy
    {
        rr.updatescore(scoreperenemy);
        rocketmovements.allenemies.Remove(this.gameObject); //remove it from the list
        
        int show = Random.Range(0, 1000);
        if (show == lifechamce)
        {
            Instantiate(lifepre, transform.position, Quaternion.identity); //we create it at the position that enemy died
        }
        else if(show <= healthchance) //more chance
        {
            Instantiate(healthpre, transform.position, Quaternion.identity);
        }
        Vector2 ps = new Vector2(transform.position.x, transform.position.y-3);
        Vector2 p = gameObject.transform.position;
        Instantiate(exposion, ps, Quaternion.identity);
        
        if (rocketmovements.allenemies.Count == 0) // if we kill all the enemies we have new set
        {
            gamemanage.movesetto();
        }
        Destroy(gameObject);
    }
}
