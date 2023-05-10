using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace IFB
{
    public class GameOverText : MonoBehaviour
    {
        public Text gameOverText;

        void Start()
        {
            if (Player.t_playerWon)
            {
                gameOverText.text = "Won";
            } 
            else
            {
                gameOverText.text = "Game Over";
            }
        }
    }
}
