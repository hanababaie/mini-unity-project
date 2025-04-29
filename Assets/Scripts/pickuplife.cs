using UnityEngine;

public class pickuplife : pickups
{
   public override void Pickupit()
   {
      GameObject.FindGameObjectWithTag("Player").GetComponent<playermovements>().addlife();
      GameObject.FindGameObjectWithTag("Player").GetComponent<playermovements>().addhelth(); //when they hit it make it less so we do this to cancel the effect
      Destroy(gameObject);
   } 
}
