using System.Collections;
using UnityEngine;

public class gamemanage : MonoBehaviour
{
   public GameObject[] setofem; //one collection of villians
   private GameObject currentsetofem;
   private Vector2 pos = new Vector2(240, 500);
   public GameObject sheilds;
  
   public static gamemanage instance;

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

   
   public static void movesetto()
   {
      instance.StartCoroutine(instance.moveset());
   }

   private IEnumerator moveset() 
   {
     
      
      rocketmovements.allenemies.Clear();
      musicmanage.playingbattle();
      if (currentsetofem != null) //check if we have a set so we have to delete the enemies parant
      {
         Destroy(currentsetofem);
      }

      yield return new WaitForSeconds(3f); // we wait for 3 seconds;
      
      currentsetofem = Instantiate(setofem[Random.Range(0, setofem.Length)],pos, Quaternion.identity); //create the set
      rr.updatewave(); //update the pa
      
   }

   public static void cancelgame(){ // us this when palyer exist the game.
      rr.Resetui();
      instance.StopAllCoroutines(); //stiping all of the cortoutines
      
      rocketmovements.allenemies.Clear();
      if (instance.currentsetofem != null)
      {
         Destroy(instance.currentsetofem);
      }

      foreach (var bomb in GameObject.FindGameObjectsWithTag("bomb"))
    Destroy(bomb);

    foreach (var explosion in GameObject.FindGameObjectsWithTag("exp"))
    Destroy(explosion);

    foreach (var pickup in GameObject.FindGameObjectsWithTag("pick"))
    Destroy(pickup);
    
    musicmanage.stopbattle(); //after existimh music will be sstopped
    

   }
   
   public static void createsheilds(GameObject sheilds)
   {
      Vector2 pos = new Vector2(240, 500);
      float gap = 60;
    
      for (int i = 0; i < 5; i++)
      {
         Instantiate(sheilds ,pos , Quaternion.identity );
      } 
   }

}
