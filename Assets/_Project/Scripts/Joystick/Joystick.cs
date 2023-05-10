using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace IFB
{
    public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        RectTransform reactBack;
        RectTransform reactJoystick;

        Movement movement;
        Rigidbody2D rigidBody2D;
        Text life;

        private float _radius;
        private bool _touch;

        void Start()
        {
            reactBack = transform.Find("JoystickBack").GetComponent<RectTransform>();
            reactJoystick = transform.Find("JoystickBack/Joystick").GetComponent<RectTransform>();
            life = transform.Find("Life").GetComponent<Text>();

            rigidBody2D = GameObject.Find("Player").GetComponent<Rigidbody2D>();
            movement = GameObject.Find("Player").GetComponent<Movement>();

            life.text = "Vidas: " + Player.t_life.ToString();
            _radius = reactBack.rect.width * 0.25f;
        }

        void Update()
        {
            if(_touch)
            {
                movement.MoveJoystick(reactJoystick, rigidBody2D, Player.t_speedJoystick);
            }
        }

        void OnTouch(Vector2 vectorTouchParam)
        {
            Vector2 vector = new Vector2(vectorTouchParam.x - reactBack.position.x, vectorTouchParam.y - reactBack.position.y);

            vector = Vector2.ClampMagnitude(vector, _radius);
            reactJoystick.localPosition = vector;
        }

        public void OnDrag(PointerEventData eventData)
        {            
            OnTouch(eventData.position);
            _touch = true;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            OnTouch(eventData.position);
            _touch = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            reactJoystick.localPosition = Vector3.zero;
            _touch = false;
        }
    }
}
