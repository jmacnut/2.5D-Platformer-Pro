using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

   private void OnTriggerEnter(Collider other)
   {

      if (other.tag == "Player")
      {
         // give the player a coin
         Player player = other.GetComponent<Player>();

         if(player != null)
         {
            // collect coin
            player.CollectCoin();

            // destroy this coin
            Destroy(this.gameObject);
         }
         else
         {
            Debug.LogError("Coin(): Player is NULL.");
         }

      }

   }
}
