using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
   [SerializeField]
   private GameObject _respawnLocation;

   private void OnTriggerEnter(Collider other)
   {
      if (other.tag == "Player")
      {
         Player player = other.GetComponent<Player>();
         if (player != null)
         {
            // reduce number of lives
            // update lives in UI
            player.Damage();
         }
         else
         {
            Debug.LogError("The Player object is NULL.");
         }

         CharacterController cc = other.GetComponent<CharacterController>();

         if (cc != null)
         {
            cc.enabled = false;
         }

         // respawn player in original position
         other.transform.position = _respawnLocation.transform.position;
         // destroy player
         //Destroy(other.gameObject);

         StartCoroutine(CCEnableRoutine(cc));

      }
   }

   IEnumerator CCEnableRoutine(CharacterController controller)
   {
      yield return new WaitForSeconds(1.0f);

      controller.enabled = true;
   }
}
