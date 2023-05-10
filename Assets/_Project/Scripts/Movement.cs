using IFB.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IFB
{
    public class Movement : MonoBehaviour, IMovement
    {
        KeyboardInput kInput = new KeyboardInput();

        private Vector2 _directionRight = new Vector2(1, 0);
        private Vector2 _directionLeft = new Vector2(-1, 0);
        private Vector2 _directionUp = new Vector2(0, 1);

        public void Move(Rigidbody2D rigidBody, float speed)
        {
            if (kInput.GetActionButtonDown())
            {
                if (kInput.GetHorizontalButton() > 0)
                {
                    rigidBody.AddForce(_directionRight * speed);
                }
                else if (kInput.GetHorizontalButton() < 0)
                {
                    rigidBody.AddForce(_directionLeft * speed);
                }

                if (kInput.GetVerticalButton() > 0)
                {
                    rigidBody.AddForce(_directionUp * speed);
                }
            }
        }

        public void MoveJoystick(RectTransform reactJoystick, Rigidbody2D rigidBody, float speed)
        {
            if (reactJoystick.localPosition.x > 0)
            {
                rigidBody.AddForce(_directionRight * speed);
            }
            else if (reactJoystick.localPosition.x < 0)
            {
                rigidBody.AddForce(_directionLeft * speed);
            }

            if (reactJoystick.localPosition.y > 0)
            {
                rigidBody.AddForce(_directionUp * speed);
            }
        }

        public IEnumerator PauseMovement(Rigidbody2D rigidBody)
        {
            rigidBody.velocity = Vector2.zero;
            rigidBody.angularVelocity = 0f;
            rigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
            rigidBody.isKinematic = true;

            yield return new WaitForSeconds(1);

            rigidBody.constraints = RigidbodyConstraints2D.None;
            rigidBody.isKinematic = false;
        }
    }
}
