using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace IFB
{
    public class Player : MonoBehaviour
    {
        public static bool t_playerWon;
        public static float t_speedJoystick;
        public static float t_life;

        Movement movement;
        Health health;
        Rigidbody2D rigidBody2D;
        Text lifeText;

        [SerializeField]
        private Camera _camera;
        [SerializeField]
        private float _speedMovementKeyboard = 2.0f;
        [SerializeField]
        private float _speedMovementJoystick = 2.5f;
        [SerializeField]
        private int _lifePlayer = 3;
        [SerializeField]
        private int _damage = 1;

        private Vector2 _respawnPosition = new Vector2(-3.001f, 1.643f);

        public Vector2 RespawnPosition { get => _respawnPosition; set => _respawnPosition = value; }

        private void Start()
        {
            rigidBody2D = GetComponent<Rigidbody2D>();

            GameObject gameObjectHealth = new GameObject("Health");
            health = gameObjectHealth.AddComponent<Health>();

            GameObject gameObjectMovement = new GameObject("Movement");
            movement = gameObjectMovement.AddComponent<Movement>();

            t_speedJoystick = _speedMovementJoystick;
            health.InitialLife = _lifePlayer;
            t_life = _lifePlayer;
        }

        private void Update()
        {
            movement.Move(rigidBody2D, _speedMovementKeyboard);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("PlatDamage"))
            {
                if (health.Initial > 0)
                {
                    health.Damage(_damage);
                    lifeText = GameObject.Find("Canvas/Life").GetComponent<Text>();
                    lifeText.text = "Vidas: " + health.Initial.ToString();

                    RespawnPlayer();
                }
                else
                {
                    GameOver(false);
                }
            }
            
            if(collision.gameObject.CompareTag("PlatWon"))
            {
                GameOver(true);
            }
        }

        private void RespawnPlayer()
        {
            transform.position = _respawnPosition;

            movement.StartCoroutine(movement.PauseMovement(rigidBody2D));
            _camera.ResetCamera();
        }

        private void GameOver(bool playerWon)
        {
            t_playerWon = playerWon;

            SceneLoader.t_instance.LoadScene("GameOver");
        }
    }
}
