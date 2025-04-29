using UnityEngine;
[System.Serializable] //for saving we use this
public class saveobject
{
   public int highscore;
   public gettinghurt sta;


   public saveobject(){
    highscore = 0;
    sta = new gettinghurt();
    sta.maxhealth = 3;
    sta.maxlives = 3;
    sta.firepower = 0.5f;
    sta.shipspeed = 20;
   }
}
