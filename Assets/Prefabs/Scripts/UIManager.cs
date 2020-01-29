
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
   // update coin count

   [SerializeField]
   private Text _coinCountText;

   public void UpdateCoinCount(int coinCount)
   {
      _coinCountText.text = "Coins: " + coinCount;
   }
}
