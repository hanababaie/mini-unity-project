using UnityEngine;

public class savemanager : MonoBehaviour //make it a singlton
{
    private static savemanager instance;
    public GameObject ship;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        laodgame();
        
    }

    public static void svaepro()
    {
        saveobject saved = saving.loading();
        saved.highscore = rr.gethighscore();
        saved.sta = GameObject.FindGameObjectWithTag("Player").GetComponent<playermovements>().sta;
    }

    public static void laodgame()
    {
        saveobject saved = saving.loading();
        rr.updatinghighscore(saved.highscore);
        GameObject.FindGameObjectWithTag("Player").GetComponent<playermovements>().sta = saved.sta;
    }
}
