using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IFB
{

    public class Item : MonoBehaviour
    {
        public Player player;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            player.RespawnPosition = transform.position;
            Destroy(gameObject);
        }
    }
}
