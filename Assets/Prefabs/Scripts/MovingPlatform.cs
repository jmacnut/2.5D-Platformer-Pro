using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
   [SerializeField]
   private float _speed = 1.0f;

   [SerializeField]
   private Transform _targetA;

   [SerializeField]
   private Transform _targetB;

   private bool _switch;

   void Start()
   {

   }

   // consistent update loop to remedy player jitter when on a platform
   void FixedUpdate()
   {
      float step = _speed * Time.deltaTime;

      if (_switch == false)
      {
         transform.position = Vector3.MoveTowards(transform.position, _targetB.position, step);
      }
      else if (_switch == true)
      {
         transform.position = Vector3.MoveTowards(transform.position, _targetA.position, step);
      }

      // if at point a, go to point b
      if (transform.position == _targetA.position)
      {
         _switch = false;
      }

      // if at point b, go to point a
      else if (transform.position == _targetB.position)
      {
         _switch = true;
      }

   }

   // collision detection
   // if we collide with player
   // then assign player parent = this game object
   private void OnTriggerEnter(Collider other)
   {
      if (other.tag == "Player")
      {
         other.transform.SetParent(this.transform);
      }
   }

   // exit collision detection
   // if player exited
   // assign player parent == null
   private void OnTriggerExit(Collider other)
   {
      if (other.tag == "Player")
      {
         other.transform.SetParent(null);
      }
   }

}
