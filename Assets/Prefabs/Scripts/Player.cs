using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   [SerializeField]
   private CharacterController _characterController;

   [SerializeField]
   private float _speed = 5.0f;

   [SerializeField]
   private float _gravity = 1.0f;   // real world = -9.81f

   [SerializeField]
   private float _jumpHeight = 20.0f;

   [SerializeField]
   private float _yVelocity;   // cached velocity

   private bool _doubleJump;

   [SerializeField]
   private int _coinCount;   // collectable count

   private UIManager _uiManager;


   void Start()
   {
      _characterController = GetComponent<CharacterController>();

      _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
      if (_uiManager == null)
      {
         Debug.LogError("The UI Manager is NULL");
      }

   }

   void Update()
   {
      // get horizontal input
      float horizontalInput = Input.GetAxis("Horizontal");

      // define direction based on that input
      Vector3 direction = new Vector3(horizontalInput, 0, 0);

      // velocity = direction * speed
      Vector3 velocity = direction * _speed;


      // if grounded
      if (_characterController.isGrounded == true)
      {
         // if space key pressed
         if (Input.GetKeyDown(KeyCode.Space))
         {
            // then, jump! (assign y velocity to jump height)
            _yVelocity = _jumpHeight;
            _doubleJump = true;
         }
      }
      else   // if not grounded
      {
         // check for double jump
         if (Input.GetKeyDown(KeyCode.Space))
         {
            if (_doubleJump == true)
            {
               // current _yVelocity += jumpHeight
               _yVelocity += _jumpHeight;
               _doubleJump = false;
            }

         }

         // then, apply gravity to velocity
         _yVelocity -= _gravity;
      }

      // assign cached y velocity
      velocity.y = _yVelocity;

      // move based on that direction
      _characterController.Move(velocity * Time.deltaTime);

   }
   
   public void CollectCoin()
   {
      _coinCount++;

      _uiManager.UpdateCoinCount(_coinCount);
   }

}