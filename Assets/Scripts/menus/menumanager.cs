using System.ComponentModel.Design.Serialization;
using System.ComponentModel;
using Unity.Mathematics;
using UnityEngine;

public class menumanager : MonoBehaviour //reponde to all the menu
{
   public GameObject mainmenu;
   public GameObject gameovermenu;
   public GameObject ingamemenu;
   public GameObject pausemenu;
   public GameObject sh;
   private Vector2 pos = new Vector2(100, 31);
   public gettinghurt sta;

   private static menumanager instance;


   private void Start(){ //we open the main menu
      instance.mainmenu.SetActive(true);
      instance.gameovermenu.SetActive(false);
      instance.ingamemenu.SetActive(false);
      instance.pausemenu.SetActive(false);
      resetplayersta();

   }

   public void resetplayersta()
   {
      sta.currenthealth = sta.maxhealth;
      sta.currenlives = sta.maxlives;
      rr.updatinghlive(3);
      rr.updatehealth(3);
   }
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

   public void openmainmenu()
   {

      instance.mainmenu.SetActive(true);
      instance.ingamemenu.SetActive(false); //we dint want to see it
      resetplayersta();
      Debug.Log($"Reset stats - Health: {sta.currenthealth}, Lives: {sta.currenlives}"); 
   }

   public static void opengameovermenu()
   {
      Time.timeScale = 0;
      instance.ingamemenu.SetActive(false);
      instance.gameovermenu.SetActive(true);

   }

   public void openingmenu()
   {
      resetplayersta();
      Debug.Log($"Reset stats - Health: {sta.currenthealth}, Lives: {sta.currenlives}"); 
      sta.currenlives = 3;
      Time.timeScale = 1;
      instance.mainmenu.SetActive(false);
      instance.pausemenu.SetActive(false);
      instance.gameovermenu.SetActive(false);
      instance.ingamemenu.SetActive(true);
      gamemanage.movesetto();
      createShields();
    


   }

   public void openpausemenu()
   {
      Time.timeScale = 0;
      instance.ingamemenu.SetActive(false);
      instance.pausemenu.SetActive(true);
   }

   public void returntomainmenu()
   {
      Time.timeScale = 1;
      instance.gameovermenu.SetActive(false);
      instance.pausemenu.SetActive(false);
      instance.ingamemenu.SetActive(false);
      instance.mainmenu.SetActive(true);
      gamemanage.cancelgame();
      musicmanage.playingbattle();
     
      
   }

   public static void closewindow(GameObject window)
   {
      window.SetActive(false);

   }

   public void closepausemenu()
   {
      Time.timeScale = 1;
      instance.ingamemenu.SetActive(true);
      instance.pausemenu.SetActive(false);
   }

   public void createShields()
   {
      
      GameObject[] existingShields = GameObject.FindGameObjectsWithTag("sheild");
      foreach (GameObject shield in existingShields)
      {
         Destroy(shield);
      }
      Vector2 pos = new Vector2(58f, 31f); // Define starting position
      float gap = 60f;
    
      for (int i = 0; i < 5; i++)
      {
         Instantiate(
            sh,                          
            new Vector2(pos.x + i * gap, pos.y), Quaternion.identity);
      }
   }

  
}
