using UnityEngine;

public class pickuphealth : pickups //inherted from pickuip 
{
   public override void Pickupit()
   {
      GameObject.FindGameObjectWithTag("Player").GetComponent<playermovements>().addhelth();
      GameObject.FindGameObjectWithTag("Player").GetComponent<playermovements>().addhelth();
      Destroy(gameObject);

   } 
}
